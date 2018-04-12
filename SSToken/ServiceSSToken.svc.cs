using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;


using ViewModel;
using ViewModel.Catalogo;
using ViewModel.Catalogo._ItemModulo;
using ViewModel.Catalogo._Pais;
using ViewModel.Catalogo._Rol;
using ViewModel.Catalogo._Sistema;
using ViewModel.Catalogo._Usuario;
using ViewModel.Catalogo._PermisoItem;
using ViewModel.Catalogo._ToolItem;
using ViewModel.Catalogo._Modulo;
using Modelo;

namespace SSToken
{

    public class ServiceSSToken : /*IServiceToken,*/ IServiceGestion, IServiceAcceso
    {
        #region ServiceGestion

        public VMUsuario RegistrarNuevoUsuario(string Nombre, string apellidoMaterno, string apellidoPaterno, string celular, string correo,
            string extension, int idEstatus, string password, string usuario_sistema)
        {
            try
            {
                return new NegocioUsuario().RegistrarUsuario(Nombre, apellidoMaterno, apellidoPaterno, celular, correo,
                 extension, idEstatus, password, usuario_sistema);
            }
            catch (Exception ex)
            {
                ExceptionService exception = new ExceptionService()
                {
                    Mensaje = ex.Message,
                    Operacion = "Registro de Usuario."
                };
                throw new FaultException<ExceptionService>(exception);
            }
        }

        public void EditarUsuario(VMUsuario usuario)
        {
            try
            {
                new NegocioUsuario().ActualizarUsuario(usuario);
            }
            catch (Exception ex)
            {
                ExceptionService exception = new ExceptionService()
                {
                    Mensaje = ex.Message,
                    Operacion = "Actuazliar Usuario."
                };
                throw new FaultException<ExceptionService>(exception);
            }
        }

        public IEnumerable<VMUsuario> ObtenerCatalogoUsuarios()
        {
            try
            {
                return new NegocioUsuario().ObtenerTodosLosUsuarios();
            }
            catch (Exception ex)
            {
                ExceptionService exception = new ExceptionService()
                {
                    Mensaje = ex.Message,
                    Operacion = "Catálogo de Usuarios."
                };
                throw new FaultException<ExceptionService>(exception);
            }
        }

        public void ResetPassUsuario(string usuario_sistema)
        {
            try
            {
                new NegocioUsuario().ResetPassUsuario(usuario_sistema);
            }
            catch (Exception ex)
            {
                ExceptionService exception = new ExceptionService()
                {
                    Mensaje = ex.Message,
                    Operacion = "Reset contraseña."
                };
                throw new FaultException<ExceptionService>(exception);
            }
        }

        public VMUsuario ObtenerInfoUsuario(string usuario_sistema)
        {
            try
            {
                return new NegocioUsuario().ObtenerInfoUsuario(usuario_sistema);
            }
            catch (Exception ex)
            {
                ExceptionService exception = new ExceptionService()
                {
                    Mensaje = ex.Message,
                    Operacion = "Información de Usuarios."
                };
                throw new FaultException<ExceptionService>(exception);
            }
        }

        public IEnumerable<VMRol> ObtenerRoles(int idSistema)
        {
            try
            {
                return new NegocioUsuario().ObtenerRoles(idSistema);
            }
            catch (Exception ex)
            {
                ExceptionService exception = new ExceptionService()
                {
                    Mensaje = ex.Message,
                    Operacion = "Catálogo de Roles."
                };
                throw new FaultException<ExceptionService>(exception);
            }
        }

        public IEnumerable<VMRol> ObtenerRolesUsuario( string usuario, int? idSistema)
        {
            try
            {
                return new NegocioUsuario().ObtenerRolesUsuario(usuario,idSistema);
            }
            catch (Exception ex)
            {
                ExceptionService exception = new ExceptionService()
                {
                    Mensaje = ex.Message,
                    Operacion = "Roles de usuario."
                };
                throw new FaultException<ExceptionService>(exception);
            }
        }

        public VMRol RegistrarNuevoRol(string nombre, string descripcion, int idPais)
        {
            try
            {
                return new NegocioUsuario().RegistrarRol(nombre, descripcion, idPais);
            }
            catch (Exception ex)
            {
                ExceptionService exception = new ExceptionService()
                {
                    Mensaje = ex.Message,
                    Operacion = "Nuevo rol."
                };
                throw new FaultException<ExceptionService>(exception);
            }
        }

