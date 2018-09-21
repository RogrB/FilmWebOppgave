using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Graubakken_Filmsjappe.Models
{
    public class Nyhet
    {
        public int id { get; set; }
        public string Tittel { get; set; }
        public string Beskjed { get; set; }
        public DateTime Dato { get; set; }
    }
}