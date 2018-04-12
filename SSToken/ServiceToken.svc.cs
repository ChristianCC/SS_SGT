using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


using ViewModel;
using Modelo;


namespace SSToken
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceToken" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceToken.svc o ServiceToken.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceToken : IServiceToken
    {
        public RespuestaSesion ValidarToken(string token)
        {
            try
            {
                return new NegocioSistema().ValidarToken(token);
            }
            catch (Exception ex)
            {
                ExceptionService exception = new ExceptionService()
                {
                    Mensaje = ex.Message,
                    Operacion = "Validar token."
                };
                throw new FaultException<ExceptionService>(exception);
            }
        }

        public RespuestaSesion ValidarAcceso(string url,string usuario)
        {
            try
            {
                return new NegocioSistema().ValidarAcceso(url,usuario);
            }
            catch (Exception ex)
            {
                ExceptionService exception = new ExceptionService()
                {
                    Mensaje = ex.Message,
                    Operacion = "Validar acceso."
                };
                throw new FaultException<ExceptionService>(exception);
            }
        }

        public void CerrarSesion(string usuario)
        {
            try
            {
                new NegocioSistema().CerrarSesion(usuario);
            }
            catch (Exception ex)
            {
                ExceptionService exception = new ExceptionService()
                {
                    Mensaje = ex.Message,
                    Operacion = "Cerrar sesión."
                };
                throw new FaultException<ExceptionService>(exception);
            }
        }
    }
}