        public IEnumerable<VMItemModulo> ObtenerItemsModulo()
        {
            try
            {
                return new NegocioAcceso().ObtenerItemsDeSistema();
            }
            catch (Exception ex)
            {
                ExceptionService exception = new ExceptionService()
                {
                    Mensaje = ex.Message,
                    Operacion = "Items de Modulo."
                };
                throw new FaultException<ExceptionService>(exception);
            }

        }



        public IEnumerable<VMItemModulo> ObtenerItemsRol(int idrol)
        {
            try
            {
                return new NegocioAcceso().ObtenerItemsDeRol(idrol);
            }
            catch (Exception ex)
            {
                ExceptionService exception = new ExceptionService()
                {
                    Mensaje = ex.Message,
                    Operacion = "Items de Rol."
                };
                throw new FaultException<ExceptionService>(exception);
            }
        }


        public void LimpiarItemsRol(int idRol)
        {
            try
            {
                new NegocioAcceso().LimpiarItemsRol(idRol);
            }
            catch (Exception ex)
            {
                ExceptionService exception = new ExceptionService()
                {
                    Mensaje = ex.Message,
                    Operacion = "Reasignar Rol."
                };
                throw new FaultException<ExceptionService>(exception);
            }
        }

        public void AsignarItemRol(int idRol, int idItem)
        {
            try
            {
                new NegocioAcceso().AsignarItemRol(idRol, idItem );
            }
            catch (Exception ex)
            {
                ExceptionService exception = new ExceptionService()
                {
                    Mensaje = ex.Message,
                    Operacion = "Asignar item a rol."
                };
                throw new FaultException<ExceptionService>(exception);
            }
        }

        public void AsignarPermisos(int usuarioRol, bool write, bool delete)
        {
            try
            {
                new NegocioAcceso().AsignarPermisos(usuarioRol,write, delete);
            }
            catch (Exception ex)
            {
                ExceptionService exception = new ExceptionService()
                {
                    Mensaje = ex.Message,
                    Operacion = "Asignar permisos de acceso."
                };
                throw new FaultException<ExceptionService>(exception);
            }
        }

        public void AsignarPermisosTool(int idUsuarioPermisos, int idTool, bool permitir)
        {
            try
            {
                new NegocioAcceso().AsignarPermisosTool(idUsuarioPermisos,idTool,permitir);
            }
            catch (Exception ex)
            {
                ExceptionService exception = new ExceptionService()
                {
                    Mensaje = ex.Message,
                    Operacion = "Asignar permisos de acceso Herramienta."
                };
                throw new FaultException<ExceptionService>(exception);
            }
        }

        public void EliminarItemRol(int idRol, int idItem)
        {
            try
            {
                new NegocioAcceso().EliminarItemRol(idRol, idItem);
            }
            catch (Exception ex)
            {
                ExceptionService exception = new ExceptionService()
                {
                    Mensaje = ex.Message,
                    Operacion = "Eliminar asignacion item a rol."
                };
                throw new FaultException<ExceptionService>(exception);
            }
        }

        public void AsignarRolUsuario(int  idRol, string usuario)
        {
            try
            {//por ahora todos todas las asignaciones son a mexico
                new NegocioUsuario().AsignarRolUsuario(idRol, usuario,1);
            }            
            catch (Exception ex)
            {
                ExceptionService exception = new ExceptionService()
                {
                    Mensaje = ex.Message,
                    Operacion = "Asignar rol a usuario."
                };
                throw new FaultException<ExceptionService>(exception);
            }
        }


        public void EliminarRolUsuario(int idRol, string usuario )
        {
            try
            {
                new NegocioUsuario().EliminarRolUsuario(idRol, usuario,1);
            }
            catch (Exception ex)
            {//por ahora todos todas las asignaciones son a mexico
                ExceptionService exception = new ExceptionService()
                {
                    Mensaje = ex.Message,
                    Operacion = "Eliminar asignación de rol a uaurio."
                };
                throw new FaultException<ExceptionService>(exception);
            }
        }

        public IEnumerable<VMPais> ObtenerCatalogoPaises()
        {
            return new NegocioPais().ObtenerCatalogoPaises();
        }

