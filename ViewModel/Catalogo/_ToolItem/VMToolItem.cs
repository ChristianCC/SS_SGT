using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ViewModel.Catalogo._ToolItem
{
    [DataContract]
    public class VMToolItem
    {
        private int idUsuarioPermisos;
        private int idTool;        
        private string nombre;        
        private bool permitir;

        

        [DataMember]
        public int IdTool
        {
            get { return idTool; }
            set { idTool = value; }
        }

        [DataMember]
        public int IdUsuarioPermisos
        {
            get { return idUsuarioPermisos; }
            set { idUsuarioPermisos = value; }
        }

        [DataMember]
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        [DataMember]
        public bool Permitir
        {
            get { return permitir; }
            set { permitir = value; }
        }
        
    }
}
