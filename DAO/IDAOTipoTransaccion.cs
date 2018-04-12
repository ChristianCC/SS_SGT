using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface IDAOTipoTransaccion
    {
        RespuestaBD ObtenerTipoTransaccion(int? id, int? status);
        RespuestaBD RegistrarTipoTransaccion(bool status, string descripcion);
        RespuestaBD EditarTipoTransaccion(int id, bool status, string descripcion);
        RespuestaBD ObtenerListaTipoTransaccion();
    }
}
