using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Graubakken_Filmsjappe.Models.DBData
{
    public class SjangerData
    {
        Sjanger Western = new Sjanger()
        {
            sjanger = "Western"
        };

        Sjanger Action = new Sjanger()
        {
            sjanger = "Action"
        };

        Sjanger Romantikk = new Sjanger()
        {
            sjanger = "Romantikk"
        };

        Sjanger SciFi = new Sjanger()
        {
            sjanger = "Science Fiction"
        };

        Sjanger Krim = new Sjanger()
        {
            sjanger = "Krim"
        };

        Sjanger Drama = new Sjanger()
        {
            sjanger = "Drama"
        };

        Sjanger Dokumentar = new Sjanger()
        {
            sjanger = "Dokumentar"
        };

        Sjanger Eventyr = new Sjanger()
        {
            sjanger = "Eventyr"
        };

        Sjanger Komedie = new Sjanger()
        {
            sjanger = "Komedie"
        };

        Sjanger Animasjon = new Sjanger()
        {
            sjanger = "Animasjon"
        };

        Sjanger Familie = new Sjanger()
        {
            sjanger = "Familie"
        };

        Sjanger Musikal = new Sjanger()
        {
            sjanger = "Musikal"
        };

        public List<Sjanger> HentSjangerListe()
        {
            List<Sjanger> alleSjangere = new List<Sjanger>();
            alleSjangere.Add(Western);
            alleSjangere.Add(Action);
            alleSjangere.Add(Romantikk);
            alleSjangere.Add(SciFi);
            alleSjangere.Add(Krim);
            alleSjangere.Add(Drama);
            alleSjangere.Add(Dokumentar);
            alleSjangere.Add(Eventyr);
            alleSjangere.Add(Komedie);
            alleSjangere.Add(Animasjon);
            alleSjangere.Add(Familie);
            alleSjangere.Add(Musikal);

            return alleSjangere;
        }

    }
}