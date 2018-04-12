using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAO.ADO
{
    public class DAOAcceso : IDAOAcceso
    {

        string conexion;        

        public DAOAcceso()
        {
            conexion = Conexion.DBConexion.conexiones.conn_SERV.ToString();
        }

        public RespuestaBD ObtenerBitacoraAccesos(string idUsuario, string ipUsuario, DateTime? fechaInicio, DateTime? fechaFin)
        {
            SqlTools helpSql = new SqlTools(conexion);
            RespuestaBD resp = helpSql.ExecuteSP("sps_MDB_seg_obtener_bit_acceso",
                    new SqlParameter[]{       
                        new SqlParameter("@pc_usuario",idUsuario),
                        new SqlParameter("@pc_ip_usuario",ipUsuario),                        
                        new SqlParameter("@pd_fecha_acceso_ini",fechaInicio),                        
                        new SqlParameter("@pd_fecha_acceso_fin",fechaFin)                        
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
