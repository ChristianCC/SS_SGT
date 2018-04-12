using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAO.ADO
{
    public class DAOError : IDAOError
    {
        string conexion;

        public DAOError()
        {
            conexion = Conexion.DBConexion.conexiones.conn_SERV.ToString();
        }

        public RespuestaBD ObtenerBitacoraErrores(DateTime? fechaInicio, DateTime? fechaFin)
        {
            SqlTools helpSql = new SqlTools(conexion);
            RespuestaBD resp = helpSql.ExecuteSP("sps_MDB_seg_obtener_bit_error",
                    new SqlParameter[]{                               
                        new SqlParameter("@pd_fecha_error_ini",fechaInicio),                        
                        new SqlParameter("@pd_fecha_error_fin",fechaFin)                        
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
