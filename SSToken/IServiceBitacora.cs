using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using ViewModel;
using ViewModel.Catalogo._TipoApp;
using ViewModel.Catalogo._Transaccion;
using ViewModel.Catalogo._TipoTransaccion;
using ViewModel.Catalogo._Acceso;
using ViewModel.Catalogo._Error;


namespace SSToken
{    
    [ServiceContract]
    public interface IServiceBitacora
    {
        [OperationContract]
        [FaultContract(typeof(ExceptionService))]
        IEnumerable<VMTipoApp> ObtenerTiposApp(bool? activo);

        [OperationContract]
        [FaultContract(typeof(ExceptionService))]
        IEnumerable<VMTipoApp> ObtenerListaTipoApp();

        [OperationContract]
        [FaultContract(typeof(ExceptionService))]
        IEnumerable<VMTransaccion> ObtenerTransacciones(int? idSistema, int? idTipoTransaccion, string host, string ip, string dominio, DateTime? fechaInicio, DateTime? fechaFin);

        [OperationContract]
        [FaultContract(typeof(ExceptionService))]
        void RegistrarTransaccion(int idSistema, int idTipoTransaccion,string tipoAcceso,
            string neUsuario, string url, int idTipoApp, string hostName,
            string ipCliente, string mensaje, string dominio, DateTime? inicioProceso,
            DateTime? finDeProceso, int? idAppExt, int? idUsuario);

        #region Catalogo TipoTransaccion

        [OperationContract]
        [FaultContract(typeof(ExceptionService))]
        VMTipoTransaccion RegistrarTipoTrensaccion(bool status, string descripcion);

        [OperationContract]
        [FaultContract(typeof(ExceptionService))]
        IEnumerable<VMTipoTransaccion> ObtenerCatalogoTipoTransaccion(int? id_tipo_transaccion, int? status);

        [OperationContract]
        [FaultContract(typeof(ExceptionService))]
        void EditarTipoTransaccion(int id_tipo_transaccion, bool status, string descripcion);

        [OperationContract]
        [FaultContract(typeof(ExceptionService))]
        IEnumerable<VMTipoTransaccion> ObtenerListaTipoTransaccion();

        #endregion Catalogo TipoTransaccion

        [OperationContract]
        [FaultContract(typeof(ExceptionService))]
        List<VMAcceso> ObtenerBitacoraAccesos(string idUsuario, string ipUsuario, DateTime? fechaInicio, DateTime? fechaFin);

        [OperationContract]
        [FaultContract(typeof(ExceptionService))]
        List<VMError> ObtenerBitacoraErrores(DateTime? fechaInicio, DateTime? fechaFin);
    }
}
