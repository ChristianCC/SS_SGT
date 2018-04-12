using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface IDAOUsuario
    {
        RespuestaBD ObtenerListaUsuarios(int? status,string usuario = null);

        RespuestaBD RegistrarUsuario(string usuario_sistema, string password, string nombre, string apellido_paterno,
           string apellido_materno, string correo, string celular, string extension);

        RespuestaBD EditarUsuario(string usuario_sistema, string password, string nombre, string apellido_paterno,
           string apellido_materno, string correo, string celular, string extension, DateTime? fechaDeVencimiento, int idEstatus);

        RespuestaBD RegistrarEditarRolUsuario(int idRol,string usuario_sistema,int idPais, bool eliminar);

        RespuestaBD ObtenerItemsUsuario(string usuario_sistema);

        RespuestaBD EditarPassword(string usuario_sistema, string password, string passwordAnterior = "");

        RespuestaBD ObtenerInfoUsuario(string usuario);
        

    }
}
