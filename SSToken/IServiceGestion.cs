using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ServiceModel;
using ViewModel;
using ViewModel.Catalogo;
using ViewModel.Catalogo._ItemModulo;
using ViewModel.Catalogo._Pais;
using ViewModel.Catalogo._Rol;
using ViewModel.Catalogo._Sistema;
using ViewModel.Catalogo._Usuario;
using ViewModel.Catalogo._Modulo;



namespace SSToken
{
    [ServiceContract]
    public interface IServiceGestion
    {
        #region Catalogo usuario
        [OperationContract]
        [FaultContract(typeof(ExceptionService))]
        VMUsuario RegistrarNuevoUsuario(string nombre, string apellidoMaterno, string apellidoPaterno, string celular, string correo,
            string extension, int idEstatus, string password, string usuario_sistema);

        [OperationContract]
        [FaultContract(typeof(ExceptionService))]
        void EditarUsuario(VMUsuario usuario);

        [OperationContract]
        [FaultContract(typeof(ExceptionService))]
        IEnumerable<VMUsuario> ObtenerCatalogoUsuarios();


        [OperationContract]
        [FaultContract(typeof(ExceptionService))]
        void ResetPassUsuario(string usuario_sistema);

        [OperationContract]
        [FaultContract(typeof(ExceptionService))]
        VMUsuario ObtenerInfoUsuario(string usuario_sistema);

        #endregion

        #region Catalogo roles

        [OperationContract]
        [FaultContract(typeof(ExceptionService))]
        IEnumerable<VMRol> ObtenerRoles(int idSistema);

        [OperationContract]
        [FaultContract(typeof(ExceptionService))]
        IEnumerable<VMRol> ObtenerRolesUsuario(string usuario,int? idSistema);

        [OperationContract]
        [FaultContract(typeof(ExceptionService))]
        VMRol RegistrarNuevoRol(string nombre, string descripcion, int idPais);

        [OperationContract]
        [FaultContract(typeof(ExceptionService))]
        void AsignarRolUsuario(int idRol, string usuario);

        [OperationContract]
        [FaultContract(typeof(ExceptionService))]
        void EliminarRolUsuario(int idRol, string usuario);

        #endregion

        #region Catalogo ItemsModulo

        [OperationContract]
        [FaultContract(typeof(ExceptionService))]
        IEnumerable<VMItemModulo> ObtenerItemsModulo();

        [OperationContract]
        [FaultContract(typeof(ExceptionService))]
        void LimpiarItemsRol(int idRol);

        [OperationContract]
        [FaultContract(typeof(ExceptionService))]
        void AsignarItemRol(int idRol, int idItem);

        [OperationContract]
        [FaultContract(typeof(ExceptionService))]
        void AsignarPermisos(int usuarioRol, bool write, bool delete);

        [OperationContract]
        [FaultContract(typeof(ExceptionService))]
        void AsignarPermisosTool(int idUsuarioPermisos, int  idTool, bool permitir);

        [OperationContract]
        [FaultContract(typeof(ExceptionService))]
        IEnumerable<VMItemModulo> ObtenerItemsRol(int idRol);

        [OperationContract]
        [FaultContract(typeof(ExceptionService))]
        void EliminarItemRol(int idRol, int idItem);

        #endregion

        #region Catalogo Sistemas

        [OperationContract]
        [FaultContract(typeof(ExceptionService))]
        VMSistema RegistrarSistema(string nombre, string logo, string urlhome, bool sistemaEmbebido ,bool activo);

        [OperationContract]
        [FaultContract(typeof(ExceptionService))]
        void EditarSistema(int idSistema,string nombre, string logo, string urlhome, bool sistemaEmbebido, bool activo);

        [OperationContract]
        [FaultContract(typeof(ExceptionService))]
        IEnumerable<VMSistema> ObtenerCatalogoSistemas();

        [OperationContract]
        [FaultContract(typeof(ExceptionService))]
        VMSistema ObtenerInfoSistemas(int idSistema);

        #endregion

        #region Modulos Sistema

        [OperationContract]
        [FaultContract(typeof(ExceptionService))]
        List<VMModulo> ObtenerModulosSistemaApp(int idSistema,bool? activo);

        #endregion

        #region Catalogo Modulos

        [OperationContract]
        [FaultContract(typeof(ExceptionService))]
        VMModulo RegistrarModuloSistemaApp(string nombre,
            int idSistema, string urlIcono, string urlDestino, string dbConexion, bool activo);

        [OperationContract]
        [FaultContract(typeof(ExceptionService))]
        void EditarModuloSistemaApp(int idModulo,string nombre,
            int idSistema, string urlIcono, string urlDestino, string dbConexion, bool activo);
        [OperationContract]
        [FaultContract(typeof(ExceptionService))]
        VMModulo ObtenerInfoModuloSistemaApp(int idModulo);


        #endregion

        #region PaginasModulo

        [OperationContract]
        [FaultContract(typeof(ExceptionService))]
        VMItemModulo RegistrarPaginaModulo(string nombre,
            int idModulo, string urlIcono, string urlDestino, int idItemPadre, int orden, bool activo);

        [OperationContract]
        [FaultContract(typeof(ExceptionService))]
        void EditarPaginaModulo(int idPagina, string nombre,
            int idModulo, string urlIcono, string urlDestino, int idItemPadre, int orden, bool activo);

        #endregion

        #region Paises

        [OperationContract]
        IEnumerable<VMPais> ObtenerCatalogoPaises();

        #endregion

    }
}
