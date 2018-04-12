using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface IDAOSistemaApp
    {
        RespuestaBD ObtenerListaSistemasApp(int? status);

        RespuestaBD ObtenerSistemasApp(int? idSistema);

        RespuestaBD RegistrarSistemaApp(string nombre, string logo, string urlhome, bool sistemaEmbebido, bool estatus);

        RespuestaBD EditarSistemaApp(int idSistemaApp, string nombre, string logo, string urlhome, bool sistemaEmbebido, bool estatus);

    }
}
