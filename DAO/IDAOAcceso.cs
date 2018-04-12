using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface IDAOAcceso
    {
        RespuestaBD ObtenerBitacoraAccesos(string idUsuario, string ipUsuario, DateTime? fechaInicio, DateTime? fechaFin);
    }
}
