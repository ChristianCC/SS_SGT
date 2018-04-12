using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace DAO
{
    public interface ISqlTools
    {
        RespuestaBD ExecuteSP(string storedProcedure, SqlParameter[] parametros = null);

        RespuestaBD ExecuteQuery(string consulta);

        RespuestaBD ExecuteQuery(string consulta, SqlParameter[] parametros);

        RespuestaBD EjecutarConsulta(string consulta, SqlParameter[] parametros, CommandType tipoConsulta);

    }
}
