using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Graubakken_Filmsjappe.Models
{
    public class Sjanger
    {
        public int id { get; set; }
        public string sjanger { get; set; }
        public int antall { get; set; }
        public virtual List<Film> Filmer { get; set; }
    }
}
