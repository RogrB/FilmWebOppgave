using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Graubakken_Filmsjappe.Models
{ 
    public class Kunde
    {
        public string id { get; set; }
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public string Brukernavn { get; set; }
        public virtual List<Film> Filmer { get; set; }
        public virtual List<Stemmer> Stemmer { get; set; }
    }
}