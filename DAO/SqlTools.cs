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
    public class SqlTools : ISqlTools
    {
        private string CONEXION_ACTUAL = string.Empty;
        public SqlTools(string conexion)
        {
            //Obtener la cadena de conexión del archivo .config
            CONEXION_ACTUAL = ConfigurationManager.AppSettings[conexion];
        }

        public RespuestaBD ExecuteSP(string storedProcedure, SqlParameter[] parametros = null)
        {
            return this.EjecutarConsulta(storedProcedure, parametros, CommandType.StoredProcedure);
        }

        public RespuestaBD ExecuteQuery(string consulta)
        {
            return this.EjecutarConsulta(consulta, null, CommandType.Text);
        }

        public RespuestaBD ExecuteQuery(string consulta, SqlParameter[] parametros)
        {
            return this.EjecutarConsulta(consulta, parametros, CommandType.Text);
        }

        public RespuestaBD EjecutarConsulta(string consulta, SqlParameter[] parametros, CommandType tipoConsulta)
        {
            SqlConnection conn = null;
            RespuestaBD rRes = null;
            SqlDataAdapter adapter = null;

            try
            {
                //Iniciarlizar conexión
                conn = new SqlConnection(CONEXION_ACTUAL);

                //Inicializar objeto para regresar la información
                rRes = new RespuestaBD();
                rRes.dataSet = new DataSet();

                //Abrir conexión
                conn.Open();

                //Inicializar adaptador de datos con la conexión abierta
                adapter = new SqlDataAdapter(consulta, conn);

                //Se indica si se está enviando una consulta directamente o invocando un SP
                adapter.SelectCommand.CommandType = tipoConsulta;
                adapter.SelectCommand.CommandTimeout = 3000;

                //Agregar el párametro de retorno del SP, por defecto es 0 cuando todo salió bien.
                adapter.SelectCommand.Parameters.Add(new SqlParameter() { Direction = ParameterDirection.ReturnValue, Value = 0 });

                //Agregar los parámetros necesarios para la consulta o el SP
                if (parametros != null)
                {
                    foreach (SqlParameter myparam in parametros)
                        adapter.SelectCommand.Parameters.Add(myparam);
                }

                //Ejecutar instrucción el BD
                adapter.Fill(rRes.dataSet);

                //En caso de tener parámetros de salida
                if (parametros != null)
                {
                    foreach (SqlParameter myparam in parametros)
                    {
                        if (myparam.Direction == ParameterDirection.Output)
                        {
                            rRes.AgregarParametro(myparam.ParameterName, myparam.Value);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                try
                {
                    rRes.Error(ex.Message);
                    rRes.respuesta = ex.State.ToString();
                }
                catch(Exception ex2){}
            }
            catch (Exception ex)
            {
                rRes.Error(ex.Message);
            }
            finally
            {
                try
                {

                    //Cerrar conexión
                    if (conn != null)
                    {
                        if (conn.State == ConnectionState.Open)
                        {
                            conn.Close();
                            conn = null;
                        }
                    }

                }
                catch (Exception) { }

                try
                {
                    //Recuperar el valor de regreso del sp
                   // rRes.respuesta = Convert.ToInt32(adapter.SelectCommand.Parameters[0].Value);
                }
                catch (Exception) { }
            }

            return rRes;
        }
    }

    public class RespuestaBD
    {
        private bool existeError;
        private string mensaje;
        public string respuesta;
        private Dictionary<string, object> paramSalida;

        public DataSet dataSet;

        public bool EXISTE_ERROR
        {
            get { return existeError; }
        }

        public string MENSAJE
        {
            get { return mensaje; }
        }

        public RespuestaBD()
        {
            existeError = false;
            mensaje = "ProcesoETL exitoso.";
            respuesta = "0";
            dataSet = null;
            paramSalida = new Dictionary<string, object>();
        }

        //Sustituye el mensaje de éxito por el mensaje de error y activa el indicador de error.
        public void Error(string mensajeError)
        {
            existeError = true;
            mensaje = mensajeError;
        }

        public void AgregarParametro(string nombre, object valor)
        {
            paramSalida.Add(nombre, valor);
        }

        //Para acceder a los párametros de salida se usa el nombre de la instancia y entre corchetes el nombre del parámetro
        //Si se envía un parámetro de salida @pcParametro y la instancia de esta clase se llama rInstancia
        //se obtiene el valor rInstancia["@pcParametro"]
        public object this[string nombre]
        {
            get
            {
                return paramSalida[nombre];
            }
        }
    }
}
