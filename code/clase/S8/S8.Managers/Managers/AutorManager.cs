using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S8.DataAccess;
using S8.DataAccess.Tables;
using S8.DataAccess.Entities;

namespace S8.Managers.Managers
{
    public class AutorManager
    {
        private Database _database;
        private AutorTable _context;
        
        public AutorManager()
        {
            _database = new Database();
            _context = new AutorTable(_database);
        }

        public List<Autor> GetAllAutores()
        {
            var data = _context.ObtenerTodosActores();
            return data;
        }
    }
}
