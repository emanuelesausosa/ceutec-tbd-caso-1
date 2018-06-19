using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBD.imdb.DataAccess;
using TBD.imdb.DataAccess.Entities;
using TBD.imdb.DataAccess.Tables;
using TBD.imdb.Managers.Interfaces;

namespace TBD.imdb.Managers.Factories
{
    public class AutorFactory: IAutor
    {

        private readonly AutorTabla _context;
        private readonly Database _database;
        public AutorFactory()
        {
            _database = new Database();
            _context = new AutorTabla(_database);
        }
        //protected AutorFactory(Database database) : base(database)
        //{
        //    _context = new AutorTabla(database);
        //}

        public IQueryable<Autor> ObtenerTodosActores()
        {
            var data = _context.ObtenerTodosAutores();
            return data;
        }
    }
}
