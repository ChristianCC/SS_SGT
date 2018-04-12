using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAO.ADO
{
    public class DAORol : IDAORol
    {
        string conexion;

        public DAORol()
        {
            conexion = Conexion.DBConexion.conexiones.conn_SERV.ToString();
        }

        public RespuestaBD ObtenerRoles(int? idSistema= null ,bool? activo = null)
        {
            SqlTools helpSql = new SqlTools(conexion);
            RespuestaBD resp = helpSql.ExecuteSP("sps_MDB_seg_obtener_roles",
                    new SqlParameter[]{       
                        new SqlParameter("@pi_id_estatus",activo),
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

        public RespuestaBD ObtenerRolesUsuario(string usuario, int? idSistema)
        {
            SqlTools helpSql = new SqlTools(conexion);
            RespuestaBD resp = helpSql.ExecuteSP("sps_MDB_seg_obtener_roles_usuario",
                    new SqlParameter[]{       
                        new SqlParameter("@pc_usuario",usuario),
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

        public RespuestaBD RegistrarEditarRol(int idRol, string descripcion, string nombre, int idPais, bool activo)
        {
            SqlTools helpSql = new SqlTools(conexion);
            RespuestaBD resp = helpSql.ExecuteSP("sps_MDB_seg_regedit_rol",
                    new SqlParameter[]{       
                        new SqlParameter("@pc_descripcion_rol",descripcion),
                        new SqlParameter("@pc_nombre_rol",nombre),
                        new SqlParameter("@pi_id_pais",idPais),
                        new SqlParameter("@pi_id_rol",idRol),
                        new SqlParameter("@pl_activo",activo)
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

        public RespuestaBD LimpiarAsignacionRol(int idRol)
        {
            SqlTools helpSql = new SqlTools(conexion);
            RespuestaBD resp = helpSql.ExecuteSP("sps_MDB_seg_limpiar_rolmodulo",
                    new SqlParameter[]{                               
                        new SqlParameter("@pi_id_rol",idRol)                        
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

        public RespuestaBD RegistrarEditarRolItem(int idRol, int idItem)
        {
            SqlTools helpSql = new SqlTools(conexion);
            RespuestaBD resp = helpSql.ExecuteSP("sps_MDB_seg_regedit_rolmodulo",
                    new SqlParameter[]{                               
                        new SqlParameter("@pi_id_rol",idRol) ,                       
                        new SqlParameter("@pi_id_item_modulo",idItem)  ,
                        //new SqlParameter("@pl_escritura",escritura) , 
                        //new SqlParameter("@pl_update",update) 
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

        public RespuestaBD EliminarRolItem(int idRol, int idItem)
        {
            SqlTools helpSql = new SqlTools(conexion);
            RespuestaBD resp = helpSql.ExecuteSP("sps_MDB_seg_eliminar_rolmodulo",
                    new SqlParameter[]{                               
                        new SqlParameter("@pi_id_rol",idRol) ,                       
                        new SqlParameter("@pi_id_item_modulo",idItem)                          
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

        public RespuestaBD ObtenerItemsRol(int idRol)
        {
            SqlTools helpSql = new SqlTools(conexion);
            RespuestaBD resp = helpSql.ExecuteSP("sps_MDB_seg_obtener_items_rol",
                    new SqlParameter[]{       
                        new SqlParameter("@pi_id_rol",idRol)
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
