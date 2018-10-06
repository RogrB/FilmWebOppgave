using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Graubakken_Filmsjappe.Models
{
    public class Kommentar
    {
        public int id { get; set; }
        public virtual KundeDB Kunde { get; set; }
        public string Melding { get; set; }
        public string Dato { get; set; }
    }
}