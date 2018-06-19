using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBD.imdb.DataAccess.Entities;

namespace TBD.imdb.DataAccess.Tables
{
    public class AutorTabla
    {
        private Database _database;
        public AutorTabla(Database database)
        {
            _database = database;
        }

        /// <summary>
        /// obtiene todos los autores de un material
        /// </summary>
        /// <returns></returns>
        public IQueryable<Autor> ObtenerTodosAutores()
        {
            // prepar structura objeto retorno
            List<Autor> autores = new List<Autor>();

            // escribir la consulta
            var commandText = @"SELECT * FROM MERCADEO.AUTOR";

            // llenar parametros

            // obtener objeto
            var rows = _database.Query(commandText, null);

            if (rows == null || rows.Count < 1)
                return null;


            // formatear objeto de retorno
            foreach (var row in rows)
            {
                // inicializa objeto de transferencia iteracion
                var autor = (Autor)Activator.CreateInstance(typeof(Autor));
                autor.Id = string.IsNullOrEmpty(row["ID"]) ? 0 : Int32.Parse(row["ID"]);
                autor.Nombres = row["NOMBRES"];
                autor.Apellidos = row["APELLIDOS"];
                autor.FechaNacimiento = string.IsNullOrEmpty(row["FECHA_NACIMIENTO"]) ? DateTime.Now : DateTime.Parse(row["FECHA_NACIMIENTO"]);
                autor.FechaNacimiento = string.IsNullOrEmpty(row["FECHA_DEFUNCION"]) ? DateTime.Now : DateTime.Parse(row["FECHA_DEFUNCION"]);

                autores.Add(autor);
            }

            return autores.AsQueryable();
        }
    }
}
