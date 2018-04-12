using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ViewModel.Catalogo._Sistema
{
    [DataContract]
    public class VMSistema
    {
        private int idSistema;
        private string nombreSistema;
        private string logo;
        private string urlHome;
        private bool embebido;
        private bool activo;

        [DataMember]
        public bool Activo
        {
            get { return activo; }
            set { activo = value; }
        }



        [DataMember]
        public bool Embebido
        {
            get { return embebido; }
            set { embebido = value; }
        }

        [DataMember]
        public string UrlHome
        {
            get { return urlHome; }
            set { urlHome = value; }
        }

        [DataMember]
        public int IdSistema
        {
            get { return idSistema; }
            set { idSistema = value; }
        }

        [DataMember]
        public string NombreSistema
        {
            get { return nombreSistema; }
            set { nombreSistema = value; }
        }

        [DataMember]
        public string Logo
        {
            get { return logo; }
            set { logo = value; }
        }
    }
}
