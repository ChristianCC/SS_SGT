using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ViewModel.Catalogo._Error
{
    [DataContract]
    public class VMError
    {
        private int idErrorBitacora;
        private int idBitacora;//id de bitacora de acceso
        private string explorador;
        private string versionSistema;
        private string sistema;
        private string errorGenerado;
        private string stackTrace;
        private string targetSite;
        private DateTime fechaError;

        [DataMember]
        public int IdErrorBitacora
        {
            get { return idErrorBitacora; }
            set { idErrorBitacora = value; }
        }

        [DataMember]
        public int IdBitacora
        {
            get { return idBitacora; }
            set { idBitacora = value; }
        }

        [DataMember]
        public string Explorador
        {
            get { return explorador; }
            set { explorador = value; }
        }

        [DataMember]
        public string VersionSistema
        {
            get { return versionSistema; }
            set { versionSistema = value; }
        }

        [DataMember]
        public string Sistema
        {
            get { return sistema; }
            set { sistema = value; }
        }

        [DataMember]
        public string ErrorGenerado
        {
            get { return errorGenerado; }
            set { errorGenerado = value; }
        }

        [DataMember]
        public string StackTrace
        {
            get { return stackTrace; }
            set { stackTrace = value; }
        }

        [DataMember]
        public string TargetSite
        {
            get { return targetSite; }
            set { targetSite = value; }
        }

        [DataMember]
        public DateTime FechaError
        {
            get { return fechaError; }
            set { fechaError = value; }
        }




    }
}
