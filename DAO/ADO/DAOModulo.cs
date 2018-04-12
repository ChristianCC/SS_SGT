using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace DAO.ADO
{
    public  class DAOModulo: IDAOModulo
    {
        string conexion;

        public DAOModulo()
        {
            conexion = Conexion.DBConexion.conexiones.conn_SERV.ToString();
        }

        public RespuestaBD ObtenerListaModulosSistemasApp(int? status)
        {
            throw new NotImplementedException();
        }

        public RespuestaBD ObtenerModulosSistemaApp(int idSistema,bool? itemsActivo)
        {
            SqlTools helpSql = new SqlTools(conexion);
            RespuestaBD resp = helpSql.ExecuteSP("sps_MDB_seg_obtener_modulo",
                    new SqlParameter[]{                               
                        new SqlParameter("@pi_id_sistema",idSistema)  ,
                        new SqlParameter("@pi_id_modulo",null),
                        new SqlParameter("@pl_item_activo",itemsActivo)
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

        public RespuestaBD ObtenerInfoModulosSistemaApp(int idModulo)
        {
            SqlTools helpSql = new SqlTools(conexion);
            RespuestaBD resp = helpSql.ExecuteSP("sps_MDB_seg_obtener_modulo",
                    new SqlParameter[]{                               
                        new SqlParameter("@pi_id_sistema",null)  ,
                        new SqlParameter("@pi_id_modulo",idModulo)
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


        public RespuestaBD RegistrarModuloApp(string nombre,
            int idSistema ,string urlIcono, string urlDestino, string dbConexion, bool activo)
        {
            SqlTools helpSql = new SqlTools(conexion);
            RespuestaBD resp = helpSql.ExecuteSP("sps_MDB_seg_regedit_modulo",
                    new SqlParameter[]{                               
                        new SqlParameter("@pc_nombre_modulo",nombre),
                        new SqlParameter("@pc_url_icono",urlIcono),
                        new SqlParameter("@pc_url_destino",urlDestino),
                        new SqlParameter("@pi_id_sistema",idSistema),
                        new SqlParameter("@pl_estatus_modulo",activo),
                        new SqlParameter("@pc_db_conexion",dbConexion),
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

        public RespuestaBD EditarModuloApp(int idModulo,string nombre,
            int idSistema, string urlIcono, string urlDestino, string dbConexion, bool activo)
        {
            SqlTools helpSql = new SqlTools(conexion);
            RespuestaBD resp = helpSql.ExecuteSP("sps_MDB_seg_regedit_modulo",
                    new SqlParameter[]{                              
                        new SqlParameter("@pi_id_modulo",idModulo),
                        new SqlParameter("@pc_nombre_modulo",nombre),
                        new SqlParameter("@pc_url_icono",urlIcono),
                        new SqlParameter("@pc_url_destino",urlDestino),
                        new SqlParameter("@pi_id_sistema",idSistema),
                        new SqlParameter("@pl_estatus_modulo",activo),
                        new SqlParameter("@pc_db_conexion",dbConexion),
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
