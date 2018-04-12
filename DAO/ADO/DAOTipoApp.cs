using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAO.ADO
{
    public class DAOTipoApp : IDAOTipoApp
    {
        string conexion;

        public DAOTipoApp()
        {
            conexion = Conexion.DBConexion.conexiones.conn_SERV.ToString();
        }

        public RespuestaBD ObtenerTiposApp(int? idTipoApp, bool? activo = null)
        {
            SqlTools helpSql = new SqlTools(conexion);
            RespuestaBD resp = helpSql.ExecuteSP("sps_MDB_seg_obtener_tipo_app",
                    new SqlParameter[]{       
                        new SqlParameter("@pi_id_tipo_app",idTipoApp),
                        new SqlParameter("@pl_activo",activo)
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

        public RespuestaBD RegistrarEditarTipoApp(int idTipoApp, string descripcion, bool activo)
        {
            
            SqlTools helpSql = new SqlTools(conexion);
            RespuestaBD resp = helpSql.ExecuteSP("sps_MDB_seg_regedit_tipo_app",
                    new SqlParameter[]{       
                        new SqlParameter("@pi_id_tipo_app",idTipoApp),
                        new SqlParameter("@pc_descripcion",descripcion),
                        new SqlParameter("@pl_activo",activo)
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

        public RespuestaBD EliminarTipoApp(int idRol, int idItem)
        {
            throw new NotImplementedException();
        }

        public RespuestaBD ObtenerListaTipoApp()
        {
            SqlTools helpSql = new SqlTools(conexion);
            RespuestaBD resp = helpSql.ExecuteSP("sps_MDB_seg_obtener_tipo_app",
                    new SqlParameter[]{                               
                        new SqlParameter("@pl_activo",true)
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
