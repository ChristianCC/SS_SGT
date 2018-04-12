using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;
using ViewModel;

using ViewModel.Catalogo._Usuario;
using ViewModel.Catalogo._ItemModulo;
using ViewModel.Catalogo._Sistema;
using ViewModel.Catalogo._PermisoItem;
using ViewModel.Catalogo._ToolItem;
using ViewModel.Catalogo._Rol;


namespace SSToken
{
    [ServiceContract]
    public interface IServiceAcceso
    {
        [OperationContract]
        [FaultContract(typeof(ExceptionService))]
        IEnumerable<VMItemModulo> ObtenerItemsUsuario(string usuario);

        [OperationContract]
        [FaultContract(typeof(ExceptionService))]
        string IniciarSesion(string usuario, string llave, string ip, string sistema, bool cerrarSesiones=false);

        [OperationContract]
        [FaultContract(typeof(ExceptionService))]
        void CerrarSesion(string usuario);

        [OperationContract]
        [FaultContract(typeof(ExceptionService))]
        IEnumerable<VMSistema> ObtenerSistemasUsuario(string usuario);

        [OperationContract]
        [FaultContract(typeof(ExceptionService))]
        IEnumerable<VMPermisoItem> ObtenerPermisosItemsUsuario(string usuario, int? idSistema, int? idRol);

        [OperationContract]
        [FaultContract(typeof(ExceptionService))]
        IEnumerable<VMToolItem> ObtenerPermisosToolsUsuario(int idUsuarioPermisos);

        //[OperationContract]
        //[FaultContract(typeof(ExceptionService))]
        //bool ExisteSesion(int idUsuarioPermisos);

        [OperationContract]
        [FaultContract(typeof(ExceptionService))]
        IEnumerable<VMRol> ObtenerRolesDeUsuario(string usuario, int? idSistema);
        
        [OperationContract]
        [FaultContract(typeof(ExceptionService))]
        IEnumerable<VMItemModulo> ObtenerItemsDeRol(int idRol);

        [OperationContract]
        [FaultContract(typeof(ExceptionService))]
        void ModificarPasswordUsuario(string idUsuario, string passAnterior, string passNueva);
    }
}
