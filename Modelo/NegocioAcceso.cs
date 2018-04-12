using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using DAO;
using DAO.ADO;
using Entidad.Common;
using System.ServiceModel;
using ViewModel.Catalogo._ItemModulo;
using ViewModel.Catalogo._Rol;
using Tools;

namespace Modelo
{
    public class NegocioAcceso
    {
        public List<VMItemModulo> ObtenerItemsDeSistema()
        {
            try
            {
                RespuestaBD resp = new DAOItemModulo().ObtenerItemsSistema(null);
                if (resp.EXISTE_ERROR)
                {
                    throw new Exception(resp.MENSAJE);
                }
                else
                {
                    List<VMItemModulo> lista = new List<VMItemModulo>();
                    if (resp.dataSet.Tables.Count > 0)
                    {
                        DataTable datos = resp.dataSet.Tables[0];
                        lista = (from x in datos.AsEnumerable()
                                 select new VMItemModulo()
                                 {
                                     Activo = x.Field<bool>("fl_estatus_item"),
                                    Descripcion = x.Field<string>("fc_desc_item"),
                                    IdItemModulo = x.Field<int>("fi_id_item_modulo"),
                                    IdItemPadre = x.Field<int>("fi_id_item_padre"),
                                    IdModulo = x.Field<int>("fi_id_modulo"),
                                     IdSistema = x.Field<int>("fi_id_sistema"),
                                    Modulo = x.Field<string>("fc_nombre_modulo"),
                                    Orden = x.Field<int>("fi_id_orden"),
                                    Sistema = x.Field<string>("fc_nombre_sistema"),
                                    Url = x.Field<string>("fc_url"),
                                    UrlIcono = x.Field<string>("fc_url_icono"),
                                     

                                 }).ToList();
                    }
                    return lista;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(new Util().ObtenerMsjExcepcion(ex));
            }
        }

        public List<VMItemModulo> ObtenerItemsDeRol(int idRol)
        {
            try
            {
                RespuestaBD resp = new DAORol().ObtenerItemsRol(idRol);
                if (resp.EXISTE_ERROR)
                {
                    throw new Exception(resp.MENSAJE);
                }
                else
                {
                    List<VMItemModulo> lista = new List<VMItemModulo>();
                    if (resp.dataSet.Tables.Count > 0)
                    {
                        DataTable datos = resp.dataSet.Tables[0];
                        lista = (from x in datos.AsEnumerable()
                                 select new VMItemModulo()
                                 {
                                     Activo = x.Field<bool>("fl_estatus_item"),
                                     Descripcion = x.Field<string>("fc_desc_item"),
                                     IdItemModulo = x.Field<int>("fi_id_item_modulo"),
                                     IdItemPadre = x.Field<int>("fi_id_item_padre"),
                                     IdModulo = x.Field<int>("fi_id_modulo"),
                                     IdSistema = x.Field<int>("fi_id_sistema"),
                                     Modulo = x.Field<string>("fc_nombre_modulo"),
                                     Orden = x.Field<int>("fi_id_orden"),
                                     Sistema = x.Field<string>("fc_nombre_sistema"),
                                     Url = x.Field<string>("fc_url"),
                                     UrlIcono = x.Field<string>("fc_url_icono"),
                                     UrlIconoModulo = x.Field<string>("fc_url_icono_modulo")


                                 }).ToList();
                    }
                    return lista;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(new Util().ObtenerMsjExcepcion(ex));
            }
        }

        public void LimpiarItemsRol(int idRol)
        {
            try
            {
                RespuestaBD resp = new DAORol().LimpiarAsignacionRol(idRol);
                if (resp.EXISTE_ERROR)
                {
                    throw new Exception(resp.MENSAJE);
                }                
            }
            catch (Exception ex)
            {
                throw new Exception(new Util().ObtenerMsjExcepcion(ex));                
            }
        }

        public void AsignarItemRol(int idRol, int idItem)
        {
            try
            {
                RespuestaBD resp = new DAORol().RegistrarEditarRolItem(idRol,idItem);
                if (resp.EXISTE_ERROR)
                {
                    throw new Exception(resp.MENSAJE);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(new Util().ObtenerMsjExcepcion(ex)); 
            }
        }

        public void EliminarItemRol(int idRol, int idItem)
        {
            try
            {
                RespuestaBD resp = new DAORol().EliminarRolItem(idRol, idItem);
                if (resp.EXISTE_ERROR)
                {
                    throw new Exception(resp.MENSAJE);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(new Util().ObtenerMsjExcepcion(ex));                 
            }
        }

        public void AsignarPermisos(int usuarioRol, bool write, bool delete)
        {
            try
            {
                RespuestaBD resp = new DAOPermisosItem().AsignarPermisos(usuarioRol,write,delete);
                if (resp.EXISTE_ERROR)
                {
                    throw new Exception(resp.MENSAJE);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(new Util().ObtenerMsjExcepcion(ex));
            }
        }

        public void AsignarPermisosTool(int usuarioRol, int idTool, bool permitir)
        {
            try
            {
                IDAOPermisosTool idaoTools = new DAOPermisosTool();
                RespuestaBD resp = idaoTools.AsignarPermisosTools(usuarioRol,idTool,permitir);
                if (resp.EXISTE_ERROR)
                {
                    throw new Exception(resp.MENSAJE);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(new Util().ObtenerMsjExcepcion(ex));
            }
        }
    }
}
