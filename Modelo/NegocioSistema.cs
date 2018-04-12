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
using ViewModel.Catalogo._ItemModulo;
using ViewModel.Catalogo._Sistema;
using ViewModel.Catalogo._PermisoItem;
using ViewModel;
using ViewModel.Catalogo._ToolItem;

using Tools;

namespace Modelo
{
    public class NegocioSistema
    {
        public string IniciarSesion(string usuario,string llave,string ip,string sistema, bool cerrarSesiones)
        {
            try
            {
                Exception excep = new Exception("");
                if (llave.Length > 0)
                {
                    byte[] usr = Convert.FromBase64String(usuario);
                    byte[] pws = Convert.FromBase64String(llave);
                    

                    llave = Encriptacion.EncriptarContraseña(Encriptacion.Desencriptar(pws), Encriptacion.Desencriptar(usr));
                    //Obtiene llave del usuario
                    IDAOSistema iDaoSis = new DAOSistema();

                    RespuestaBD resp = iDaoSis.IniciarSesion(Encriptacion.Desencriptar(usr),
                                         llave, ip, sistema,cerrarSesiones);
                    if (resp.EXISTE_ERROR)
                    {
                        excep = new Exception(resp.MENSAJE);
                        excep.Data.Add("code", resp.respuesta);
                        throw excep;
                    }
                    else
                    {
                        return this.GenerarToken(Encriptacion.Desencriptar(usr));
                    }
                          
                }
                else
                {
                    excep = new Exception("Constraseña no especificada");
                    excep.Data.Add("code", 1);
                    throw excep;
                }
            }
            catch (Exception ex)
            {
                Exception excep = new Exception(new Util().ObtenerMsjExcepcion(ex));
                if (ex.Data["code"] == null)
                {
                    excep.Data.Add("code", 1);//Error no especificado
                }
                else
                {
                    excep.Data.Add("code", ex.Data["code"]);
                }
                throw excep;                
            }
        }

