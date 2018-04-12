using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ViewModel.Catalogo._TipoApp
{
    [DataContract]
    public class VMTipoApp
    {
        private int idTipoApp;
        private string descripcion;
        private bool activo;

        [DataMember]
        public int IdTipoApp
        {
            get { return idTipoApp; }
            set { idTipoApp = value; }
        }

        [DataMember]
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        [DataMember]
        public bool Activo
        {
            get { return activo; }
            set { activo = value; }
        }



    }
}
