using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace DAO.ADO
{
    public class DAOItemModulo : IDAOItemModulo
    {
        string conexion;

        public DAOItemModulo()
        {
            conexion = Conexion.DBConexion.conexiones.conn_SERV.ToString();
        }

        public RespuestaBD ObtenerItemsSistema(int? sistema = null)
        {
            SqlTools helpSql = new SqlTools(conexion);
            RespuestaBD resp = helpSql.ExecuteSP("sps_MDB_seg_obtener_items_sistema",
                    new SqlParameter[]{       
                        new SqlParameter("@pi_id_sistema",sistema)
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

        public  RespuestaBD RegistrarItemModulo(string nombre,
            int idModulo, string urlIcono, string urlDestino, int idItemPadre, int orden, bool activo)
        {
            SqlTools helpSql = new SqlTools(conexion);
            RespuestaBD resp = helpSql.ExecuteSP("sps_MDB_seg_regedit_item_modulo",
                    new SqlParameter[]{       
                        new SqlParameter("@pi_id_item_modulo",null),
                        new SqlParameter("@pc_desc_item",nombre),
                        new SqlParameter("@pc_url",urlDestino),
                        new SqlParameter("@pc_url_icono",urlIcono),
                        new SqlParameter("@pi_id_item_padre",idItemPadre),
                        new SqlParameter("@pi_id_modulo",idModulo),
                        new SqlParameter("@pl_estatus_item",activo),
                        new SqlParameter("@pi_id_orden",orden),
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

        public RespuestaBD EditarItemModulo(int idItem, string nombre,
            int idModulo, string urlIcono, string urlDestino, int idItemPadre, int orden, bool activo)
        {
            SqlTools helpSql = new SqlTools(conexion);
            RespuestaBD resp = helpSql.ExecuteSP("sps_MDB_seg_regedit_item_modulo",
                    new SqlParameter[]{       
                        new SqlParameter("@pi_id_item_modulo",idItem),
                        new SqlParameter("@pc_desc_item",nombre),
                        new SqlParameter("@pc_url",urlDestino),
                        new SqlParameter("@pc_url_icono",urlIcono),
                        new SqlParameter("@pi_id_item_padre",idItemPadre),
                        new SqlParameter("@pi_id_modulo",idModulo),
                        new SqlParameter("@pl_estatus_item",activo),
                        new SqlParameter("@pi_id_orden",orden),
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

        public RespuestaBD ObtenerInfoItemModulo(int idItem)
        {
            return null;
        }



        
    }
}
