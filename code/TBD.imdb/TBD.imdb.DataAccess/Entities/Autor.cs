using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBD.imdb.DataAccess.Entities
{
    public class Autor: Persona
    {
        public virtual ICollection<Concepto> Conceptos { get; set; }
    }
}
