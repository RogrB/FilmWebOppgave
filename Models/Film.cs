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
        public string Studio { get; set; }
        public string Bilde { get; set; }
        public int Visninger { get; set; }
        public string Beskrivelse { get; set; }
        public string ReleaseDate { get; set; }
        public int Pris { get; set; }
        public double Gjennomsnitt { get; set; }
        public virtual List<Skuespiller> Skuespillere { get; set; }
        public virtual List<Sjanger> Sjanger { get; set; }
        public virtual List<Stemmer> Stemmer { get; set; }
    }
}
