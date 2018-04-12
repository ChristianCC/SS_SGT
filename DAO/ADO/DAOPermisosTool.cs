using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;


namespace DAO.ADO
{
    public class DAOPermisosTool  : IDAOPermisosTool
    {
        string conexion;

        public DAOPermisosTool()
        {
            conexion = Conexion.DBConexion.conexiones.conn_SERV.ToString();
        }


        public RespuestaBD ObtenerToolsUsuarioRol(int idUsuarioPermisos)
        {
            SqlTools helpSql = new SqlTools(conexion);
            RespuestaBD resp = helpSql.ExecuteSP("sps_MDB_seg_obtener_tools_item",
                    new SqlParameter[]{       
                        new SqlParameter("@pi_id_usuario_permisos",idUsuarioPermisos)
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


        public RespuestaBD AsignarPermisosTools(int idUsuarioPermisos, int idHerramienta, bool permitir)
        {
            SqlTools helpSql = new SqlTools(conexion);
            RespuestaBD resp = helpSql.ExecuteSP("sps_MDB_seg_edit_permisos_tool",
                    new SqlParameter[]{       
                        new SqlParameter("@pi_id_usuario_permisos",idUsuarioPermisos),
                        new SqlParameter("@pi_id_herramienta",idHerramienta),
                        new SqlParameter("@pl_permitir",permitir)
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
