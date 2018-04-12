using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface IDAOItemModulo
    {
        RespuestaBD ObtenerItemsSistema(int? sistema = null);

        RespuestaBD RegistrarItemModulo(string nombre,
            int idModulo, string urlIcono, string urlDestino,int idItemPadre,int orden, bool activo);

        RespuestaBD EditarItemModulo(int idItem,string nombre,
            int idModulo, string urlIcono, string urlDestino, int idItemPadre, int orden, bool activo);

        RespuestaBD ObtenerInfoItemModulo(int idItem);
    }
}
