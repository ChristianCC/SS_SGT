using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ViewModel.Catalogo._Usuario
{
    [DataContract]
    public class VMUsuario
    {
        private string usuario_sistema;
        private string password;
        private string nombre;
        private string apellido_paterno;
        private string apellido_materno;
        private string correo;
        private string extension;
        private string celular;
        private DateTime? fechaDeRegistro;
        private DateTime? fechaDeVencimiento;
        private string estatus;
        private int idEstatus;

        [DataMember]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        [DataMember]
        public int IdEstatus
        {
            get { return idEstatus; }
            set { idEstatus = value; }
        }

        [DataMember]
        public string Usuario_sistema
        {
            get { return usuario_sistema; }
            set { usuario_sistema = value; }
        }

        [DataMember]
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        [DataMember]
        public string Apellido_paterno
        {
            get { return apellido_paterno; }
            set { apellido_paterno = value; }
        }

        [DataMember]
        public string Apellido_materno
        {
            get { return apellido_materno; }
            set { apellido_materno = value; }
        }

        [DataMember]
        public string Correo
        {
            get { return correo; }
            set { correo = value; }
        }

        [DataMember]
        public string Celular
        {
            get { return celular; }
            set { celular = value; }
        }

        [DataMember]
        public string Extension
        {
            get { return extension; }
            set { extension = value; }
        }

        [DataMember]
        public DateTime? FechaDeRegistro
        {
            get { return fechaDeRegistro; }
            set { fechaDeRegistro = value; }
        }

        [DataMember]
        public DateTime? FechaDeVencimiento
        {
            get { return fechaDeVencimiento; }
            set { fechaDeVencimiento = value; }
        }

        [DataMember]
        public string Estatus
        {
            get { return estatus; }
            set { estatus = value; }
        }
    }
}
