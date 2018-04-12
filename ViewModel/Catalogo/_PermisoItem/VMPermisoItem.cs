using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ViewModel.Catalogo._PermisoItem
{
    [DataContract]
    public class VMPermisoItem
    {
        private int idUsuarioPermisos;        
        private int idItemModulo;
        private string nombre;
        private bool write;
        private bool delete;
        private int idRol;
        private string nombreRol;

        [DataMember]
        public int IdRol
        {
            get { return idRol; }
            set { idRol = value; }
        }

        [DataMember]
        public string NombreRol
        {
            get { return nombreRol; }
            set { nombreRol = value; }
        }

        [DataMember]
        public int IdUsuarioPermisos
        {
            get { return idUsuarioPermisos; }
            set { idUsuarioPermisos = value; }
        }


        [DataMember]
        public int IdItemModulo
        {
            get { return idItemModulo; }
            set { idItemModulo = value; }
        }

        [DataMember]
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        [DataMember]
        public bool Write
        {
            get { return write; }
            set { write = value; }
        }

        [DataMember]
        public bool Delete
        {
            get { return delete; }
            set { delete = value; }
        }


    }
}
