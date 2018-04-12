using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;

namespace ViewModel
{
    [DataContract]
    public class RespuestaSesion
    {
        private string code;

        [DataMember]
        public string Code
        {
            get { return code; }
            set { code = value; }
        }


        private bool activa;

        [DataMember]
        public bool Activa
        {
            get { return activa; }
            set { activa = value; }
        }
        private string mensaje;

        [DataMember]
        public string Mensaje
        {
            get { return mensaje; }
            set { mensaje = value; }
        }



    }
}
