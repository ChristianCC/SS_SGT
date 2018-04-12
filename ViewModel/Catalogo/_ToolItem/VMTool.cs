using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;


namespace ViewModel.Catalogo._ToolItem
{
    [DataContract]
    public class VMTool
    {
        private int idTool;
        private int idItemModulo;
        private string nombre;
        private bool activo;
        

        [DataMember]
        public int IdTool
        {
            get { return idTool; }
            set { idTool = value; }
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
        public bool Activo
        {
            get { return activo; }
            set { activo = value; }
        }


    }
}
