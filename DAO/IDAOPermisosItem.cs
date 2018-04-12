using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface IDAOPermisosItem
    {
        RespuestaBD ObtenerItemsUsuarioRol(string usuario, int? idSistema, int? idRol);
        RespuestaBD AsignarPermisos(int usuarioRol,bool write,bool delete);
    }
}
