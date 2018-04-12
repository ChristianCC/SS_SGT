using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ViewModel.Catalogo._Pais
{
    [DataContract]
    public class VMPais
    {
        private int idPais;
        private string nombre;
        private bool activo;

        [DataMember]
        public int IdPais
        {
            get { return idPais; }
            set { idPais = value; }
        }

        [DataMember]
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        [DataMember]
        public bool Activo
        {
            get { return activo; }
            set { activo = value; }
        }
    }
}
