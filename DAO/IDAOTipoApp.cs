using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface IDAOTipoApp
    {
        RespuestaBD ObtenerTiposApp(int? idTipoApp, bool? activo = null);
        RespuestaBD RegistrarEditarTipoApp(int idTipoApp, string descripcion, bool activo);
        RespuestaBD EliminarTipoApp(int idRol, int idItem);
        RespuestaBD ObtenerListaTipoApp();
    }
}
