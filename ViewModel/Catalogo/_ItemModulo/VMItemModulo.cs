using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ViewModel.Catalogo._ItemModulo
{
    [DataContract]
    public class VMItemModulo
    {
        private int idItemModulo;
        private string descripcion;
        private string url;
        private string urlIcono;
        private int orden;
        private int idItemPadre;
        private int idModulo;
        private string modulo;
        private int idSistema;
        private string sistema;
        private bool activo;
        private string urlIconoModulo;

        [DataMember]
        public string UrlIconoModulo
        {
            get { return urlIconoModulo; }
            set { urlIconoModulo = value; }
        }

        [DataMember]
        public bool Activo
        {
            get { return activo; }
            set { activo = value; }
        }

        [DataMember]
        public int IdItemModulo
        {
            get { return idItemModulo; }
            set { idItemModulo = value; }
        }

        [DataMember]
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        [DataMember]
        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        [DataMember]
        public string UrlIcono
        {
            get { return urlIcono; }
            set { urlIcono = value; }
        }

        [DataMember]
        public int Orden
        {
            get { return orden; }
            set { orden = value; }
        }

        [DataMember]
        public int IdItemPadre
        {
            get { return idItemPadre; }
            set { idItemPadre = value; }
        }

        [DataMember]
        public int IdModulo
        {
            get { return idModulo; }
            set { idModulo = value; }
        }

        [DataMember]
        public string Modulo
        {
            get { return modulo; }
            set { modulo = value; }
        }

        [DataMember]
        public int IdSistema
        {
            get { return idSistema; }
            set { idSistema = value; }
        }

        [DataMember]
        public string Sistema
        {
            get { return sistema; }
            set { sistema = value; }
        }
    }
}
