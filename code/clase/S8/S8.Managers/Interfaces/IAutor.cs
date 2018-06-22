using S8.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S8.Managers.Interfaces
{
    public interface IAutor
    {
        List<Autor> ObtenerTodosAutores();
    }
}
