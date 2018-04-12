using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAO.ADO
{

    public class DAOPais : IDAOPais
    {
        string conexion;

        public DAOPais()
        {
            conexion = Conexion.DBConexion.conexiones.conn_SERV.ToString();
        }

        public RespuestaBD ObtenerCatalogoPais(bool? activo=null)
        {
            SqlTools helpSql = new SqlTools(conexion);
            RespuestaBD resp = helpSql.ExecuteSP("sps_MDB_seg_obtener_paises",
                    new SqlParameter[]{               
                        new SqlParameter("@pl_activo",activo), 
                }
                    );
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
