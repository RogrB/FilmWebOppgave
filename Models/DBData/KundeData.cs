using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Graubakken_Filmsjappe.Models.DBData
{
    public class KundeData
    {
        Kunde Kunde1 = new Kunde
        {
            Fornavn = "Ole",
            Etternavn = "Olsen",
            Brukernavn = "OleOo123"
        };

        Kunde Kunde2 = new Kunde
        {
            Fornavn = "Per",
            Etternavn = "Pettersen",
            Brukernavn = "UglerIMosen"
        };

        Kunde Kunde3 = new Kunde
        {
            Fornavn = "Olga",
            Etternavn = "Petrunia",
            Brukernavn = "Blomst02"
        };

        Kunde Kunde4 = new Kunde
        {
            Fornavn = "Line",
            Etternavn = "Linesen",
            Brukernavn = "LitenOgSint"
        };

        Kunde Kunde5 = new Kunde
        {
            Fornavn = "Donald",
            Etternavn = "Duck",
            Brukernavn = "OnkL_D"
        };

        Kunde Kunde6 = new Kunde
        {
            Fornavn = "Gustav",
            Etternavn = "Bernardsen",
            Brukernavn = "Fanta03"
        };

        public List<Kunde> HentKundeListe()
        {
            List<Kunde> kunder = new List<Kunde>();
            kunder.Add(Kunde1);
            kunder.Add(Kunde2);
            kunder.Add(Kunde3);
            kunder.Add(Kunde4);
            kunder.Add(Kunde5);
            kunder.Add(Kunde6);

            return kunder;
        }

    }
}