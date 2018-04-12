using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;


namespace DAO.ADO
{
    public class DAOSistema : IDAOSistema
    {
        string conexion;

        public DAOSistema()
        {
            conexion = Conexion.DBConexion.conexiones.conn_SERV.ToString();
        }

        public RespuestaBD IniciarSesion(string usuario,string llave,string ip,string sistema,bool cerrareSesiones)
        {
            SqlTools helpSql = new SqlTools(conexion);
            RespuestaBD resp = helpSql.ExecuteSP("sps_MDB_seg_iniciar_sesion",
                    new SqlParameter[]{       
                        new SqlParameter("@pc_usuario",usuario),
                        new SqlParameter("@pc_ip_usuario",ip),
                        new SqlParameter("@pcLlave",llave),
                        new SqlParameter("@pc_sistema_acceso",sistema),
                        new SqlParameter("@pl_cerrar_sesiones",cerrareSesiones)
                });

            //if (resp.EXISTE_ERROR)
            //{
            //    Exception ex = new Exception(resp.MENSAJE);
            //    ex.Data.Add("status", resp.respuesta);
            //    throw ex;
            //}
            //else
            {
                return resp;
            }
        }

        public RespuestaBD ObtenerLlaveUsuario(string usuario)
        {
            SqlTools helpSql = new SqlTools(conexion);
            RespuestaBD resp = helpSql.ExecuteSP("sps_MDB_seg_obtener_llave",
                    new SqlParameter[]{       
                        new SqlParameter("@pc_usuario",usuario)                        
                });

            if (resp.EXISTE_ERROR)
            {
                Exception ex = new Exception(resp.MENSAJE);
                ex.Data.Add("status", resp.respuesta);
                throw ex;
            }
            else
            {
                return resp;
            }
        }

        public RespuestaBD CerrarSesion(string usuario)
        {
            SqlTools helpSql = new SqlTools(conexion);
            RespuestaBD resp = helpSql.ExecuteSP("sps_MDB_seg_cerrar_sesion",
                    new SqlParameter[]{       
                        new SqlParameter("@pc_usuario",usuario)                        
                });

            if (resp.EXISTE_ERROR)
            {
                Exception ex = new Exception(resp.MENSAJE);
                ex.Data.Add("status", resp.respuesta);
                throw ex;
            }
            else
            {
                return resp;
            }
        }

        public RespuestaBD ValidarToken(string token)
        {
            SqlTools helpSql = new SqlTools(conexion);
            RespuestaBD resp = helpSql.ExecuteSP("sps_MDB_seg_valida_token",
                    new SqlParameter[]{       
                        new SqlParameter("@pc_token",token)                        
                });            
                return resp;
            
        }

        
        public RespuestaBD ValidarAcceso(string url,string usuario)
        {
            SqlTools helpSql = new SqlTools(conexion);
            RespuestaBD resp = helpSql.ExecuteSP("sps_MDB_seg_valida_acceso",
                    new SqlParameter[]{       
                        new SqlParameter("@pc_url",url),
                        new SqlParameter("@pc_usuario",usuario)                        
                });            
                return resp;
            
        }

        public RespuestaBD RegistrarToken(string token, DateTime fechaCaduca, string usuario)
        {
            SqlTools helpSql = new SqlTools(conexion);
            RespuestaBD resp = helpSql.ExecuteSP("sps_MDB_seg_reg_token",
                    new SqlParameter[]{       
                        new SqlParameter("@pc_token",token) ,                       
                        new SqlParameter("@pd_fecha_caduca",fechaCaduca) ,
                        new SqlParameter("@pc_usuario",usuario) ,
                });
            return resp;
        }
    }
}