        public void CerrarSesion(string usuario)
        {
            try
            {
                IDAOSistema iDaoSis = new DAOSistema();
                RespuestaBD resp = iDaoSis.CerrarSesion(usuario);
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

        public List<VMItemModulo> ObtenerItemsUsuario(string usuario)
        {
            try
            {
                IDAOUsuario iDaoUsuario = new DAOUsuario();
                RespuestaBD resp = iDaoUsuario.ObtenerItemsUsuario(usuario);
                if (resp.EXISTE_ERROR)
                {
                    throw new Exception(resp.MENSAJE);
                }
                else
                {
                    List<VMItemModulo> lista = new List<VMItemModulo>();
                    if (resp.dataSet.Tables.Count > 0)
                    {
                        DataTable datos = resp.dataSet.Tables[0];
                        lista = (from x in datos.AsEnumerable()
                                 select new VMItemModulo()
                                 {
                                     Activo = x.Field<bool>("fl_estatus_item"),
                                     Descripcion = x.Field<string>("fc_desc_item"),
                                     IdItemModulo = x.Field<int>("fi_id_item_modulo"),
                                     IdItemPadre = x.Field<int>("fi_id_item_padre"),
                                     IdModulo = x.Field<int>("fi_id_modulo"),
                                     IdSistema = x.Field<int>("fi_id_sistema"),
                                     Modulo = x.Field<string>("fc_nombre_modulo"),
                                     Orden = x.Field<int>("fi_id_orden"),
                                     Sistema = x.Field<string>("fc_nombre_sistema"),
                                     Url = x.Field<string>("fc_url"),
                                     UrlIcono = x.Field<string>("fc_url_icono"),
                                     UrlIconoModulo = x.Field<string>("fc_url_icono_modulo")


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

        public List<VMSistema> ObtenerSistemasUsuario(string usuario)
        {
            try
            {
                IDAOUsuario iDaoUsuario = new DAOUsuario();
                RespuestaBD resp = iDaoUsuario.ObtenerItemsUsuario(usuario);
                if (resp.EXISTE_ERROR)
                {
                    throw new Exception(resp.MENSAJE);
                }
                else
                {
                    List<VMSistema> lista = new List<VMSistema>();
                    if (resp.dataSet.Tables.Count > 1)
                    {
                        DataTable datos = resp.dataSet.Tables[1];
                        lista = (from x in datos.AsEnumerable()
                                 select new VMSistema()
                                 {
                                     IdSistema = x.Field<int>("fi_id_sistema"),
                                     NombreSistema = x.Field<string>("fc_nombre_sistema"),
                                     Logo = x.Field<string>("fc_logo"),
                                     UrlHome = x.Field<string>("fc_url_home"),
                                     Embebido = x.Field<bool>("fl_embebido")

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

        public List<VMPermisoItem> ObtenerPermisosItemsUsuario(string usuario, int? idSistema, int? idRol)
        {
            try
            {
                IDAOPermisosItem iDaoPermisos = new DAOPermisosItem();
                RespuestaBD resp = iDaoPermisos.ObtenerItemsUsuarioRol( usuario /*Encriptacion.Desencriptar(Convert.FromBase64String( usuario))*/,idSistema,idRol);
                if (resp.EXISTE_ERROR)
                {
                    throw new Exception(resp.MENSAJE);
                }
                else
                {
                    List<VMPermisoItem> lista = new List<VMPermisoItem>();
                    if (resp.dataSet.Tables.Count > 0)
                    {
                        DataTable datos = resp.dataSet.Tables[0];
                        lista = (from x in datos.AsEnumerable()
                                 select new VMPermisoItem()
                                 {
                                    Delete = x.Field<bool>("fl_delete"),
                                    IdItemModulo = x.Field<int>("fi_id_item_modulo"),
                                    IdUsuarioPermisos = x.Field<int>("fi_id_usuario_permisos"),
                                    Nombre = x.Field<string>("fc_desc_item"),
                                    Write = x.Field<bool>("fl_write"),
                                    IdRol = x.Field<int>("fi_id_rol"),
                                    NombreRol = x.Field<string>("fc_nombre_rol"),
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

        public List<VMToolItem> ObtenerPermisosToolsUsuario(int idUsuarioPermisos)
        {
            try
            {
                IDAOPermisosTool iDaoPermisos = new DAOPermisosTool();
                RespuestaBD resp = iDaoPermisos.ObtenerToolsUsuarioRol(idUsuarioPermisos);
                if (resp.EXISTE_ERROR)
                {
                    throw new Exception(resp.MENSAJE);
                }
                else
                {
                    List<VMToolItem> lista = new List<VMToolItem>();
                    if (resp.dataSet.Tables.Count > 0)
                    {
                        DataTable datos = resp.dataSet.Tables[0];
                        lista = (from x in datos.AsEnumerable()
                                 select new VMToolItem()
                                 {
                                     IdTool = x.Field<int>("fi_id_herramienta"),
                                     IdUsuarioPermisos = x.Field<int>("fi_id_usuario_permisos"),
                                     Nombre = x.Field<string>("fc_nombre"),
                                     Permitir = x.Field<bool>("fl_permitir")
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

        public RespuestaSesion ValidarToken(string token)
        {
            try
            {
                RespuestaSesion respuestaSesion = new RespuestaSesion();                
                IDAOSistema iDaoSistema = new DAOSistema();
                RespuestaBD resp = iDaoSistema.ValidarToken(token);
                if (resp.EXISTE_ERROR)
                {
                    respuestaSesion.Activa = false;
                    respuestaSesion.Mensaje = resp.MENSAJE ;
                    respuestaSesion.Code = resp.respuesta;
                }
                else
                {
                    respuestaSesion.Activa = true;
                    respuestaSesion.Mensaje = "Token ok";
                    respuestaSesion.Code = "0";
                }
                return respuestaSesion;
            }
            catch (Exception ex)
            {
                throw new Exception(new Util().ObtenerMsjExcepcion(ex));
            }
        }

        public RespuestaSesion ValidarAcceso(string url, string usuario)
        {
            try
            {
                RespuestaSesion respuestaSesion = new RespuestaSesion();
                IDAOSistema iDaoSistema = new DAOSistema();
                RespuestaBD resp = iDaoSistema.ValidarAcceso(url,usuario);
                if (resp.EXISTE_ERROR)
                {
                    respuestaSesion.Activa = false;
                    respuestaSesion.Mensaje = resp.MENSAJE;
                    respuestaSesion.Code = resp.respuesta;
                }
                else
                {
                    respuestaSesion.Activa = true;
                    respuestaSesion.Mensaje = "Acceso permitido";
                    respuestaSesion.Code = "0";
                }
                return respuestaSesion;
            }
            catch (Exception ex)
            {
                throw new Exception(new Util().ObtenerMsjExcepcion(ex));
            }
        }
        
        public string GenerarToken(string usuario)
        {
            try
            {
                //Genera token 
                
                string bufer = "USUARIO="+usuario+";Time="+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string token = Convert.ToBase64String( Encriptacion.Encriptar(bufer,usuario));
                string nombre = string.Empty;
                string correo = string.Empty;
                string extension = string.Empty;

                //Busca informacion de usuario
                IDAOUsuario iDaoUsuario = new DAOUsuario();
                RespuestaBD resp = iDaoUsuario.ObtenerListaUsuarios(null,usuario);
                if(!resp.EXISTE_ERROR)
                {
                    if(resp.dataSet.Tables[0].Rows.Count>0)
                    {
                       DataRow r = resp.dataSet.Tables[0].Rows[0];

                        nombre = (string) r["fc_nombre"] +" " + (string) r["fc_apellido_p"]+" " +(string) r["fc_apellido_m"];
                        correo = (string) r["fc_correo"];
                        extension = (string) r["fc_extension_usuario"];
                    }
                }
                
                string cadRespuesta = nombre+";"+correo+";"+extension+";"+usuario+";"+token;

                RespuestaSesion respuestaSesion = new RespuestaSesion();
                IDAOSistema iDaoSistema = new DAOSistema();
                resp = iDaoSistema.RegistrarToken(token, DateTime.Now.AddMinutes(15), usuario);
                
                if (resp.EXISTE_ERROR)
                {
                    throw new Exception("No es posible registrar el Token");
                }
                return Convert.ToBase64String(Encriptacion.Encriptar(cadRespuesta));//Retorna cadena encriptada
            }
            catch (Exception ex)
            {
                throw new Exception(new Util().ObtenerMsjExcepcion(ex));
            }
        }

    }
}
