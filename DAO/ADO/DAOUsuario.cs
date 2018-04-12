using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAO.ADO
{
    public class DAOUsuario : IDAOUsuario
    {
        string conexion;

        public DAOUsuario()
        {
            conexion = Conexion.DBConexion.conexiones.conn_SERV.ToString();
        }

        public RespuestaBD ObtenerListaUsuarios(int? status,string usuario = null)
        {
            SqlTools helpSql = new SqlTools(conexion);
            RespuestaBD resp = helpSql.ExecuteSP("sps_MDB_seg_obtener_usuarios",
                    new SqlParameter[]{       
                        new SqlParameter("@pi_id_estatus",status),
                        new SqlParameter("@pc_usuario",usuario)
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

        public RespuestaBD RegistrarUsuario(string usuario_sistema, string password, string nombre, string apellido_paterno,
           string apellido_materno, string correo, string celular, string extension)
        {
            SqlTools helpSql = new SqlTools(conexion);
            RespuestaBD resp = helpSql.ExecuteSP("sps_MDB_seg_reg_usuario",
                    new SqlParameter[]{       
                        new SqlParameter("@pc_usuario",usuario_sistema),
                        new SqlParameter("@pc_llave_usuario",password),
                        new SqlParameter("@pc_nombre",nombre),
                        new SqlParameter("@pc_apellido_p",apellido_paterno),
                        new SqlParameter("@pc_apellido_m",apellido_materno),
                        new SqlParameter("@pc_correo",correo),
                        new SqlParameter("@pc_celular",celular),
                        new SqlParameter("@pc_extension_usuario",extension)
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

        public RespuestaBD EditarUsuario(string usuario_sistema, string password, string nombre, string apellido_paterno,
           string apellido_materno, string correo, string celular, string extension, DateTime? fechaDeVencimiento, int idEstatus)
        {
            SqlTools helpSql = new SqlTools(conexion);
            RespuestaBD resp = helpSql.ExecuteSP("sps_MDB_seg_edit_usuario",
                    new SqlParameter[]{       
                        new SqlParameter("@pc_usuario",usuario_sistema),
                        new SqlParameter("@pc_llave_usuario",password),
                        new SqlParameter("@pc_nombre",nombre),
                        new SqlParameter("@pc_apellido_p",apellido_paterno),
                        new SqlParameter("@pc_apellido_m",apellido_materno),
                        new SqlParameter("@pc_correo",correo),
                        new SqlParameter("@pc_celular",celular),
                        new SqlParameter("@pc_extension_usuario",extension),
                        new SqlParameter("@pd_fecha_vencimiento",fechaDeVencimiento),
                        new SqlParameter("@pi_id_estatus",idEstatus)
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

        public RespuestaBD RegistrarEditarRolUsuario(int idRol, string usuario_sistema, int idPais, bool eliminar)
        {
            SqlTools helpSql = new SqlTools(conexion);
            RespuestaBD resp = helpSql.ExecuteSP("sps_MDB_seg_regedit_rol_usuario",
                    new SqlParameter[]{                               
                        new SqlParameter("@pi_id_rol",idRol) ,                       
                        new SqlParameter("@pc_usuario",usuario_sistema)  ,
                        new SqlParameter("@pl_eliminar",eliminar)  ,
                        new SqlParameter("@pi_id_pais",idPais)                          
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

        public RespuestaBD ObtenerItemsUsuario(string usuario_sistema)
        {
            SqlTools helpSql = new SqlTools(conexion);
            RespuestaBD resp = helpSql.ExecuteSP("sps_MDB_seg_obtener_accesos_usuario",
                    new SqlParameter[]{       
                        new SqlParameter("@pc_usuario",usuario_sistema)
                });

            if (resp.EXISTE_ERROR)
            {
                Exception ex = new Exception(resp.MENSAJE);
                ex.Data.Add("status",resp.respuesta);
                throw ex;
            }
            else
            {
                return resp;
            }
        }

        
        public RespuestaBD EditarPassword(string usuario_sistema, string password, string passwordAnterior = "")
        {
            SqlTools helpSql = new SqlTools(conexion);
            RespuestaBD resp = helpSql.ExecuteSP("sps_MDB_seg_edit_pass",
                    new SqlParameter[]{       
                        new SqlParameter("@pc_usuario",usuario_sistema),
                        new SqlParameter("@pc_llave_usuario",password),
                        new SqlParameter("@pc_llave_usuario_anterior",passwordAnterior)
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


        public RespuestaBD ObtenerInfoUsuario(string usuario )
        {
            SqlTools helpSql = new SqlTools(conexion);
            RespuestaBD resp = helpSql.ExecuteSP("sps_MDB_seg_obtener_usuarios",
                    new SqlParameter[]{       
                        new SqlParameter("@pi_id_estatus",null),
                        new SqlParameter("@pc_usuario",usuario)
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
