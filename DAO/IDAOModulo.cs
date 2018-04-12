using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface IDAOModulo
    {
        RespuestaBD ObtenerListaModulosSistemasApp(int? status);

        RespuestaBD RegistrarModuloApp(string nombre,
            int idSistema, string urlIcono, string urlDestino, string dbConexion, bool activo);

        RespuestaBD EditarModuloApp(int idModulo,string nombre,
            int idSistema, string urlIcono, string urlDestino, string dbConexion, bool activo);

        RespuestaBD ObtenerModulosSistemaApp(int idSistema,bool? itemsActivo);

        RespuestaBD ObtenerInfoModulosSistemaApp(int idModulo);
    }
}
