using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBD.imdb.DataAccess;

namespace TBD.imdb.Managers
{
    public abstract class Manager
    {
        private readonly Database _database;        

        protected Manager(Database database)
        {
            _database = database;
        }
    }
}
