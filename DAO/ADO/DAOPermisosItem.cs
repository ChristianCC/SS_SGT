using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace DAO.ADO
{
    public class DAOPermisosItem : IDAOPermisosItem
    {
        string conexion;

        public DAOPermisosItem()
        {
            conexion = Conexion.DBConexion.conexiones.conn_SERV.ToString();
        }

        public RespuestaBD ObtenerItemsUsuarioRol(string usuario, int? idSistema, int? idRol)
        {
            SqlTools helpSql = new SqlTools(conexion);
            RespuestaBD resp = helpSql.ExecuteSP("sps_MDB_seg_obtener_permisos_item",
                    new SqlParameter[]{       
                        new SqlParameter("@pc_usuario",usuario),
                        new SqlParameter("@pi_id_sistema",idSistema),
                        new SqlParameter("@pi_id_rol",idRol)
                });

            if (resp.EXISTE_ERROR)
            {
                throw new Exception(resp.MENSAJE);
            }
            else
            {
                return resp;
            }
        }

        public RespuestaBD AsignarPermisos(int usuarioRol, bool write, bool delete)
        {
            SqlTools helpSql = new SqlTools(conexion);
            RespuestaBD resp = helpSql.ExecuteSP("sps_MDB_seg_edit_permisos_item",
                    new SqlParameter[]{       
                        new SqlParameter("@pi_id_usuario_permisos",usuarioRol),
                        new SqlParameter("@pl_delete",delete),
                        new SqlParameter("@pl_write",write)
                });

            if (resp.EXISTE_ERROR)
            {
                throw new Exception(resp.MENSAJE);
            }
            else
            {
                return resp;
            }
        }
    }
}
