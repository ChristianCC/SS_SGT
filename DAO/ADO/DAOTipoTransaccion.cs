using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAO.ADO
{
    public class DAOTipoTransaccion :IDAOTipoTransaccion
    {
        string conexion;

        public DAOTipoTransaccion()
        {
            conexion = Conexion.DBConexion.conexiones.conn_SERV.ToString();
        }

        public RespuestaBD ObtenerTipoTransaccion(int? id, int? status)
        {
            SqlTools helpSql = new SqlTools(conexion);
            RespuestaBD resp = helpSql.ExecuteSP("sps_MDB_seg_obtener_tipo_transaccion",
                    new SqlParameter[]
                    {       
                        new SqlParameter("@pi_id_tipo_transaccion",id),
                        new SqlParameter("@pl_activo",status)
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

        public RespuestaBD RegistrarTipoTransaccion(bool status, string descripcion)
        {
            SqlTools helpSql = new SqlTools(conexion);
            RespuestaBD resp = helpSql.ExecuteSP("sps_MDB_seg_regedit_tipo_transaccion",
                    new SqlParameter[]{       
                        new SqlParameter("@pc_descripcion",descripcion),
                        new SqlParameter("@pl_activo",status)
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

        public RespuestaBD EditarTipoTransaccion(int id, bool status, string descripcion)
        {
            SqlTools helpSql = new SqlTools(conexion);
            RespuestaBD resp = helpSql.ExecuteSP("sps_MDB_seg_regedit_tipo_transaccion",
                    new SqlParameter[]{       
                        new SqlParameter("@pi_id_tipo_transaccion",id),
                        new SqlParameter("@pc_descripcion",descripcion),
                        new SqlParameter("@pl_activo",status)
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

        public RespuestaBD ObtenerListaTipoTransaccion()
        {
            SqlTools helpSql = new SqlTools(conexion);
            RespuestaBD resp = helpSql.ExecuteSP("sps_MDB_seg_obtener_tipo_transaccion",
                    new SqlParameter[]
                    {       
                        new SqlParameter("@pi_id_tipo_transaccion",null),
                        new SqlParameter("@pl_activo",1)
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
