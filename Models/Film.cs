using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Graubakken_Filmsjappe.Models
{
    public class Film
    {
        public int id { get; set; }
        public string Navn { get; set; }
        public int Produksjonsår { get; set; }
        public string Kontinent { get; set; }
        public string Sjanger1 { get; set; }
        public string Sjanger2 { get; set; }
        public string Studio { get; set; }
        public string Bilde { get; set; }
        public int Visninger { get; set; }
        public string Beskrivelse { get; set; }
        public DateTime ReleaseDate { get; set; }
        public virtual List<Skuespiller> Skuespillere { get; set; }
        public virtual List<Stemmer> Stemmer { get; set; }
    }
}