using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public  interface IDAOTransaccion
    {
        RespuestaBD ObtenerBitacoraTransaccion(int? idSistema, int? idTipoTransaccion, string host, string ip, string dominio, DateTime? fechaInicio, DateTime? fechaFin);

        RespuestaBD RegistrarTransaccion(int idSistema, int idTipoTransaccion, string tipoAcceso,
            string neUsuario, string url,int idTipoApp, string hostName,
            string ipCliente, string mensaje, string dominio, DateTime? inicioProceso,
            DateTime? finDeProceso, int? idAppExt,int? idUsuario);                
    }
}
