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
using ViewModel.Catalogo._TipoApp;
using ViewModel.Catalogo._Transaccion;
using Tools;
using ViewModel.Catalogo._TipoTransaccion;
using ViewModel.Catalogo._Acceso;
using ViewModel.Catalogo._Error;

namespace Modelo
{
    public class NegocioBitacora
    {
        public List<VMTipoApp> ObtenerTipoDeApp(bool? activo)
        {
            try
            {
                IDAOTipoApp iDaoTipo = new DAOTipoApp();
                RespuestaBD resp = iDaoTipo.ObtenerTiposApp(null,activo);
                if (resp.EXISTE_ERROR)
                {
                    throw new Exception(resp.MENSAJE);
                }
                else
                {
                    List<VMTipoApp> lista = new List<VMTipoApp>();
                    if (resp.dataSet.Tables.Count > 0)
                    {
                        DataTable datos = resp.dataSet.Tables[0];
                        lista = (from x in datos.AsEnumerable()
                                 select new VMTipoApp()
                                 {
                                     Descripcion = x.Field<string>("fc_descripcion"),
                                     IdTipoApp = x.Field<int>("fi_id_tipo_app"),
                                     Activo = x.Field<bool>("fl_activo")                                     
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

        public List<VMTipoApp> ObtenerListaTipoDeApp()
        {
            try
            {
                IDAOTipoApp iDaoTipo = new DAOTipoApp();
                RespuestaBD resp = iDaoTipo.ObtenerListaTipoApp();
                if (resp.EXISTE_ERROR)
                {
                    throw new Exception(resp.MENSAJE);
                }
                else
                {
                    List<VMTipoApp> lista = new List<VMTipoApp>();
                    if (resp.dataSet.Tables.Count > 0)
                    {
                        DataTable datos = resp.dataSet.Tables[0];
                        lista = (from x in datos.AsEnumerable()
                                 select new VMTipoApp()
                                 {
                                     Descripcion = x.Field<string>("fc_descripcion"),
                                     IdTipoApp = x.Field<int>("fi_id_tipo_app"),
                                     Activo = x.Field<bool>("fl_activo")
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

        public VMTipoApp ObtenerInfoTipoDeApp(int idTipoApp)
        {
            try
            {
                IDAOTipoApp iDaoTipo = new DAOTipoApp();
                RespuestaBD resp = iDaoTipo.ObtenerTiposApp(idTipoApp);
                if (resp.EXISTE_ERROR)
                {
                    throw new Exception(resp.MENSAJE);
                }
                else
                {
                    VMTipoApp objeto = new VMTipoApp();
                    if (resp.dataSet.Tables.Count > 0)
                    {
                        DataTable datos = resp.dataSet.Tables[0];
                        objeto = (from x in datos.AsEnumerable()
                                 select new VMTipoApp()
                                 {
                                     Descripcion = x.Field<string>("fc_descripcion"),
                                     IdTipoApp = x.Field<int>("fi_id_tipo_app"),
                                     Activo = x.Field<bool>("fl_activo")
                                 }).FirstOrDefault();
                    }
                    return objeto;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(new Util().ObtenerMsjExcepcion(ex));
            }
        }

        public List<VMTransaccion> ObtenerBitacoraTransaccion(int? idSistema, int? idTipoTransaccion, string host, string ip, string dominio, DateTime? fechaInicio, DateTime? fechaFin)
        {
            try
            {
                IDAOTransaccion iDao = new DAOTransaccion();
                RespuestaBD resp = iDao.ObtenerBitacoraTransaccion(idSistema, idTipoTransaccion, host, ip, dominio, fechaInicio, fechaFin);
                if (resp.EXISTE_ERROR)
                {
                    throw new Exception(resp.MENSAJE);
                }
                else
                {
                    List<VMTransaccion> lista = new List<VMTransaccion>();
                    if (resp.dataSet.Tables.Count > 0)
                    {
                        DataTable datos = resp.dataSet.Tables[0];
                        lista = (from x in datos.AsEnumerable()
                                 select new VMTransaccion()
                                  {
                                      Dominio = x.Field<string>("fc_dominio"),
                                      FechaFinProceso = x.Field<DateTime?>("fd_fecha_fin_proceso"),
                                      FechaInicioProceso = x.Field<DateTime?>("fd_fecha_inicio_proceso"),
                                      FechaRegistro = x.Field<DateTime>("fd_fecha_sistema"),
                                      Hostname = x.Field<string>("fc_hostname"),
                                      IdAppExt = x.Field<int?>("fi_id_app"),
                                      IdSistema = x.Field<int>("fi_id_sistema"),
                                      IdTipoApp = x.Field<int>("fi_id_tipo_app"),
                                      IdTipoTransaccion = x.Field<int>("fi_id_tipo_transaccion"),
                                      IdUsuario = x.Field<int?>("fi_id_usuario"),
                                      IpClient = x.Field<string>("fc_ipclient"),
                                      Mensaje = x.Field<string>("fc_mensaje"),
                                      Neusuario = x.Field<string>("fc_neusuario"),
                                      Url = x.Field<string>("fc_url"),
                                      NombreSistema  = x.Field<string>("fc_nombre_sistema"),
                                      NombreTipoTransaccion = x.Field<string>("descTransaccion"),
                                       NombreTipoAplicacion = x.Field<string>("descTipoApp"),
                                      TipoAcceso = x.Field<string>("fc_tipo_acceso")

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


        public void RegistrarTransaccion(int idSistema, int idTipoTransaccion, string tipoAcceso,
            string neUsuario, string url, int idTipoApp, string hostName,
            string ipCliente, string mensaje, string dominio, DateTime? inicioProceso,
            DateTime? finDeProceso, int? idAppExt, int? idUsuario)
        {
            try
            {
                IDAOTransaccion iDao = new DAOTransaccion();
                RespuestaBD resp = iDao.RegistrarTransaccion(idSistema,  idTipoTransaccion,tipoAcceso,
                 neUsuario,  url,  idTipoApp,  hostName,
                 ipCliente,  mensaje,  dominio,  inicioProceso,
                 finDeProceso,  idAppExt,  idUsuario);

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

        public List<VMTipoTransaccion> ObtenerTipoTrensaccion(int? id, int? status)
        {
            try
            {
                IDAOTipoTransaccion iDAOTipoTransaccion = new DAOTipoTransaccion();
                RespuestaBD resp = iDAOTipoTransaccion.ObtenerTipoTransaccion(id, status);
                if (resp.EXISTE_ERROR)
                {
                    throw new Exception(resp.MENSAJE);
                }
                else
                {
                    List<VMTipoTransaccion> lista = new List<VMTipoTransaccion>();
                    if (resp.dataSet.Tables.Count > 0)
                    {
                        DataTable datos = resp.dataSet.Tables[0];
                        lista = (from x in datos.AsEnumerable()
                                 select new VMTipoTransaccion()
                                 {
                                     IdTipoTransaccion = x.Field<int>("fi_id_tipo_transaccion"),
                                     Descripcion = x.Field<string>("fc_descripcion"),
                                     Estatus = x.Field<bool>("fl_activo"),
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

        public VMTipoTransaccion RegistrarTipoTrensaccion(bool status, string descripcion)
        {
            try
            {
                string error = string.Empty;
                if (string.IsNullOrEmpty(descripcion))
                {
                    error += "- Debes registrar una descripcion." + "<br />";
                }
                if (string.IsNullOrEmpty(error))
                {
                    VMTipoTransaccion TipoTransaccion = new VMTipoTransaccion();
                    IDAOTipoTransaccion iDAOTipoTransaccion = new DAOTipoTransaccion();
                    RespuestaBD resp = iDAOTipoTransaccion.RegistrarTipoTransaccion(status, descripcion);
                    if (resp.EXISTE_ERROR)
                    {
                        throw new Exception(resp.MENSAJE);
                    }
                    else
                    {
                        TipoTransaccion = new VMTipoTransaccion()
                        {
                            Estatus = status,
                            Descripcion = descripcion
                        };
                    }
                    return TipoTransaccion;
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

        public void EditarTipoTransaccion(int id, bool status, string descripcion)
        {
            try
            {
                IDAOTipoTransaccion iDAOTipoTransaccion = new DAOTipoTransaccion();
                RespuestaBD resp = iDAOTipoTransaccion.EditarTipoTransaccion(id, status, descripcion);
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

        public List<VMTipoTransaccion> ObtenerListaTipoTransaccion()
        {
            try
            {
                IDAOTipoTransaccion iDAOTipoTransaccion = new DAOTipoTransaccion();
                RespuestaBD resp = iDAOTipoTransaccion.ObtenerListaTipoTransaccion();
                if (resp.EXISTE_ERROR)
                {
                    throw new Exception(resp.MENSAJE);
                }
                else
                {
                    List<VMTipoTransaccion> lista = new List<VMTipoTransaccion>();
                    if (resp.dataSet.Tables.Count > 0)
                    {
                        DataTable datos = resp.dataSet.Tables[0];
                        lista = (from x in datos.AsEnumerable()
                                 select new VMTipoTransaccion()
                                 {
                                     Descripcion = x.Field<string>("fc_descripcion"),
                                     IdTipoTransaccion = x.Field<int>("fi_id_tipo_transaccion"),
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

        public List<VMAcceso> ObtenerBitacoraAccesos(string idUsuario, string ipUsuario, DateTime? fechaInicio, DateTime? fechaFin)
        {
            try
            {
                IDAOAcceso iDao = new DAOAcceso();
                RespuestaBD resp = iDao.ObtenerBitacoraAccesos(idUsuario,ipUsuario, fechaInicio, fechaFin);
                if (resp.EXISTE_ERROR)
                {
                    throw new Exception(resp.MENSAJE);
                }
                else
                {
                    List<VMAcceso> lista = new List<VMAcceso>();
                    if (resp.dataSet.Tables.Count > 0)
                    {
                        DataTable datos = resp.dataSet.Tables[0];
                        lista = (from x in datos.AsEnumerable()
                                 select new VMAcceso()
                                 {
                                     IdBitacora = x.Field<int>("fi_id_bitacora_acc"),
                                     FechaFinSesion = x.Field<DateTime?>("fd_fecha_cierre"),
                                     FechaInicioSesion = x.Field<DateTime?>("fd_fecha_acceso"),
                                     UsuarioAccesa = x.Field<string>("fc_usuario"),
                                     IpUsuario = x.Field<string>("fc_ip_usuario"),
                                     Sistema = x.Field<string>("fc_sistema_acceso")                                     
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

        public List<VMError> ObtenerBitacoraErrores(DateTime? fechaInicio, DateTime? fechaFin)
        {
            try
            {
                IDAOError iDao = new DAOError();
                RespuestaBD resp = iDao.ObtenerBitacoraErrores( fechaInicio, fechaFin);
                if (resp.EXISTE_ERROR)
                {
                    throw new Exception(resp.MENSAJE);
                }
                else
                {
                    List<VMError> lista = new List<VMError>();
                    if (resp.dataSet.Tables.Count > 0)
                    {
                        DataTable datos = resp.dataSet.Tables[0];
                        lista = (from x in datos.AsEnumerable()
                                 select new VMError()
                                 {
                                     IdBitacora = x.Field<int>("fi_id_bitacora_acc"),
                                     FechaError = x.Field<DateTime>("fd_fecha_error"),
                                     ErrorGenerado = x.Field<string>("fc_error_generado"),
                                     Explorador = x.Field<string>("fc_datos_explorador"),
                                     IdErrorBitacora = x.Field<int>("fi_id_bitacora_error"),
                                     Sistema = x.Field<string>("fc_nombre_sistema"),
                                     StackTrace = x.Field<string>("fc_stack_trace"),
                                     TargetSite = x.Field<string>("fc_target_site"),
                                     VersionSistema = x.Field<string>("fc_version_sistema"),

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
    }
}
