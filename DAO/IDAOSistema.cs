using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface IDAOSistema
    {
        RespuestaBD IniciarSesion(string usuario, string llave, string ip, string sistema, bool cerrarSesiones);

        RespuestaBD ObtenerLlaveUsuario(string usuario);

        RespuestaBD CerrarSesion(string usuario);

        RespuestaBD ValidarToken(string token);

        RespuestaBD RegistrarToken(string token, DateTime fechaCaduca, string usuario);

        RespuestaBD ValidarAcceso(string url, string usuario);

        

    }
}
