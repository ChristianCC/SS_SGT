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
using ViewModel.Catalogo._Sistema;
using ViewModel.Catalogo._Modulo;

using ViewModel;
using ViewModel.Catalogo._ToolItem;

using Tools;



namespace Modelo
{
    public class NegocioModulosAcceso
    {                

        public VMSistema RegistrarSistema(string nombre, string logo, string urlhome, bool sistemaEmbebido, bool estatus)
        {
            try
            {
                VMSistema sis = new VMSistema();
                string error = string.Empty;
                if (string.IsNullOrEmpty(nombre))
                {
                    error += "- Debes registrar un Nombre." + "<br />";
                }
                
                if (string.IsNullOrEmpty(error))
                {                    
                    IDAOSistemaApp iDaoSistemaApp = new DAOSistemaApp();
                    RespuestaBD resp = iDaoSistemaApp.RegistrarSistemaApp(nombre, logo, urlhome, sistemaEmbebido,  estatus);               
                    if (resp.EXISTE_ERROR)
                    {
                        throw new Exception(resp.MENSAJE);
                    }
                    else
                    {
                        sis = new VMSistema() //mapea modelo
                        {
                            NombreSistema = nombre,
                            Logo = logo,
                            UrlHome = urlhome,
                            Embebido = sistemaEmbebido,
                            Activo = estatus,
                            IdSistema = (int)resp.dataSet.Tables[0].Rows[0]["fi_id_sistema"]
                        };
                    }
                    return sis;
                }
                else
                {
                    throw new Exception(error);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(new Util().ObtenerMsjExcepcion(ex));
            }
        }

        public void EditarSistema(int idSistema,
            string nombre, string logo, string urlhome, bool sistemaEmbebido, bool estatus)
        {
            try
            {
                VMSistema sis = new VMSistema();
                string error = string.Empty;
                if (idSistema <= 0)
                {
                    error += "- Indica que sistema se actualizara." + "<br />";
                }

                if (string.IsNullOrEmpty(nombre))
                {
                    error += "- Debes registrar un Nombre." + "<br />";
                }

                if (string.IsNullOrEmpty(error))
                {
                    IDAOSistemaApp iDaoSistemaApp = new DAOSistemaApp();
                    RespuestaBD resp = iDaoSistemaApp.EditarSistemaApp(idSistema, nombre, logo, urlhome, sistemaEmbebido, estatus);
                    if (resp.EXISTE_ERROR)
                    {
                        throw new Exception(resp.MENSAJE);
                    }                    
                }
                else
                {
                    throw new Exception(error);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(new Util().ObtenerMsjExcepcion(ex));
            }
        }

        public VMModulo RegistrarModuloSistemaApp(string nombre,
            int idSistema ,string urlIcono, string urlDestino, string dbConexion, bool activo)
        {
            try
            {
                VMModulo modulo = new VMModulo();
                string error = string.Empty;
                
                if (idSistema <= 0)
                {
                    error += "- Indica el sistema al que pertenece este modulo." + "<br />";
                }

                if (string.IsNullOrEmpty(nombre))
                {
                    error += "- Debes registrar un Nombre." + "<br />";
                }

                if (string.IsNullOrEmpty(error))
                {
                    IDAOModulo iDaoModuloApp = new DAOModulo();
                    RespuestaBD resp = iDaoModuloApp.RegistrarModuloApp( nombre,
                                idSistema , urlIcono,  urlDestino,  dbConexion,  activo);
                    if (resp.EXISTE_ERROR)
                    {
                        throw new Exception(resp.MENSAJE);
                    }
                    else
                    {
                        modulo = new VMModulo() //mapea modelo
                        {
                            Nombre = nombre,
                            Activo = activo,
                            DbConexion = dbConexion,                            
                            IdSistema = idSistema,
                            UrlDestino = urlDestino,
                            UrlIcono = urlIcono,
                            IdModulo = (int)resp.dataSet.Tables[0].Rows[0]["fi_id_modulo"]
                        };
                    }
                    return modulo;
                }
                else
                {
                    throw new Exception(error);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(new Util().ObtenerMsjExcepcion(ex));
            }
        }

        public void EditarModuloSistemaApp(int idModulo,string nombre,
            int idSistema, string urlIcono, string urlDestino, string dbConexion, bool activo)
        {
            try
            {
                VMModulo modulo = new VMModulo();
                string error = string.Empty;
                if (idModulo <= 0)
                {
                    error += "- Indica el modulo a actualizar." + "<br />";
                }

                if (idSistema <= 0)
                {
                    error += "- Indica el sistema al que pertenece este modulo." + "<br />";
                }

                if (string.IsNullOrEmpty(nombre))
                {
                    error += "- Debes registrar un Nombre." + "<br />";
                }

                if (string.IsNullOrEmpty(error))
                {
                    IDAOModulo iDaoModuloApp = new DAOModulo();
                    RespuestaBD resp = iDaoModuloApp.EditarModuloApp(idModulo,nombre,
                                idSistema, urlIcono, urlDestino, dbConexion, activo);
                    if (resp.EXISTE_ERROR)
                    {
                        throw new Exception(resp.MENSAJE);
                    }                    
                }
                else
                {
                    throw new Exception(error);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(new Util().ObtenerMsjExcepcion(ex));
            }
        }

        public List<VMSistema> ObtenerCatalogoSistemaApp()
        {
            try
            {
                IDAOSistemaApp iDaoSis = new DAOSistemaApp();
                RespuestaBD resp = iDaoSis.ObtenerSistemasApp(null);
                if (resp.EXISTE_ERROR)
                {
                    throw new Exception(resp.MENSAJE);
                }
                else
                {
                    List<VMSistema> lista = new List<VMSistema>();
                    if (resp.dataSet.Tables.Count > 0)
                    {
                        DataTable datos = resp.dataSet.Tables[0];
                        lista = (from x in datos.AsEnumerable()
                                 select new VMSistema()
                                 {
                                     Activo = x.Field<bool>("fl_estatus_sistema"),
                                     Embebido = x.Field<bool>("fl_embebido"),
                                     IdSistema = x.Field<int>("fi_id_sistema"),
                                     Logo = x.Field<string>("fc_logo"),
                                     NombreSistema = x.Field<string>("fc_nombre_sistema"),
                                     UrlHome = x.Field<string>("fc_url_home"),
                                 }).ToList();
                    }
                    return lista;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public VMSistema ObtenerInfoSistemaApp(int idSistema)
        {
            try
            {
                IDAOSistemaApp iDaoSis = new DAOSistemaApp();
                RespuestaBD resp = iDaoSis.ObtenerSistemasApp(idSistema);
                if (resp.EXISTE_ERROR)
                {
                    throw new Exception(resp.MENSAJE);
                }
                else
                {
                    DataTable datos = resp.dataSet.Tables[0];
                    VMSistema sis = (from x in datos.AsEnumerable()
                             select new VMSistema()
                             {
                                 Activo = x.Field<bool>("fl_estatus_sistema"),
                                 Embebido = x.Field<bool>("fl_embebido"),
                                 IdSistema = x.Field<int>("fi_id_sistema"),
                                 Logo = x.Field<string>("fc_logo"),
                                 NombreSistema = x.Field<string>("fc_nombre_sistema"),
                                 UrlHome = x.Field<string>("fc_url_home"),
                             }).FirstOrDefault();
                    return sis;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<VMModulo> ObtenerModulosSistemaApp(int idSistema,bool? activo)
        {
            try
            {
                IDAOModulo iDaoModulo = new DAOModulo();
                RespuestaBD resp = iDaoModulo.ObtenerModulosSistemaApp(idSistema,activo);
                if (resp.EXISTE_ERROR)
                {
                    throw new Exception(resp.MENSAJE);
                }
                else
                {
                    List<VMModulo> lista = new List<VMModulo>();
                    if (resp.dataSet.Tables.Count > 0)
                    {
                        DataTable datos = resp.dataSet.Tables[0];
                        lista = (from x in datos.AsEnumerable()
                                 select new VMModulo()
                                 {
                                     IdSistema = x.Field<int>("fi_id_sistema"),
                                     IdModulo = x.Field<int>("fi_id_modulo"),
                                     Activo = x.Field<bool>("fl_estatus_modulo"),
                                     UrlDestino = x.Field<string>("fc_url_destino"),
                                     UrlIcono = x.Field<string>("fc_url_icono"),
                                     Nombre = x.Field<string>("fc_nombre_modulo"),
                                     DbConexion = x.Field<string>("fc_db_conexion"),                                     
                                 }).ToList();
                    }
                    
                    if (resp.dataSet.Tables.Count > 1)
                    {//Items
                        DataTable items = resp.dataSet.Tables[1];
                        foreach (VMModulo modulo in lista)
                        {
                            modulo.Items = (from x in items.AsEnumerable()
                                            where x.Field<int>("fi_id_modulo") == modulo.IdModulo
                                     select new VMItemModulo()
                                     {
                                         IdItemModulo = x.Field<int>("fi_id_item_modulo"),
                                         IdModulo = x.Field<int>("fi_id_modulo"),
                                         Activo = x.Field<bool>("fl_estatus_item"),
                                         Descripcion = x.Field<string>("fc_desc_item"),
                                         Url = x.Field<string>("fc_url"),
                                         UrlIcono = x.Field<string>("fc_url_icono"),
                                         IdItemPadre = x.Field<int>("fi_id_item_padre"),
                                         Orden = x.Field<int>("fi_id_orden"),
                                     }).ToList();
                        }
                    }

                    return lista;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public VMModulo ObtenerInfoModulosSistemaApp(int idModulo)
        {
            try
            {
                IDAOModulo iDaoModulo = new DAOModulo();
                RespuestaBD resp = iDaoModulo.ObtenerInfoModulosSistemaApp(idModulo);
                if (resp.EXISTE_ERROR)
                {
                    throw new Exception(resp.MENSAJE);
                }
                else
                {
                    VMModulo modulo = new VMModulo();
                    if (resp.dataSet.Tables.Count > 0)
                    {
                        DataTable datos = resp.dataSet.Tables[0];
                        modulo = (from x in datos.AsEnumerable()
                                 select new VMModulo()
                                 {
                                     IdSistema = x.Field<int>("fi_id_sistema"),
                                     IdModulo = x.Field<int>("fi_id_modulo"),
                                     Activo = x.Field<bool>("fl_estatus_modulo"),
                                     UrlDestino = x.Field<string>("fc_url_destino"),
                                     UrlIcono = x.Field<string>("fc_url_icono"),
                                     Nombre = x.Field<string>("fc_nombre_modulo"),
                                     DbConexion = x.Field<string>("fc_db_conexion"),
                                 }).FirstOrDefault();
                    }
                                        
                    return modulo;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public VMItemModulo RegistrarItemModulo(string nombre,
            int idModulo, string urlIcono, string urlDestino, int idItemPadre, int orden, bool activo)
        {
            try
            {
                VMItemModulo item = new VMItemModulo();
                string error = string.Empty;

                if (idModulo <= 0)
                {
                    error += "- Indica el modulo al que pertenece esta página." + "<br />";
                }

                if (string.IsNullOrEmpty(nombre))
                {
                    error += "- Debes registrar un Nombre." + "<br />";
                }

                if (string.IsNullOrEmpty(error))
                {
                    IDAOItemModulo iDaoModuloApp = new DAOItemModulo();
                    RespuestaBD resp = iDaoModuloApp.RegistrarItemModulo( nombre,
             idModulo,  urlIcono,  urlDestino,  idItemPadre,  orden,  activo);
                    if (resp.EXISTE_ERROR)
                    {
                        throw new Exception(resp.MENSAJE);
                    }
                    else
                    {
                        item = new VMItemModulo() //mapea modelo
                        {                            
                            Activo = activo,
                            Descripcion = nombre,                            
                            IdItemPadre = idItemPadre,
                            IdModulo = idModulo,                            
                            Orden = orden,                            
                            Url = urlDestino,
                            UrlIcono = urlIcono,
                            IdItemModulo = (int)resp.dataSet.Tables[0].Rows[0]["fi_id_item_modulo"]
                        };
                    }
                    return item;
                }
                else
                {
                    throw new Exception(error);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(new Util().ObtenerMsjExcepcion(ex));
            }
        }

        public void EditarItemModulo(int idItem,string nombre,
            int idModulo, string urlIcono, string urlDestino, int idItemPadre, int orden, bool activo)
        {
            try
            {
                VMItemModulo item = new VMItemModulo();
                string error = string.Empty;

                if (idModulo <= 0)
                {
                    error += "- Indica el modulo al que pertenece esta página." + "<br />";
                }

                if (string.IsNullOrEmpty(nombre))
                {
                    error += "- Debes registrar un Nombre." + "<br />";
                }

                if (!string.IsNullOrEmpty(error))
                {
                    IDAOItemModulo iDaoModuloApp = new DAOItemModulo();
                    RespuestaBD resp = iDaoModuloApp.EditarItemModulo(idItem,nombre,
             idModulo, urlIcono, urlDestino, idItemPadre, orden, activo);
                    if (resp.EXISTE_ERROR)
                    {
                        throw new Exception(resp.MENSAJE);
                    }                    
                }
                else
                {
                    throw new Exception(error);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(new Util().ObtenerMsjExcepcion(ex));
            }
        }

    }
}
