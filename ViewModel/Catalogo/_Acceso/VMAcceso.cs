using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace ViewModel.Catalogo._Acceso
{

    [DataContract]
    public class VMAcceso
    {
        private int idBitacora;
        private string usuarioAccesa;
        private string ipUsuario;
        private DateTime? fechaInicioSesion;
        private DateTime? fechaFinSesion;
        private string sistema;

        [DataMember]
        public int IdBitacora
        {
            get { return idBitacora; }
            set { idBitacora = value; }
        }

        [DataMember]
        public string UsuarioAccesa
        {
            get { return usuarioAccesa; }
            set { usuarioAccesa = value; }
        }

        [DataMember]
        public string IpUsuario
        {
            get { return ipUsuario; }
            set { ipUsuario = value; }
        }

        [DataMember]
        public DateTime? FechaInicioSesion
        {
            get { return fechaInicioSesion; }
            set { fechaInicioSesion = value; }
        }

        [DataMember]
        public DateTime? FechaFinSesion
        {
            get { return fechaFinSesion; }
            set { fechaFinSesion = value; }
        }

        [DataMember]
        public string Sistema
        {
            get { return sistema; }
            set { sistema = value; }
        }



    }
}
