using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    /// <summary>
    /// Esta clase contiene el enumerador para todas las conexiones a base de datos.
    /// Cada conexion de defin en el webconfig del proyecto ERPWEB
    /// </summary>
    public class Conexion
    {
        /// <summary>
        /// Esta clase contiene cada clave de conexiondefinida en el archivo web config.
        /// Para obtener el nombre de la clave usar el metodo ToString(), caso contrario, lo que devuelve es
        /// el número.
        /// </summary>
        public static class DBConexion
        {
            // Cada nuevo elemento se enumera automaticamente
            public enum conexiones : int { conn_SEG = 1, conn_SERV = 2 };
        }
    }
}