        public IEnumerable<VMSistema> ObtenerCatalogoSistemas()
        {
            try
            {
                return new NegocioModulosAcceso().ObtenerCatalogoSistemaApp();
            }
            catch (Exception ex)
            {
                ExceptionService exception = new ExceptionService()
                {
                    Mensaje = new Tools.Util().ObtenerMsjExcepcion(ex),
                    Operacion = "Catálogo de Sistemas."
                };
                throw new FaultException<ExceptionService>(exception);
            }
        }

        public VMSistema ObtenerInfoSistemas(int idSistema)
        {
            try
            {
                return new NegocioModulosAcceso().ObtenerInfoSistemaApp(idSistema);
            }
            catch (Exception ex)
            {
                ExceptionService exception = new ExceptionService()
                {
                    Mensaje = new Tools.Util().ObtenerMsjExcepcion(ex),
                    Operacion = "Información de Sistemas."
                };
                throw new FaultException<ExceptionService>(exception);
            }
        }

        public VMSistema RegistrarSistema(string nombre, string logo, string urlhome, bool sistemaEmbebido, bool activo)
        {
            return new NegocioModulosAcceso()
                .RegistrarSistema(nombre, logo, urlhome, sistemaEmbebido, activo);            
        }


        public void EditarSistema(int idSistema, string nombre, string logo, string urlhome, bool sistemaEmbebido, bool activo)
        {
            new NegocioModulosAcceso().EditarSistema(idSistema, nombre, logo, urlhome, sistemaEmbebido, activo);            
        }


        public VMModulo RegistrarModuloSistemaApp(string nombre,
            int idSistema, string urlIcono, string urlDestino, string dbConexion, bool activo)
        {
            return new NegocioModulosAcceso()
                .RegistrarModuloSistemaApp( nombre,
             idSistema,  urlIcono,  urlDestino,  dbConexion,  activo);       
        }


        public void EditarModuloSistemaApp(int idModulo, string nombre,
            int idSistema, string urlIcono, string urlDestino, string dbConexion, bool activo)
        {
            new NegocioModulosAcceso()
                .EditarModuloSistemaApp(idModulo,nombre,
             idSistema, urlIcono, urlDestino, dbConexion, activo); 
        }

        public List<VMModulo> ObtenerModulosSistemaApp(int idSistema,bool? activo)
        {

            return new NegocioModulosAcceso()
                .ObtenerModulosSistemaApp(idSistema,activo); 
        }

        public VMModulo ObtenerInfoModuloSistemaApp(int idModulo)
        {
            return new NegocioModulosAcceso()
                .ObtenerInfoModulosSistemaApp(idModulo);
        }

        public VMItemModulo RegistrarPaginaModulo(string nombre,
            int idModulo, string urlIcono, string urlDestino, int idItemPadre, int orden, bool activo)
        {
            try
            {
            return new NegocioModulosAcceso().RegistrarItemModulo( nombre,
             idModulo,  urlIcono,  urlDestino,  idItemPadre,  orden,  activo);
            }
            catch (Exception ex)
            {
                throw new FaultException<ExceptionService>(new ExceptionService()
                {
                    Mensaje = ex.Message,
                    ErrorCode = "1"
                });

            }
        }

        public void EditarPaginaModulo(int idPagina,string nombre,
            int idModulo, string urlIcono, string urlDestino, int idItemPadre, int orden, bool activo)
        {
            try
            {
                new NegocioModulosAcceso().EditarItemModulo(idPagina, nombre,
                idModulo, urlIcono, urlDestino, idItemPadre, orden, activo);
            }
            catch(Exception ex)
            {
                throw new FaultException<ExceptionService>(new ExceptionService()
                {
                    Mensaje = ex.Message,
                    ErrorCode = "1"
                });

            }
        }

        //public VMSistema RegistrarModulo(int idSistema,string nombre, string urlIcono,
        //    string urlDestino, string dbCadConexion ,bool estatus )
        //{
        //    return new NegocioModulosAcceso()
        //        .RegistrarSistema( nombre,  logo,  urlhome,  sistemaEmbebido,  estatus);            
        //}

        #endregion

        #region ServiceAccesos

        public string IniciarSesion(string usuario, string llave, string ip, string sistema, bool cerrarSesiones=false)
        {
            try
            {
                return new NegocioSistema().IniciarSesion(usuario, llave, ip, sistema, cerrarSesiones);
            }
            catch (Exception ex)
            {
                ExceptionService exception = new ExceptionService()
                {
                    Mensaje = ex.Message,
                    Operacion = "Inicio de sesión.",
                    ErrorCode = ex.Data["code"].ToString()
                };
                throw new FaultException<ExceptionService>(exception);
            }
        }

