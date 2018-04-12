using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAO.ADO
{
    public class DAOTransaccion : IDAOTransaccion
    {
        string conexion;

        public DAOTransaccion()
        {
            conexion = Conexion.DBConexion.conexiones.conn_SERV.ToString();
        }

        public RespuestaBD ObtenerBitacoraTransaccion(int? idSistema,int? idTipoTransaccion,string host, string ip, string dominio, DateTime? fechaInicio, DateTime? fechaFin)
        {
            SqlTools helpSql = new SqlTools(conexion);
            RespuestaBD resp = helpSql.ExecuteSP("sps_MDB_seg_obtener_bit_trans",
                    new SqlParameter[]{       
                        new SqlParameter("@pi_id_sistema",idSistema),
                        new SqlParameter("@pi_id_tipo_transaccion",idTipoTransaccion),
                        new SqlParameter("@pc_hostname",host),
                        new SqlParameter("@pc_ipclient",ip),
                        new SqlParameter("@pc_dominio",dominio),
                        new SqlParameter("@pd_fecha_sistema_ini",fechaInicio),                        
                        new SqlParameter("@pd_fecha_sistema_fin",fechaFin)                        
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

        public RespuestaBD RegistrarTransaccion(int idSistema, int idTipoTransaccion, string tipoAcceso,
            string neUsuario, string url, int idTipoApp, string hostName,
            string ipCliente, string mensaje, string dominio, DateTime? inicioProceso,
            DateTime? finDeProceso, int? idAppExt, int? idUsuarioExt)
        {
            SqlTools helpSql = new SqlTools(conexion);
            RespuestaBD resp = helpSql.ExecuteSP("sps_MDB_seg_reg_transaccion",
                    new SqlParameter[]{       
                        new SqlParameter("@pi_id_sistema",idSistema),
                        new SqlParameter("@pi_id_tipo_transaccion",idTipoTransaccion),
                        new SqlParameter("@pc_neusuario",neUsuario),
                        new SqlParameter("@pc_url",url),
                        new SqlParameter("@pi_id_tipo_app",idTipoApp),
                        new SqlParameter("@pc_hostname",hostName),
                        new SqlParameter("@pc_ipclient",ipCliente),
                        new SqlParameter("@pc_mensaje",mensaje),
                        new SqlParameter("@pc_dominio",dominio),
                        new SqlParameter("@pd_fecha_inicio_proceso",inicioProceso),
                        new SqlParameter("@pd_fecha_fin_proceso",finDeProceso),
                        new SqlParameter("@pi_id_app",idAppExt),
                        new SqlParameter("@pi_id_usuario",idUsuarioExt)  ,
                        new SqlParameter ("@pc_tipo_acceso", tipoAcceso)
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
