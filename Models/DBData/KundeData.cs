using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Graubakken_Filmsjappe.Models.DBData
{
    public class KundeData
    {
        KundeDB Kunde1 = new KundeDB
        {
            Fornavn = "Ole",
            Etternavn = "Olsen",
            Brukernavn = "OleOo123",
            Kort = 1234567890123456
        };

        KundeDB Kunde2 = new KundeDB
        {
            Fornavn = "Per",
            Etternavn = "Pettersen",
            Brukernavn = "UglerIMosen",
            Kort = 4566675847561234
        };

        KundeDB Kunde3 = new KundeDB
        {
            Fornavn = "Olga",
            Etternavn = "Petrunia",
            Brukernavn = "Blomst02",
            Kort = 1235521489695852
        };

        KundeDB Kunde4 = new KundeDB
        {
            Fornavn = "Line",
            Etternavn = "Linesen",
            Brukernavn = "LitenOgSint",
            Kort = 6522321478523695
        };

        KundeDB Kunde5 = new KundeDB
        {
            Fornavn = "Donald",
            Etternavn = "Duck",
            Brukernavn = "OnkL_D",
            Kort = 2565859636985214
        };

        KundeDB Kunde6 = new KundeDB
        {
            Fornavn = "Gustav",
            Etternavn = "Bernardsen",
            Brukernavn = "Fanta03",
            Kort = 1236658596985474
        };

        public List<KundeDB> HentKundeListe()
        {
            List<KundeDB> Kunder = new List<KundeDB>();
            Kunder.Add(Kunde1);
            Kunder.Add(Kunde2);
            Kunder.Add(Kunde3);
            Kunder.Add(Kunde4);
            Kunder.Add(Kunde5);
            Kunder.Add(Kunde6);

            return Kunder;
        }

    }
}