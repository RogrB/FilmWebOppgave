using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Graubakken_Filmsjappe.Models
{
    public class DBInit : DropCreateDatabaseAlways<DBContext>
    {
        // Oppretter DBData Objekter
        DBData.FilmData filmDB = new DBData.FilmData();
        DBData.KundeData kundeDB = new DBData.KundeData();
        DBData.NyhetsData nyhetsDB = new DBData.NyhetsData();
        DBData.SkuespillerData skuespillerDB = new DBData.SkuespillerData();
        
        List<KundeDB> alleKunder;
        List<Nyhet> alleNyheter;
        List<Skuespiller> alleSkuespillere;
        List<Film> alleFilmer;
        public DBInit()
        {
            // Henter inn lister over all DB Data
            alleKunder = kundeDB.HentKundeListe();
            alleNyheter = nyhetsDB.HentNyhetsListe();
            alleSkuespillere = skuespillerDB.HentSkuespillerListe();
            alleFilmer = filmDB.HentFilmListe();
        }

        protected override void Seed(DBContext context)
        {
            /*
            // Kaller metode for å legge skuespillere inn i filmene
            SettSkuespillereInnIFilmer();

            // Kaller metode for å legge filmer inn i Kunde-objekter (filmer som kunder har sett)
            SettFilmerInnIKundeObjekt();

            // Legger filmene inn i databasen
            for (int i = 0; i < alleFilmer.Count(); i++)
            {
                context.Filmer.Add(alleFilmer[i]);
            }

            // Legger skuespillerne inn i databasen
            for (int i = 0; i < alleSkuespillere.Count(); i++)
            {
                context.Skuespillere.Add(alleSkuespillere[i]);
            }

            // Legger kundene inn i databasen
            for (int i = 0; i < alleKunder.Count(); i++)
            {
                context.Kunder.Add(alleKunder[i]);
            }

            // Legger nyheter inn i databasen
            for (int i = 0; i < alleNyheter.Count(); i++)
            {
                context.Nyheter.Add(alleNyheter[i]);
            }
            */
            // Legger til en ny skuespiller "manuelt"
            var NySkuespiller = new Skuespiller
            {
                Fornavn = "Ole",
                Etternavn = "Olsen",
                Alder = 26,
                Land = "Norge"
            };
            List<Film> noenFilmer = new List<Film>();
            noenFilmer.Add(alleFilmer[3]);
            noenFilmer.Add(alleFilmer[7]);
            NySkuespiller.Filmer = noenFilmer;
            context.Skuespillere.Add(NySkuespiller);


            base.Seed(context);
        }

        // Metode som setter et tilfeldig utvalg av skuespillere fra skuespiller-Datasettet inn i hver enkelt film
        public List<Film> SettSkuespillereInnIFilmer()
        {
            Random TilfeldigTall = new Random();
            for (int i = 0; i < alleFilmer.Count(); i++)
            {
                alleFilmer[i].Skuespillere = new List<Skuespiller>();
                int AntallSkuespillere = TilfeldigTall.Next(2, 6); // Antall skuespillere i denne filmen
                List<int> BrukteSkuespillere = new List<int>(); // Liste over skuespillere som allerede har blitt lagt til i filmen
                for (int j = 0; j < AntallSkuespillere; j++)
                {
                    int TilfeldigSkuespiller = FinnNySkuespiller(BrukteSkuespillere);
                    BrukteSkuespillere.Add(TilfeldigSkuespiller);
                    alleFilmer[i].Skuespillere.Add(alleSkuespillere[TilfeldigSkuespiller]);
                }
            }
            return alleFilmer;
        }

        // Metode som finner en ny skuespiller - for å sikre at den samme skuespilleren ikke blir lagt til en film flere ganger
        public int FinnNySkuespiller(List<int> BrukteSkuespillere)
        {
            Random TilfeldigTall = new Random();
            bool UnikSkuespiller = true;
            int Skuespiller = 0;
            while(UnikSkuespiller)
            {
                Skuespiller = TilfeldigTall.Next(0, alleSkuespillere.Count());
                UnikSkuespiller = BrukteSkuespillere.Contains(Skuespiller);
            }
            return Skuespiller;
        }

        // Metode som setter et tilfeldig utvalg av filmer inn i kunde-objektene
        public List<KundeDB> SettFilmerInnIKundeObjekt()
        {
            Random TilfeldigTall = new Random();
            for (int i = 0; i < alleKunder.Count(); i++)
            {
                alleKunder[i].Filmer = new List<Film>();
                int AntallFilmer = TilfeldigTall.Next(0, alleFilmer.Count());
                for (int j = 0; j < AntallFilmer; j++)
                {
                    int TilfeldigFilm = TilfeldigTall.Next(0, alleFilmer.Count);
                    if(!alleKunder[i].Filmer.Contains(alleFilmer[j]))
                    {
                        alleKunder[i].Filmer.Add(alleFilmer[TilfeldigFilm]);
                    }
                }
            }

            return alleKunder;
        }

    }
}