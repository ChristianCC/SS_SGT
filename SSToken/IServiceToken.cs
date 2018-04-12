using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using ViewModel;

namespace SSToken
{
    
    [ServiceContract]
    public interface IServiceToken
    {
        [OperationContract]
        [FaultContract(typeof(ExceptionService))]
        RespuestaSesion ValidarToken(string token);

        [OperationContract]
        [FaultContract(typeof(ExceptionService))]
        RespuestaSesion ValidarAcceso(string url, string usuario);

        [OperationContract]
        [FaultContract(typeof(ExceptionService))]
        void CerrarSesion(string usuario);

    }
}
