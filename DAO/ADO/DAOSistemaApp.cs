using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace DAO.ADO
{
    public class DAOSistemaApp : IDAOSistemaApp
    {
        string conexion;

        public DAOSistemaApp()
        {
            conexion = Conexion.DBConexion.conexiones.conn_SERV.ToString();
        }

        public RespuestaBD ObtenerListaSistemasApp(int? status)
        {
            throw new NotImplementedException();
        }

        public RespuestaBD ObtenerSistemasApp(int? idSistema)
        {
            SqlTools helpSql = new SqlTools(conexion);
            RespuestaBD resp = helpSql.ExecuteSP("sps_MDB_seg_obtener_sistemas",
                    new SqlParameter[]{                               
                        new SqlParameter("@pi_id_sistema",idSistema)                        
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

        public RespuestaBD RegistrarSistemaApp(string nombre, 
            string logo, string urlhome, bool sistemaEmbebido, bool estatus)
        {
            SqlTools helpSql = new SqlTools(conexion);
            RespuestaBD resp = helpSql.ExecuteSP("sps_MDB_seg_regedit_sistema",
                    new SqlParameter[]{                               
                        new SqlParameter("@pc_nombre_sistema",nombre),
                        new SqlParameter("@pl_estatus_sistema",estatus),
                        new SqlParameter("@pc_logo",logo),
                        new SqlParameter("@pc_url_home",urlhome),
                        new SqlParameter("@pl_embebido",sistemaEmbebido)                        
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

        public RespuestaBD EditarSistemaApp(int idSistemaApp,
            string nombre, string logo, string urlhome, bool sistemaEmbebido, bool estatus)
        {
            SqlTools helpSql = new SqlTools(conexion);
            RespuestaBD resp = helpSql.ExecuteSP("sps_MDB_seg_regedit_sistema",
                    new SqlParameter[]{       
                        new SqlParameter("@pi_id_sistema",idSistemaApp),
                        new SqlParameter("@pc_nombre_sistema",nombre),
                        new SqlParameter("@pl_estatus_sistema",estatus),
                        new SqlParameter("@pc_logo",logo),
                        new SqlParameter("@pc_url_home",urlhome),
                        new SqlParameter("@pl_embebido",sistemaEmbebido)                        
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
