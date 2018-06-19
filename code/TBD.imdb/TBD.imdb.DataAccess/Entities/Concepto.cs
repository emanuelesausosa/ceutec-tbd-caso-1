using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBD.imdb.DataAccess.Entities
{
    public class Concepto: EntityBase
    {
        public string Titulo { get; set; }
        public string Resenia { get; set; }
        public DateTime FechaLanzamiento { get; set; }
        public string PaisOrigen  { get; set; }
        public string UrlWeb { get; set; }
        public int IdAutor { get; set; }

        public virtual Autor Autor { get; set; }
        public virtual ICollection<ProductoMarca> ProductosMarcas { get; set; }
    }
}
