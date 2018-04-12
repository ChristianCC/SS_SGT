using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ViewModel.Catalogo._Transaccion
{
    [DataContract]
    public class VMTransaccion
    {
        private int idSistema;
        private int idTipoTransaccion;
        private string neusuario;
        private string url;
        private int idTipoApp;
        private string hostname;
        private string ipClient;
        private string mensaje;
        private string dominio;
        private DateTime? fechaInicioProceso;
        private DateTime? fechaFinProceso;
        private DateTime fechaRegistro;
        private int? idAppExt;
        private int? idUsuario;
        private string nombreSistema;
        private string nombreTipoAplicacion;
        private string nombreTipoTransaccion;
        private string tipoAcceso;

        [DataMember]
        public string TipoAcceso
        {
            get { return tipoAcceso; }
            set { tipoAcceso = value; }
        }



        [DataMember]
        public string NombreSistema
        {
            get { return nombreSistema; }
            set { nombreSistema = value; }
        }

        [DataMember]
        public string NombreTipoAplicacion
        {
            get { return nombreTipoAplicacion; }
            set { nombreTipoAplicacion = value; }
        }

        [DataMember]
        public string NombreTipoTransaccion
        {
            get { return nombreTipoTransaccion; }
            set { nombreTipoTransaccion = value; }
        }



        [DataMember]
        public DateTime FechaRegistro
        {
            get { return fechaRegistro; }
            set { fechaRegistro = value; }
        }

        [DataMember]
        public int IdSistema
        {
            get { return idSistema; }
            set { idSistema = value; }
        }

        [DataMember]
        public int IdTipoTransaccion
        {
            get { return idTipoTransaccion; }
            set { idTipoTransaccion = value; }
        }

        [DataMember]
        public string Neusuario
        {
            get { return neusuario; }
            set { neusuario = value; }
        }

        [DataMember]
        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        [DataMember]
        public int IdTipoApp
        {
            get { return idTipoApp; }
            set { idTipoApp = value; }
        }

        [DataMember]
        public string Hostname
        {
            get { return hostname; }
            set { hostname = value; }
        }

        [DataMember]
        public string IpClient
        {
            get { return ipClient; }
            set { ipClient = value; }
        }

        [DataMember]
        public string Mensaje
        {
            get { return mensaje; }
            set { mensaje = value; }
        }

        [DataMember]
        public string Dominio
        {
            get { return dominio; }
            set { dominio = value; }
        }

        [DataMember]
        public DateTime? FechaInicioProceso
        {
            get { return fechaInicioProceso; }
            set { fechaInicioProceso = value; }
        }

        [DataMember]
        public DateTime? FechaFinProceso
        {
            get { return fechaFinProceso; }
            set { fechaFinProceso = value; }
        }

        [DataMember]
        public int? IdAppExt
        {
            get { return idAppExt; }
            set { idAppExt = value; }
        }

        [DataMember]
        public int? IdUsuario
        {
            get { return idUsuario; }
            set { idUsuario = value; }
        }

    }
}
