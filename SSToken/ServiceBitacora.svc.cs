using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using ViewModel;
using ViewModel.Catalogo;
using ViewModel.Catalogo._TipoApp;
using ViewModel.Catalogo._Transaccion;
using Modelo;
using ViewModel.Catalogo._TipoTransaccion;
using ViewModel.Catalogo._Acceso;
using ViewModel.Catalogo._Error;

namespace SSToken
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceBitacora" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceBitacora.svc o ServiceBitacora.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceBitacora : IServiceBitacora
    {
        public IEnumerable<VMTipoApp> ObtenerTiposApp(bool? activo)
        {
            try
            {
                return new NegocioBitacora().ObtenerTipoDeApp(activo);
            }
            catch (Exception ex)
            {
                ExceptionService exception = new ExceptionService()
                {
                    Mensaje = ex.Message,
                    Operacion = "Catálogo de tipos de App."
                };
                throw new FaultException<ExceptionService>(exception);
            }
        }


        public IEnumerable<VMTipoApp> ObtenerListaTipoApp()
        {
            try
            {
                return new NegocioBitacora().ObtenerListaTipoDeApp();
            }
            catch (Exception ex)
            {
                ExceptionService exception = new ExceptionService()
                {
                    Mensaje = ex.Message,
                    Operacion = "Lista de tipos de App."
                };
                throw new FaultException<ExceptionService>(exception);
            }
        }

        public IEnumerable<VMTransaccion> ObtenerTransacciones(int? idSistema, int? idTipoTransaccion, string host, string ip, string dominio, DateTime? fechaInicio, DateTime? fechaFin)
        {
            try
            {
                return new NegocioBitacora().ObtenerBitacoraTransaccion( idSistema,  idTipoTransaccion,  host,  ip,  dominio,  fechaInicio,  fechaFin);
            }
            catch (Exception ex)
            {
                ExceptionService exception = new ExceptionService()
                {
                    Mensaje = ex.Message,
                    Operacion = "Transacciones."
                };
                throw new FaultException<ExceptionService>(exception);
            }
        }

        public void RegistrarTransaccion(int idSistema, int idTipoTransaccion,string tipoAcceso,
            string neUsuario, string url, int idTipoApp, string hostName,
            string ipCliente, string mensaje, string dominio, DateTime? inicioProceso,
            DateTime? finDeProceso, int? idAppExt, int? idUsuario)
        {
            try
            {
                new NegocioBitacora().RegistrarTransaccion(idSistema, idTipoTransaccion,tipoAcceso,
                             neUsuario,  url,  idTipoApp,  hostName,
                             ipCliente,  mensaje,  dominio,  inicioProceso,
                             finDeProceso,  idAppExt,  idUsuario);
            }
            catch (Exception ex)
            {
                ExceptionService exception = new ExceptionService()
                {
                    Mensaje = ex.Message,
                    Operacion = "Registro de Transacción."
                };
                throw new FaultException<ExceptionService>(exception);
            }
        }

        #region Catalogo TipoTransaccion

        public VMTipoTransaccion RegistrarTipoTrensaccion(bool status, string descripcion)
        {
            try
            {
                return new NegocioBitacora().RegistrarTipoTrensaccion(status, descripcion);
            }
            catch (Exception ex)
            {
                ExceptionService exception = new ExceptionService()
                {
                    Mensaje = ex.Message,
                    Operacion = "Registro de Tipo de Transaccion."
                };
                throw new FaultException<ExceptionService>(exception);
            }
        }
        public IEnumerable<VMTipoTransaccion> ObtenerCatalogoTipoTransaccion(int? id, int? status)
        {
            try
            {
                return new NegocioBitacora().ObtenerTipoTrensaccion(id, status);
            }
            catch (Exception ex)
            {
                ExceptionService exception = new ExceptionService()
                {
                    Mensaje = ex.Message,
                    Operacion = "Catálogo Tipo de Transaccion."
                };
                throw new FaultException<ExceptionService>(exception);
            }
        }
        public void EditarTipoTransaccion(int id, bool status, string descripcion)
        {
            try
            {
                new NegocioBitacora().EditarTipoTransaccion(id, status, descripcion);
            }
            catch (Exception ex)
            {
                throw new FaultException<ExceptionService>(new ExceptionService()
                {
                    Mensaje = ex.Message,
                    ErrorCode = "1"
                });

            }
        }
        public IEnumerable<VMTipoTransaccion> ObtenerListaTipoTransaccion()
        {
            try
            {
                return new NegocioBitacora().ObtenerListaTipoTransaccion();
            }
            catch (Exception ex)
            {
                ExceptionService exception = new ExceptionService()
                {
                    Mensaje = ex.Message,
                    Operacion = "Lista Tipo de Transaccion."
                };
                throw new FaultException<ExceptionService>(exception);
            }
        }
        #endregion Catalogo TipoTransaccion

        public List<VMAcceso> ObtenerBitacoraAccesos(string idUsuario, string ipUsuario, DateTime? fechaInicio, DateTime? fechaFin)
        {
            try
            {
                return new NegocioBitacora().ObtenerBitacoraAccesos(idUsuario, ipUsuario, fechaInicio, fechaFin);
            }
            catch (Exception ex)
            {
                ExceptionService exception = new ExceptionService()
                {
                    Mensaje = ex.Message,
                    Operacion = "Bitacora de accesos."
                };
                throw new FaultException<ExceptionService>(exception);
            }
        }

        public List<VMError> ObtenerBitacoraErrores( DateTime? fechaInicio, DateTime? fechaFin)
        {
            try
            {
                return new NegocioBitacora().ObtenerBitacoraErrores( fechaInicio, fechaFin);
            }
            catch (Exception ex)
            {
                ExceptionService exception = new ExceptionService()
                {
                    Mensaje = ex.Message,
                    Operacion = "Bitacora de errores."
                };
                throw new FaultException<ExceptionService>(exception);
            }
        }

        
    }

}
