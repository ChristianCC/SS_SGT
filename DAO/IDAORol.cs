using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface IDAORol
    {
        RespuestaBD ObtenerRoles(int? idSistema= null,bool? activo = null);

        RespuestaBD ObtenerRolesUsuario(string usuario, int? idSistema);

        RespuestaBD RegistrarEditarRol(int idRol,string descripcion,string nombre,int idPais,bool activo);

        RespuestaBD LimpiarAsignacionRol(int idRol);

        RespuestaBD RegistrarEditarRolItem(int idRol, int idItem);

        RespuestaBD EliminarRolItem(int idRol, int idItem);

        RespuestaBD ObtenerItemsRol(int idRol);

    }
}
