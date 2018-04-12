using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ViewModel.Catalogo._TipoTransaccion
{
    [DataContract]
    public class VMTipoTransaccion
    {
        private int idTipoTransaccion;
        private string descripcion;
        private bool estatus;

        [DataMember]
        public int IdTipoTransaccion
        {
            get { return idTipoTransaccion; }
            set { idTipoTransaccion = value; }
        }

        [DataMember]
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        [DataMember]
        public bool Estatus
        {
            get { return estatus; }
            set { estatus = value; }
        }
    }
}
