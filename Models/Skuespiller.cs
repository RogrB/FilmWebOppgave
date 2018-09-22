using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Graubakken_Filmsjappe.Models
{
    public class Skuespiller
    {
        public int id { get; set; }
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public string Land { get; set; }
        public int Alder { get; set; }
        public string Bilde { get; set; }
        public virtual List<Film> Filmer { get; set; }
    }
}