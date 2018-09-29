using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Graubakken_Filmsjappe.Models
{ 
    public class Kunde
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Fornavn må oppgis")]
        public string Fornavn { get; set; }

        [Required(ErrorMessage = "Etternavn må oppgis")]
        public string Etternavn { get; set; }

        [Required(ErrorMessage = "Brukernavn må oppgis")]
        public string Brukernavn { get; set; }

        [Required(ErrorMessage = "Passord må oppgis")]
        //[RegularExpression(@"^ ([a - zA - Z0 - 9@*#]{8,*})$", ErrorMessage = "Passord må være minst 8 bokstaver eller tall, og kan ikke inneholde spesialtegn")]
        public string Passord { get; set; }


        [Required(ErrorMessage = "Kortinfo må oppgis")]
        [RegularExpression(@"[0-9]{12,19}", ErrorMessage = "Kredittkort må være mellom 12 og 19 siffer")]
        [Display(Name = "Kredittkort")]
        public long Kort { get; set; }

        public virtual List<Film> Filmer { get; set; }
        public virtual List<Stemmer> Stemmer { get; set; }
    }

    public class KundeDB
    {
        public int id { get; set; }
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public string Brukernavn { get; set; }
        public byte[] Passord { get; set; }
        public string Salt { get; set; }
        public long Kort { get; set; }
        public virtual List<Film> Filmer { get; set; }
        public virtual List<Stemmer> Stemmer { get; set; }
    }
}

/*
[Display(Name = "Postnr")]
[Required(ErrorMessage = "Postnr må oppgis")]
[RegularExpression(@"[0-9]{4}", ErrorMessage = "Postnr må være 4 siffer")] 
*/