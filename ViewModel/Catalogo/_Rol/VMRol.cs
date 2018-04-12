using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ViewModel.Catalogo._Rol
{
    [DataContract]
    public class VMRol
    {
        private int idRol;
        private int idPais;
        private string nombre;
        private bool activo;
        private string pais;

        private string descripcion;

        [DataMember]
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        [DataMember]
        public int IdRol
        {
            get { return idRol; }
            set { idRol = value; }
        }

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

        [DataMember]
        public string Pais
        {
            get { return pais; }
            set { pais = value; }
        }
    }
}
