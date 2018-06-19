using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBD.imdb.DataAccess.Entities;

namespace TBD.imdb.Managers.Interfaces
{
    public interface IAutor
    {
        IQueryable<Autor> ObtenerTodosActores();
    }
}
