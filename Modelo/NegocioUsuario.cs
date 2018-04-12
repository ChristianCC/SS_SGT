using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using DAO;
using DAO.ADO;
using Entidad.Common;
using System.ServiceModel;
using ViewModel.Catalogo._Usuario;
using ViewModel.Catalogo._Rol;
using Tools;

namespace Modelo
{
    public class NegocioUsuario
    {
        public List<VMUsuario> ObtenerTodosLosUsuarios()
        {
            try
            {
                IDAOUsuario iDaoUsuario = new DAOUsuario();
                RespuestaBD resp = iDaoUsuario.ObtenerListaUsuarios(null);
                if (resp.EXISTE_ERROR)
                {
                    throw new Exception(resp.MENSAJE);
                }
                else
                {
                    List<VMUsuario> lista = new List<VMUsuario>();
                    if (resp.dataSet.Tables.Count > 0)
                    {
                        DataTable datos = resp.dataSet.Tables[0];
                        lista = (from x in datos.AsEnumerable()
                                 select new VMUsuario()
                                 {
                                     Apellido_materno = x.Field<string>("fc_apellido_m"),
                                     Apellido_paterno = x.Field<string>("fc_apellido_p"),
                                     Celular = x.Field<string>("fc_celular"),
                                     Correo = x.Field<string>("fc_correo"),
                                     Estatus = x.Field<string>("fc_desc_estatus"),
                                     Extension = x.Field<string>("fc_extension_Usuario"),
                                     FechaDeRegistro = x.Field<DateTime>("fd_fecha_registro"),
                                     FechaDeVencimiento = x.Field<DateTime>("fd_fecha_vencimiento"),
                                     Nombre = x.Field<string>("fc_nombre"),
                                     Usuario_sistema = x.Field<string>("fc_Usuario"),

                                 }).ToList();
                    }
                    return lista;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(new Util().ObtenerMsjExcepcion(ex));
            }
        }

        public VMUsuario RegistrarUsuario(string nombre, string apellidoMaterno, string apellidoPaterno, string celular, string correo,
            string extension, int idEstatus, string password, string usuario_sistema)
        {
            try
            {
                string error = string.Empty;
                if (string.IsNullOrEmpty(usuario_sistema))
                {
                    error += "- Debes registrar un Usuario." + "<br />";
                }
                else if (usuario_sistema.IndexOf(' ') >= 0)
                {
                    error += "- El Usuario no puede contener espacios." + "<br />";
                }
                if (string.IsNullOrEmpty(password))
                {
                    error += "- Debes registrar una contraseña." + "<br />";
                }
                if (string.IsNullOrEmpty(nombre))
                {
                    error += "- Debes registrar un nombre." + "<br />";
                }
                if (string.IsNullOrEmpty(correo))
                {
                    error += "- Debes registrar un correo." + "<br />";
                }
                if (string.IsNullOrEmpty(error))
                {
                    byte[] usr = Convert.FromBase64String(usuario_sistema);
                    byte[] pws = Convert.FromBase64String(password);


                    VMUsuario Usuario = new VMUsuario();
                    IDAOUsuario iDaoUsuario = new DAOUsuario();
                    RespuestaBD resp = iDaoUsuario.RegistrarUsuario(
                        Encriptacion.Desencriptar(usr),
                        Encriptacion.EncriptarContraseña(Encriptacion.Desencriptar(pws), Encriptacion.Desencriptar(usr)),
                          nombre, apellidoPaterno,
                    apellidoMaterno, correo, celular, extension);
                    if (resp.EXISTE_ERROR)
                    {
                        throw new Exception(resp.MENSAJE);
                    }
                    else
                    {
                        Usuario = new VMUsuario()
                        {
                            Apellido_materno = apellidoMaterno,
                            Apellido_paterno = apellidoPaterno,
                            Celular = celular,
                            Correo = correo,
                            Extension = extension,
                            IdEstatus = idEstatus,
                            Nombre = nombre,
                            Usuario_sistema = usuario_sistema,
                            FechaDeRegistro = (DateTime)resp.dataSet.Tables[0].Rows[0]["fd_fecha_registro"],
                            FechaDeVencimiento = (DateTime)resp.dataSet.Tables[0].Rows[0]["fd_fecha_vencimiento"],
                            Password = string.Empty
                        };
                    }
                    return Usuario;
                }
                else
                {
                    throw new Exception(error);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(new Util().ObtenerMsjExcepcion(ex));
            }
        }

        public void ActualizarUsuario(VMUsuario Usuario)
        {
            try
            {
                IDAOUsuario iDaoUsuario = new DAOUsuario();
                RespuestaBD resp = iDaoUsuario.EditarUsuario(
                    Usuario.Usuario_sistema,
                    Usuario.Password,
                    Usuario.Nombre,
                    Usuario.Apellido_paterno,
                    Usuario.Apellido_materno,
                    Usuario.Correo,
                    Usuario.Celular,
                    Usuario.Extension,
                    Usuario.FechaDeVencimiento,
                    Usuario.IdEstatus
                    );
                if (resp.EXISTE_ERROR)
                {
                    throw new Exception(resp.MENSAJE);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(new Util().ObtenerMsjExcepcion(ex));
            }
        }

        public List<VMRol> ObtenerRoles(int idSistema)
        {
            try
            {
                IDAORol iDaoRol = new DAORol();
                RespuestaBD resp = iDaoRol.ObtenerRoles(idSistema, true);
                if (resp.EXISTE_ERROR)
                {
                    throw new Exception(resp.MENSAJE);
                }
                else
                {
                    List<VMRol> lista = new List<VMRol>();
                    if (resp.dataSet.Tables.Count > 0)
                    {
                        DataTable datos = resp.dataSet.Tables[0];
                        lista = (from x in datos.AsEnumerable()
                                 select new VMRol()
                                 {
                                     Pais = x.Field<string>("fc_pais"),
                                     Descripcion = x.Field<string>("fc_descripcion"),
                                     IdPais = x.Field<int>("fi_id_pais"),
                                     IdRol = x.Field<int>("fi_id_Rol"),
                                     Nombre = x.Field<string>("fc_nombre"),
                                     Activo = x.Field<bool>("fl_activo")

                                 }).ToList();
                    }
                    return lista;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(new Util().ObtenerMsjExcepcion(ex));
            }
        }

        public List<VMRol> ObtenerRolesUsuario(string usuario, int? idSistema = null)
        {
            try
            {
                IDAORol iDaoRol = new DAORol();
                RespuestaBD resp = iDaoRol.ObtenerRolesUsuario(usuario, idSistema);
                if (resp.EXISTE_ERROR)
                {
                    throw new Exception(resp.MENSAJE);
                }
                else
                {
                    List<VMRol> lista = new List<VMRol>();
                    if (resp.dataSet.Tables.Count > 0)
                    {
                        DataTable datos = resp.dataSet.Tables[0];
                        lista = (from x in datos.AsEnumerable()
                                 select new VMRol()
                                 {
                                     Pais = x.Field<string>("fc_pais"),
                                     Descripcion = x.Field<string>("fc_descripcion"),
                                     IdPais = x.Field<int>("fi_id_pais"),
                                     IdRol = x.Field<int>("fi_id_Rol"),
                                     Nombre = x.Field<string>("fc_nombre"),
                                     Activo = x.Field<bool>("fl_activo")

                                 }).ToList();
                    }
                    return lista;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(new Util().ObtenerMsjExcepcion(ex));
            }
        }

        public VMRol RegistrarRol(string nombre, string descripcion, int idPais, int idRol = 0)
        {
            try
            {
                IDAORol iDaoRol = new DAORol();

                VMRol Rol = new VMRol();
                RespuestaBD resp = iDaoRol.RegistrarEditarRol(idRol, descripcion, nombre, idPais, true);
                if (resp.EXISTE_ERROR)
                {
                    throw new Exception(resp.MENSAJE);
                }
                else
                {
                    Rol.Descripcion = descripcion;
                    Rol.Nombre = nombre;
                    Rol.IdPais = idPais;
                    Rol.IdRol = Convert.ToInt32(resp.dataSet.Tables[0].Rows[0]["fi_id_Rol"].ToString());
                    Rol.Pais = resp.dataSet.Tables[0].Rows[0]["fc_pais"].ToString();
                    return Rol;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(new Util().ObtenerMsjExcepcion(ex));
            }
        }

        public void AsignarRolUsuario(int idRol, string usuario, int idPais)
        {
            try
            {
                IDAOUsuario iDaoUsuario = new DAOUsuario();
                RespuestaBD resp = iDaoUsuario.RegistrarEditarRolUsuario(idRol, usuario, idPais, false);
                if (resp.EXISTE_ERROR)
                {
                    throw new Exception(resp.MENSAJE);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(new Util().ObtenerMsjExcepcion(ex));
            }
        }

        public void EliminarRolUsuario(int idRol, string usuario, int idPais)
        {
            try
            {
                IDAOUsuario iDaoUsuario = new DAOUsuario();
                RespuestaBD resp = iDaoUsuario.RegistrarEditarRolUsuario(idRol, usuario, idPais, true);
                if (resp.EXISTE_ERROR)
                {
                    throw new Exception(resp.MENSAJE);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(new Util().ObtenerMsjExcepcion(ex));
            }
        }

        public void ResetPassUsuario(string usuario_sistema)
        {
            //busca info del usuario
            try
            {
                IDAOUsuario iDaoUsuario = new DAOUsuario();
                string usuario = Encriptacion.Desencriptar(Convert.FromBase64String(usuario_sistema));
                RespuestaBD resp = iDaoUsuario.ObtenerListaUsuarios(null, usuario);
                if (resp.EXISTE_ERROR)
                {
                    throw new Exception(resp.MENSAJE);
                }
                else
                {
                    List<VMUsuario> lista = new List<VMUsuario>();
                    if (resp.dataSet.Tables.Count > 0)
                    {
                        if (resp.dataSet.Tables[0].Rows.Count > 0)
                        {
                            //el usuario existe
                            //Genera nueva contraseña

                            string password = Encriptacion.EncriptarContraseña(
                                usuario,
                                usuario);
                            resp = iDaoUsuario.EditarPassword(usuario, password);
                            if (resp.EXISTE_ERROR)
                            {
                                throw new Exception(resp.MENSAJE);
                            }
                        }
                        else
                        {
                            throw new Exception("No se encontro registro de este usuario");
                        }
                    }
                    else
                    {
                        throw new Exception("No se encontro registro de este usuario");
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception(new Util().ObtenerMsjExcepcion(ex));
            }
        }

        public VMUsuario ObtenerInfoUsuario(string usuario_sistema)
        {
            try
            {
                //byte[] usr = Convert.FromBase64String(usuario_sistema);

                VMUsuario Usuario = new VMUsuario();
                IDAOUsuario iDaoUsuario = new DAOUsuario();
                RespuestaBD resp = iDaoUsuario.ObtenerInfoUsuario(
                    //Encriptacion.Desencriptar(usr)
                    usuario_sistema
                    );
                if (resp.EXISTE_ERROR)
                {
                    throw new Exception(resp.MENSAJE);
                }
                else
                {
                    if (resp.dataSet.Tables.Count > 0)
                    {
                        Usuario = (from x in resp.dataSet.Tables[0].AsEnumerable()                                   
                                   select new VMUsuario()
                                         {
                                             Apellido_materno = x.Field<string>("fc_apellido_m"),
                                             Apellido_paterno = x.Field<string>("fc_apellido_p"),
                                             Celular = x.Field<string>("fc_celular"),
                                             Correo = x.Field<string>("fc_correo"),
                                             Extension = x.Field<string>("fc_extension_usuario"),
                                             IdEstatus = x.Field<int>("fi_id_estatus"),
                                             Nombre = x.Field<string>("fc_nombre"),
                                             Usuario_sistema = x.Field<string>("fc_usuario"),
                                             FechaDeRegistro = x.Field<DateTime?>("fd_fecha_registro"),
                                             FechaDeVencimiento = x.Field<DateTime?>("fd_fecha_vencimiento"),
                                             Password = string.Empty
                                         }

                            ).FirstOrDefault();
                    }
                    else
                    {
                         throw new Exception("No información de este usuario");
                    }
                    
                }
                return Usuario;

            }
            catch (Exception ex)
            {
                throw new Exception(new Util().ObtenerMsjExcepcion(ex));
            }
        }

        public void ModificarPassUsuario(string usuario_sistema, string passAnterior, string passNueva)
        {
            //busca info del usuario
            try
            {
                IDAOUsuario iDaoUsuario = new DAOUsuario();

                byte[] usr = Convert.FromBase64String(usuario_sistema); // obtiene usuario
                byte[] pws = Convert.FromBase64String(passAnterior);// obtiene password
                byte[] pwsNew = Convert.FromBase64String(passNueva); //obtiene password nueva

                RespuestaBD resp = iDaoUsuario.EditarPassword(
                    Encriptacion.Desencriptar(usr),
                    Encriptacion.EncriptarContraseña(Encriptacion.Desencriptar(pwsNew), Encriptacion.Desencriptar(usr)),
                    Encriptacion.EncriptarContraseña(Encriptacion.Desencriptar(pws), Encriptacion.Desencriptar(usr))
                      );
                if (resp.EXISTE_ERROR)
                {
                    throw new Exception(resp.MENSAJE);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(new Util().ObtenerMsjExcepcion(ex));
            }
        }


    }
}
