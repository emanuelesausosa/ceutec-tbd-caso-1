using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBD.imdb.DataAccess.Entities
{
    public class Produccion: EntityBase
    {
        public string NombreCompania { get; set; }
        public string Pais { get; set; }
        public string UrlWeb { get; set; }
        public string CEO { get; set; }
    }
}
