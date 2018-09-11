using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Graubakken_Filmsjappe.Models
{
    public class DBInit : DropCreateDatabaseAlways<DBContext>
    {
        protected override void Seed(DBContext context)
        {
            /*
            var nyKunde = new Kunde
            {
                Navn = "Ole Hansen"
            };

            var nyOrdre = new Ordre
            {
                Dato = "23.05.2017"
            };

            var nyVare1 = new Vare
            {
                Pris = 2.34,
                Navn = "Mutter 3mm"
            };
            var nyVare2 = new Vare
            {
                Pris = 3.34,
                Navn = "Mutter 4mm"
            };

            var nyOrdreLinje1 = new OrdreLinje
            {
                Vare = nyVare1,
                Antall = 100
            };

            var nyOrdreLinje2 = new OrdreLinje
            {
                Vare = nyVare2,
                Antall = 50
            };

            // legg ordrelinjene inn i den nye ordren
            // det eksisterer ingen Liste av ordrelinjer i ordren fra før av så den må opprettes!
            var nyeOrdreLinjer = new List<OrdreLinje>();
            nyeOrdreLinjer.Add(nyOrdreLinje1);
            nyeOrdreLinjer.Add(nyOrdreLinje2);

            nyOrdre.OrdreLinjer = nyeOrdreLinjer;

            // det eksisterer ingen Liste av ordre i kunden så den må opprettes først!
            var nyeOrdre = new List<Ordre>();
            nyeOrdre.Add(nyOrdre);
            nyKunde.Ordre = nyeOrdre;

            // legg hele kunden med alle dataene inn i databasen
            context.Kunde.Add(nyKunde);
            base.Seed(context);
            */
        }
    }
}