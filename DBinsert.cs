using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Graubakken_Filmsjappe.Models;
using Graubakken_Filmsjappe.Models.DBData;

namespace Graubakken_Filmsjappe
{
    public class DBinsert
    {
        // Oppretter DBData Objekter
        FilmData filmDB = new FilmData();
        KundeData kundeDB = new KundeData();
        NyhetsData nyhetsDB = new NyhetsData();
        SkuespillerData skuespillerDB = new SkuespillerData();

        DBContext db = new DBContext();

        List<Kunde> alleKunder;
        List<Nyhet> alleNyheter;
        List<Skuespiller> alleSkuespillere;
        List<Film> alleFilmer;

        public DBinsert()
        {
            // Henter inn lister over all DB Data
            alleKunder = kundeDB.HentKundeListe();
            alleNyheter = nyhetsDB.HentNyhetsListe();
            alleSkuespillere = skuespillerDB.HentSkuespillerListe();
            alleFilmer = filmDB.HentFilmListe();
        }

        public bool settInnIDB()
        {
            bool ok = true;
            // Kaller metode for å legge skuespillere inn i filmene
            SettSkuespillereInnIFilmer();

            // Kaller metode for å legge filmer inn i Kunde-objekter (filmer som kunder har sett)
            SettFilmerInnIKundeObjekt();

            // Legger filmene inn i databasen
            try
            {
                for (int i = 0; i < alleFilmer.Count(); i++)
                {
                    db.Filmer.Add(alleFilmer[i]);
                }
                db.SaveChanges();
            }
            catch (Exception e)
            {
                ok = false;
            }

            // Legger skuespillerne inn i databasen
            try
            {
                for (int i = 0; i < alleSkuespillere.Count(); i++)
                {
                    db.Skuespillere.Add(alleSkuespillere[i]);
                }
                db.SaveChanges();
            }
            catch (Exception e)
            {
                ok = false;
            }

            // Legger nyheter inn i databasen
            try
            {
                for (int i = 0; i < alleNyheter.Count(); i++)
                {
                    db.Nyheter.Add(alleNyheter[i]);
                }
                db.SaveChanges();
            }
            catch (Exception e)
            {
                ok = false;
            }
            /*

            // Legger kundene inn i databasen
            try
            {
                for (int i = 0; i < alleKunder.Count(); i++)
                {
                    alleKunder[i].Stemmer = new List<Stemmer>();
                    db.Kunder.Add(alleKunder[i]);
                }
                db.SaveChanges();
            }
            catch (Exception e)
            {
                ok = false;
            }*/

            return ok;
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
            while (UnikSkuespiller)
            {
                Skuespiller = TilfeldigTall.Next(0, alleSkuespillere.Count());
                UnikSkuespiller = BrukteSkuespillere.Contains(Skuespiller);
            }
            return Skuespiller;
        }

        // Metode som setter et tilfeldig utvalg av filmer inn i kunde-objektene
        public List<Kunde> SettFilmerInnIKundeObjekt()
        {
            Random TilfeldigTall = new Random();
            for (int i = 0; i < alleKunder.Count(); i++)
            {
                alleKunder[i].Filmer = new List<Film>();
                int AntallFilmer = TilfeldigTall.Next(0, alleFilmer.Count());
                for (int j = 0; j < AntallFilmer; j++)
                {
                    int TilfeldigFilm = TilfeldigTall.Next(0, alleFilmer.Count);
                    if (!alleKunder[i].Filmer.Contains(alleFilmer[j]))
                    {
                        alleKunder[i].Filmer.Add(alleFilmer[TilfeldigFilm]);
                    }
                }
            }

            return alleKunder;
        }

    }
}