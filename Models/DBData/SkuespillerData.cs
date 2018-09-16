using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Graubakken_Filmsjappe.Models.DBData
{
    public class SkuespillerData
    {
        Skuespiller Skuespiller01 = new Skuespiller
        {
            Alder = 34,
            Fornavn = "John",
            Etternavn = "Doe",
            Land = "USA"
        };

        Skuespiller Skuespiller02 = new Skuespiller
        {
            Alder = 21,
            Fornavn = "Lisa",
            Etternavn = "Simpson",
            Land = "USA"
        };

        Skuespiller Skuespiller03 = new Skuespiller
        {
            Alder = 81,
            Fornavn = "Gertrud",
            Etternavn = "Schmidt",
            Land = "Tyskland"
        };

        Skuespiller Skuespiller04 = new Skuespiller
        {
            Alder = 29,
            Fornavn = "Jostein",
            Etternavn = "Sibbestad",
            Land = "Norge"
        };

        Skuespiller Skuespiller05 = new Skuespiller
        {
            Alder = 47,
            Fornavn = "Khandeer",
            Etternavn = "Patel",
            Land = "India"
        };

        Skuespiller Skuespiller06 = new Skuespiller
        {
            Alder = 18,
            Fornavn = "Daffy",
            Etternavn = "Duck",
            Land = "USA"
        };

        Skuespiller Skuespiller07 = new Skuespiller
        {
            Alder = 63,
            Fornavn = "Lise",
            Etternavn = "Furukongle",
            Land = "Norge"
        };

        Skuespiller Skuespiller08 = new Skuespiller
        {
            Alder = 108,
            Fornavn = "Mikke",
            Etternavn = "Mus",
            Land = "USA"
        };

        public List<Skuespiller> HentSkuespillerListe()
        {
            List<Skuespiller> skuespillere = new List<Skuespiller>();
            skuespillere.Add(Skuespiller01);
            skuespillere.Add(Skuespiller02);
            skuespillere.Add(Skuespiller03);
            skuespillere.Add(Skuespiller04);
            skuespillere.Add(Skuespiller05);
            skuespillere.Add(Skuespiller06);
            skuespillere.Add(Skuespiller07);
            skuespillere.Add(Skuespiller08);

            return skuespillere;
        }
    }
}