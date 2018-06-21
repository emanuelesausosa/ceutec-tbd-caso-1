using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace S8.DataAccess
{
    public class Database : IDisposable
    {
        private SqlConnection _connection;

        public Database()
            : this("ImdbConnection")
        {

        }

        /// <summary>
        /// Establece una conexion con la base de datos
        /// </summary>
        /// <param name="connectionStringName"></param>
        public Database(string connectionStringName)
        {
            var connectionStr = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
            _connection = new SqlConnection(connectionStr);
        }


        /// <summary>
        /// Retorna un solo valor escalar
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public object QueryValue(string commandText, IEnumerable parameters)
        {
            object result;

            if (string.IsNullOrEmpty(commandText))
            {
                throw new ArgumentException("Command text cannot be null or empty.");
            }

            try
            {
                EnsureConnectionOpen();
                var command = CreateCommand(commandText, parameters);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();
                result = command.Parameters["PA_CODIGO_ERROR"].Value;
            }
            finally
            {
                EnsureConnectionClosed();
            }

            return result;
        }


        /// <summary>
        /// Hace una consulta a la base y retorna un conjuento de pares ordenados
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public List<Dictionary<string, string>> Query(string commandText, IEnumerable parameters)
        {
            List<Dictionary<string, string>> rows;
            if (string.IsNullOrEmpty(commandText))
            {
                throw new ArgumentException("Command text cannot be null or empty.");
            }

            try
            {
                EnsureConnectionOpen();
                var command = CreateCommand(commandText, parameters);
                command.CommandTimeout = 30;
                using (var reader = command.ExecuteReader())
                {
                    rows = new List<Dictionary<string, string>>();
                    while (reader.Read())
                    {
                        var row = new Dictionary<string, string>();
                        for (var i = 0; i < reader.FieldCount; i++)
                        {
                            var columnName = reader.GetName(i);
                            var columnValue = reader.IsDBNull(i) ? null : reader.GetValue(i).ToString();
                            row.Add(columnName, columnValue);
                        }
                        rows.Add(row);
                    }
                }
            }
            finally
            {
                EnsureConnectionClosed();
            }

            return rows;
        }

        /// <summary>
        /// Intento de abrir una conexion
        /// </summary>
        private void EnsureConnectionOpen()
        {
            var retries = 3;
            if (_connection.State == ConnectionState.Open)
            {
                return;
            }
            while (retries >= 0 && _connection.State != ConnectionState.Open)
            {
                _connection.Open();
                retries--;
                Thread.Sleep(30);
            }
        }

        /// <summary>
        /// se asegura de cerrar la conexion
        /// </summary>
        private void EnsureConnectionClosed()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }


        /// <summary>
        /// metodo que crea un commando sql para ser ejecutado
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private SqlCommand CreateCommand(string commandText, IEnumerable parameters)
        {
            var command = _connection.CreateCommand();
            command.CommandText = commandText;
            command.Parameters.Clear();
            AddParameters(command, parameters);

            return command;
        }

        /// <summary>
        /// agrega parametros al comando
        /// </summary>
        /// <param name="command"></param>
        /// <param name="parameters"></param>
        private static void AddParameters(SqlCommand command, IEnumerable parameters)
        {
            if (parameters == null) return;

            foreach (var parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }
        }

        /// <summary>
        /// Helper method to return query a string value 
        /// </summary>
        /// <param name="commandText">The Oracle query to execute</param>
        /// <param name="parameters">Parameters to pass to the Oracle query</param>
        /// <returns>The string value resulting from the query</returns>
        public string GetStrValue(string commandText, IEnumerable parameters)
        {
            var value = QueryValue(commandText, parameters) as string;
            return value;
        }

        /// <summary>
        /// si se desea caducar la conexion
        /// </summary>
        public void Dispose()
        {
            if (_connection == null) return;

            _connection.Dispose();
            _connection = null;
        }
    }

}
