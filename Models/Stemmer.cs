using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Graubakken_Filmsjappe.Models
{
    public class Stemmer
    {
        public int id { get; set; }
        public int AntallStjerner { get; set; }
        public virtual List<Kunde> Kunder { get; set; }
        public virtual List<Film> Filmer { get; set; }
    }
}
