using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Graubakken_Filmsjappe.Models
{
    public class Stemme
    {
        public int id { get; set; }
        public int AntallStjerner { get; set; }
        public KundeDB Kunde { get; set; }
        public virtual List<Film> Filmer { get; set; }
    }
}