        public IEnumerable<VMItemModulo> ObtenerItemsUsuario(string usuario)
        {
            try
            {
                return new NegocioSistema().ObtenerItemsUsuario(usuario);
            }
            catch (Exception ex)
            {
                ExceptionService exception = new ExceptionService()
                {
                    Mensaje = ex.Message,
                    Operacion = "Obtener accesos."
                };
                throw new FaultException<ExceptionService>(exception);
            }

        }

        public void CerrarSesion(string usuario)
        {
            try
            {
                new NegocioSistema().CerrarSesion(usuario);
            }
            catch (Exception ex)
            {
                ExceptionService exception = new ExceptionService()
                {
                    Mensaje = ex.Message,
                    Operacion = "Cerrar sesión."
                };
                throw new FaultException<ExceptionService>(exception);
            }
        }

        public IEnumerable<VMSistema> ObtenerSistemasUsuario(string usuario)
        {
            try
            {
                return new NegocioSistema().ObtenerSistemasUsuario(usuario);
            }
            catch (Exception ex)
            {
                ExceptionService exception = new ExceptionService()
                {
                    Mensaje = ex.Message,
                    Operacion = "Obtener sistemas de acceso."
                };
                throw new FaultException<ExceptionService>(exception);
            }
        }

        public IEnumerable<VMPermisoItem> ObtenerPermisosItemsUsuario(string usuario, int? idSistema,int? idRol)
        {
            try
            {
                return new NegocioSistema().ObtenerPermisosItemsUsuario(usuario, idSistema,idRol);
            }
            catch (Exception ex)
            {
                ExceptionService exception = new ExceptionService()
                {
                    Mensaje = ex.Message,
                    Operacion = "Obtener permisos de acceso."
                };
                throw new FaultException<ExceptionService>(exception);
            }
        }

        public IEnumerable<VMToolItem> ObtenerPermisosToolsUsuario(int idUsuarioPermisos)
        {
            try
            {
                return new NegocioSistema().ObtenerPermisosToolsUsuario(idUsuarioPermisos);
            }
            catch (Exception ex)
            {
                ExceptionService exception = new ExceptionService()
                {
                    Mensaje = ex.Message,
                    Operacion = "Obtener permisos de acceso a herramientas."
                };
                throw new FaultException<ExceptionService>(exception);
            }
        }

        public IEnumerable<VMRol> ObtenerRolesDeUsuario(string usuario, int? idSistema)
        {
            try
            {
                return new NegocioUsuario().ObtenerRolesUsuario(usuario, idSistema);
            }
            catch (Exception ex)
            {
                ExceptionService exception = new ExceptionService()
                {
                    Mensaje = ex.Message,
                    Operacion = "Roles de usuario."
                };
                throw new FaultException<ExceptionService>(exception);
            }
        }
        
        public IEnumerable<VMItemModulo> ObtenerItemsDeRol(int idrol)
        {
            try
            {
                return new NegocioAcceso().ObtenerItemsDeRol(idrol);
            }
            catch (Exception ex)
            {
                ExceptionService exception = new ExceptionService()
                {
                    Mensaje = ex.Message,
                    Operacion = "Items de Rol."
                };
                throw new FaultException<ExceptionService>(exception);
            }
        }

        //public IEnumerable<VMRol> IServiceAcceso. ObtenerRolesUsuario(string usuario)
        //{
        //    try
        //    {
        //        return new NegocioUsuario().ObtenerRolesUsuario(usuario);
        //    }
        //    catch (Exception ex)
        //    {
        //        ExceptionService exception = new ExceptionService()
        //        {
        //            Mensaje = ex.Message,
        //            Operacion = "Roles de usuario."
        //        };
        //        throw new FaultException<ExceptionService>(exception);
        //    }
        //}

        public void ModificarPasswordUsuario(string idUsuario, string passAnterior, string passNueva)
        {
            try
            {
                new NegocioUsuario().ModificarPassUsuario(idUsuario,passAnterior,passNueva);
            }
            catch (Exception ex)
            {
                ExceptionService exception = new ExceptionService()
                {
                    Mensaje = ex.Message,
                    Operacion = "Actualización de contraseña."
                };
                throw new FaultException<ExceptionService>(exception);
            }
        }

        #endregion



        

        
    }
}
