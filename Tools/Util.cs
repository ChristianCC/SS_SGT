using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public class Util
    {
        public string ObtenerMsjExcepcion(Exception ex)
        {
            if (ex.InnerException == null)
            {
                return ex.Message;
            }
            else
            {
                return ObtenerMsjExcepcion(ex.InnerException);
            }
        }
    }
}
