using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Graubakken_Filmsjappe.Models.DBData
{
    public class NyhetsData
    {
        Nyhet nyhet01 = new Nyhet
        {
            Tittel = "Velkommen til Grautbakken Filmsjappe!",
            Beskjed = "Grautbakken Filmsjappe lanserer sin nye hjemmeside hvor du kan laste ned filmer direkte",
            Dato = DateTime.Now.AddDays(-10)
        };

        Nyhet nyhet02 = new Nyhet
        {
            Tittel = "\"Western\" Sjanger har nå blitt opprettet",
            Beskjed = "Vi har nå opprettet et eget utvalg av western filmer. Finn frem en pose popcorn og kos deg med en actionfylt kveld",
            Dato = DateTime.Now.AddDays(-5)
        };

        Nyhet nyhet03 = new Nyhet
        {
            Tittel = "Tilbud på Animasjonsfilmer ut Oktober",
            Beskjed = "Vi har nå en kampanje på Animasjonsfilmer ut Oktober!",
            Dato = DateTime.Now
        };

        public List<Nyhet> HentNyhetsListe()
        {
            List<Nyhet> nyheter = new List<Nyhet>();
            nyheter.Add(nyhet01);
            nyheter.Add(nyhet02);
            nyheter.Add(nyhet03);

            return nyheter;
        }
    }
}