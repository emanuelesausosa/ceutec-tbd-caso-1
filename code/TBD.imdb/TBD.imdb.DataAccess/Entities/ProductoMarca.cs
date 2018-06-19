using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBD.imdb.DataAccess.Entities
{
    public class ProductoMarca: EntityBase
    {
        public string Descripcion { get; set; }
        public string Marca { get; set; }
        public string Tipo { get; set; }
        public int IdConcepto { get; set; }

        public virtual Concepto Concepto { get; set; }
    }
}
