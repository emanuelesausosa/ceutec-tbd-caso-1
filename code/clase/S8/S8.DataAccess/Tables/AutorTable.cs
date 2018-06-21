using S8.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S8.DataAccess.Tables
{
    public class AutorTable
    {
        private Database _database;

        public AutorTable(Database database)
        {
            _database = database;
        }

        public List<Autor> ObtenerTodosActores()
        {
            // inicializar la lista pivote 
            List<Autor> autores = new List<Autor>();

            // escribir el comando de consulta
            string comando = "SELECT * FROM MERCADEO.AUTOR";

            // setear los parametros

            // obtener el objeto
            var rows = _database.Query(comando, null);

            // transformar el objeto
            if (rows == null || rows.Count < 1)
                return null;
            else
                foreach (var row in rows)
                {
                    var autor = (Autor)Activator.CreateInstance(typeof(Autor));
                    autor.Id = string.IsNullOrEmpty(row["ID"]) ? 0 : Int32.Parse(row["ID"]);
                    autor.Nombres = row["NOMBRES"];
                    autor.Apellidos = row["APELLIDOS"];
                    autor.FechaNacimiento = string.IsNullOrEmpty(row["FECHA_NACIMIENTO"]) ? DateTime.Now : DateTime.Parse(row["FECHA_NACIMIENTO"]);
                    autor.FechaDefuncion = string.IsNullOrEmpty(row["FECHA_DEFUNCION"]) ? DateTime.Now : DateTime.Parse(row["FECHA_NACIMIENTO"]);

                    autores.Add(autor);
                }

            // retornar el pivote
            return autores;
        }
    }
}
