using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace Entidad.Common
{
    [DataContract]
    public class ExceptionService
    {
        private string operacion;
        private string mensaje;
        private string errorCode;

        [DataMember]
        public string ErrorCode
        {
            get { return errorCode; }
            set { errorCode = value; }
        }

        [DataMember]
        public string Mensaje
        {
            get { return mensaje; }
            set { mensaje = value; }
        }

        [DataMember]
        public string Operacion
        {
            get { return operacion; }
            set { operacion = value; }
        }      
    }
}
