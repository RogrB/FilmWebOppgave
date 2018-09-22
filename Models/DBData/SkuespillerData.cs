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
            Land = "USA",
            Bilde = "Content/images/skuespillere/pexels-photo-1040879.jpeg"
        };

        Skuespiller Skuespiller02 = new Skuespiller
        {
            Alder = 29,
            Fornavn = "Brandon",
            Etternavn = "Simps",
            Land = "England",
            Bilde = "Content/images/skuespillere/pexels-photo-1059180.jpeg"
        };

        Skuespiller Skuespiller03 = new Skuespiller
        {
            Alder = 26,
            Fornavn = "Lisa",
            Etternavn = "Schmidt",
            Land = "Tyskland",
            Bilde = "Content/images/skuespillere/pexels-photo-1162462.jpeg"
        };

        Skuespiller Skuespiller04 = new Skuespiller
        {
            Alder = 29,
            Fornavn = "John",
            Etternavn = "Aboyega",
            Land = "USA",
            Bilde = "Content/images/skuespillere/pexels-photo-1406547.jpeg"
        };

        Skuespiller Skuespiller05 = new Skuespiller
        {
            Alder = 32,
            Fornavn = "Jostein",
            Etternavn = "Sibbestad",
            Land = "Norge",
            Bilde = "Content/images/skuespillere/pexels-photo-220453.jpeg"
        };

        Skuespiller Skuespiller06 = new Skuespiller
        {
            Alder = 26,
            Fornavn = "Paul",
            Etternavn = "Simons",
            Land = "USA",
            Bilde = "Content/images/skuespillere/pexels-photo-249760.jpeg"
        };

        Skuespiller Skuespiller07 = new Skuespiller
        {
            Alder = 30,
            Fornavn = "Danielle",
            Etternavn = "Peters",
            Land = "Irland",
            Bilde = "Content/images/skuespillere/pexels-photo-355178.jpeg"
        };

        Skuespiller Skuespiller08 = new Skuespiller
        {
            Alder = 23,
            Fornavn = "Lisa",
            Etternavn = "Wu",
            Land = "Korea",
            Bilde = "Content/images/skuespillere/pexels-photo-415829.jpeg"
        };

        Skuespiller Skuespiller09 = new Skuespiller
        {
            Alder = 34,
            Fornavn = "Roald",
            Etternavn = "Yrstad",
            Land = "Norge",
            Bilde = "Content/images/skuespillere/pexels-photo-428364.jpeg"
        };

        Skuespiller Skuespiller10 = new Skuespiller
        {
            Alder = 21,
            Fornavn = "Peter",
            Etternavn = "Duncan",
            Land = "Canada",
            Bilde = "Content/images/skuespillere/pexels-photo-555790.png"
        };

        Skuespiller Skuespiller11 = new Skuespiller
        {
            Alder = 23,
            Fornavn = "Elise",
            Etternavn = "Dafran",
            Land = "Sverige",
            Bilde = "Content/images/skuespillere/pexels-photo-610738.jpeg"
        };

        Skuespiller Skuespiller12 = new Skuespiller
        {
            Alder = 18,
            Fornavn = "Bettany",
            Etternavn = "Tren",
            Land = "USA",
            Bilde = "Content/images/skuespillere/pexels-photo-638700.jpeg"
        };

        Skuespiller Skuespiller13 = new Skuespiller
        {
            Alder = 24,
            Fornavn = "Zhi",
            Etternavn = "Ruo",
            Land = "Kina",
            Bilde = "Content/images/skuespillere/pexels-photo-681637.jpeg"
        };

        Skuespiller Skuespiller14 = new Skuespiller
        {
            Alder = 23,
            Fornavn = "Anthony",
            Etternavn = "Travis",
            Land = "England",
            Bilde = "Content/images/skuespillere/pexels-photo-697509.jpeg"
        };

        Skuespiller Skuespiller15 = new Skuespiller
        {
            Alder = 46,
            Fornavn = "Chris",
            Etternavn = "Voigt",
            Land = "USA",
            Bilde = "Content/images/skuespillere/pexels-photo-736715.jpeg"
        };

        Skuespiller Skuespiller16 = new Skuespiller
        {
            Alder = 25,
            Fornavn = "Margaret",
            Etternavn = "Splint",
            Land = "England",
            Bilde = "Content/images/skuespillere/pexels-photo-762020.jpeg"
        };

        Skuespiller Skuespiller17 = new Skuespiller
        {
            Alder = 27,
            Fornavn = "Rennie",
            Etternavn = "Asher",
            Land = "Haiti",
            Bilde = "Content/images/skuespillere/pexels-photo-935969.jpeg"
        };

        Skuespiller Skuespiller18 = new Skuespiller
        {
            Alder = 26,
            Fornavn = "Ava",
            Etternavn = "Jones",
            Land = "USA",
            Bilde = "Content/images/skuespillere/pexels-photo-952005.jpeg"
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
            skuespillere.Add(Skuespiller09);
            skuespillere.Add(Skuespiller10);
            skuespillere.Add(Skuespiller11);
            skuespillere.Add(Skuespiller12);
            skuespillere.Add(Skuespiller13);
            skuespillere.Add(Skuespiller14);
            skuespillere.Add(Skuespiller15);
            skuespillere.Add(Skuespiller16);
            skuespillere.Add(Skuespiller17);
            skuespillere.Add(Skuespiller18);

            return skuespillere;
        }
    }
}