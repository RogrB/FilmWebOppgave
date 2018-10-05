using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Graubakken_Filmsjappe.Models
{
    public class Søkeresultat
    {
        public string Navn { get; set; }
        public string Bilde { get; set; }
        public int id { get; set; }
        public string Type { get; set; }
    }
}