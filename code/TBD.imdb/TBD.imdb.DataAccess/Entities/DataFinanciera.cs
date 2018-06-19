using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBD.imdb.DataAccess.Entities
{
    public class DataFinanciera: EntityBase
    {
        public string Descripcion { get; set; }
        public string Pais { get; set; }
        public double Monto { get; set; }
    }
}
