using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using ViewModel.Catalogo._ItemModulo;

namespace ViewModel.Catalogo._Modulo
{
    [DataContract]
    public class VMModulo
    {
        private int idModulo;
        private string nombre;
        private string urlIcono;
        private string urlDestino;
        private int idSistema;
        private bool activo;
        private string dbConexion;
        private List<VMItemModulo> items;

        [DataMember]
        public int IdModulo
        {
            get { return idModulo; }
            set { idModulo = value; }
        }

        [DataMember]
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        [DataMember]
        public string UrlIcono
        {
            get { return urlIcono; }
            set { urlIcono = value; }
        }

        [DataMember]
        public string UrlDestino
        {
            get { return urlDestino; }
            set { urlDestino = value; }
        }

        [DataMember]
        public int IdSistema
        {
            get { return idSistema; }
            set { idSistema = value; }
        }

        [DataMember]
        public bool Activo
        {
            get { return activo; }
            set { activo = value; }
        }

        [DataMember]
        public string DbConexion
        {
            get { return dbConexion; }
            set { dbConexion = value; }
        }

        
        [DataMember]
        public List<VMItemModulo> Items
        {
            get { return items; }
            set { items = value; }
        }

    }
}
