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
        SjangerData sjangerDB = new SjangerData();

        DBContext db = new DBContext();

        List<Kunde> alleKunder;
        List<Nyhet> alleNyheter;
        List<Skuespiller> alleSkuespillere;
        List<Film> alleFilmer;
        List<Sjanger> alleSjangere;

        public DBinsert()
        {
            // Henter inn lister over all DB Data
            alleKunder = kundeDB.HentKundeListe();
            alleNyheter = nyhetsDB.HentNyhetsListe();
            alleSkuespillere = skuespillerDB.HentSkuespillerListe();
            alleFilmer = filmDB.HentFilmListe();
            alleSjangere = sjangerDB.HentSjangerListe();
        }

        public bool settInnIDB()
        {
            bool ok = true;
            // Kaller metode for å legge skuespillere inn i filmene
            SettSkuespillereInnIFilmer();

            // Kaller metode for å legge filmer inn i Kunde-objekter (filmer som kunder har sett)
            SettFilmerInnIKundeObjekt();

            // Kaller metode for å opprette sjangere og legge sjangere inn i Film-objekter
            OpprettSjangere();

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
            }

            // Legger sjangere inn i databasen
            try
            {
                for (int i = 0; i < alleSjangere.Count(); i++)
                {
                    db.Sjangere.Add(alleSjangere[i]);
                }
                db.SaveChanges();
            }
            catch (Exception e)
            {
                ok = false;
            }

            return ok;
        }

        // Metode som setter et tilfeldig utvalg av skuespillere fra skuespiller-Datasettet inn i hver enkelt film
        public void SettSkuespillereInnIFilmer()
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
        public void SettFilmerInnIKundeObjekt()
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
        }

        // Metode som oppretter sjanger-lister i film objektene
        public void OpprettSjangere()
        {
            for (int i = 0; i < alleFilmer.Count(); i++)
            {
                alleFilmer[i].Sjanger = new List<Sjanger>();
            }
            SettSjangerInnIFilmer();
        }

        public void SettSjangerInnIFilmer()
        {
            alleFilmer[0].Sjanger.Add(alleSjangere.Find(sjanger => sjanger.sjanger == "Action"));
            alleFilmer[1].Sjanger.Add(alleSjangere.Find(sjanger => sjanger.sjanger == "Action"));
            alleFilmer[1].Sjanger.Add(alleSjangere.Find(sjanger => sjanger.sjanger == "Western"));
            alleFilmer[2].Sjanger.Add(alleSjangere.Find(sjanger => sjanger.sjanger == "Krim"));
            alleFilmer[2].Sjanger.Add(alleSjangere.Find(sjanger => sjanger.sjanger == "Drama"));
            alleFilmer[3].Sjanger.Add(alleSjangere.Find(sjanger => sjanger.sjanger == "Dokumentar"));
            alleFilmer[4].Sjanger.Add(alleSjangere.Find(sjanger => sjanger.sjanger == "Action"));
            alleFilmer[4].Sjanger.Add(alleSjangere.Find(sjanger => sjanger.sjanger == "Eventyr"));
            alleFilmer[5].Sjanger.Add(alleSjangere.Find(sjanger => sjanger.sjanger == "Romantikk"));
            alleFilmer[5].Sjanger.Add(alleSjangere.Find(sjanger => sjanger.sjanger == "Komedie"));
            alleFilmer[6].Sjanger.Add(alleSjangere.Find(sjanger => sjanger.sjanger == "Drama"));
            alleFilmer[6].Sjanger.Add(alleSjangere.Find(sjanger => sjanger.sjanger == "Romantikk"));
            alleFilmer[7].Sjanger.Add(alleSjangere.Find(sjanger => sjanger.sjanger == "Action"));
            alleFilmer[7].Sjanger.Add(alleSjangere.Find(sjanger => sjanger.sjanger == "Drama"));
            alleFilmer[8].Sjanger.Add(alleSjangere.Find(sjanger => sjanger.sjanger == "Action"));
            alleFilmer[8].Sjanger.Add(alleSjangere.Find(sjanger => sjanger.sjanger == "Krim"));
            alleFilmer[9].Sjanger.Add(alleSjangere.Find(sjanger => sjanger.sjanger == "Animasjon"));
            alleFilmer[9].Sjanger.Add(alleSjangere.Find(sjanger => sjanger.sjanger == "Familie"));
            alleFilmer[10].Sjanger.Add(alleSjangere.Find(sjanger => sjanger.sjanger == "Romantikk"));
            alleFilmer[10].Sjanger.Add(alleSjangere.Find(sjanger => sjanger.sjanger == "Western"));
            alleFilmer[11].Sjanger.Add(alleSjangere.Find(sjanger => sjanger.sjanger == "Animasjon"));
            alleFilmer[11].Sjanger.Add(alleSjangere.Find(sjanger => sjanger.sjanger == "Familie"));
            alleFilmer[12].Sjanger.Add(alleSjangere.Find(sjanger => sjanger.sjanger == "Action"));
            alleFilmer[12].Sjanger.Add(alleSjangere.Find(sjanger => sjanger.sjanger == "Western"));
            alleFilmer[13].Sjanger.Add(alleSjangere.Find(sjanger => sjanger.sjanger == "Musikal"));
            alleFilmer[13].Sjanger.Add(alleSjangere.Find(sjanger => sjanger.sjanger == "Western"));
            alleFilmer[14].Sjanger.Add(alleSjangere.Find(sjanger => sjanger.sjanger == "Komedie"));
            alleFilmer[14].Sjanger.Add(alleSjangere.Find(sjanger => sjanger.sjanger == "Action"));
            alleFilmer[15].Sjanger.Add(alleSjangere.Find(sjanger => sjanger.sjanger == "Animasjon"));
            alleFilmer[15].Sjanger.Add(alleSjangere.Find(sjanger => sjanger.sjanger == "Familie"));
            alleFilmer[16].Sjanger.Add(alleSjangere.Find(sjanger => sjanger.sjanger == "Western"));
            alleFilmer[16].Sjanger.Add(alleSjangere.Find(sjanger => sjanger.sjanger == "Action"));
            alleFilmer[17].Sjanger.Add(alleSjangere.Find(sjanger => sjanger.sjanger == "Action"));
            alleFilmer[17].Sjanger.Add(alleSjangere.Find(sjanger => sjanger.sjanger == "Science Fiction"));
            alleFilmer[18].Sjanger.Add(alleSjangere.Find(sjanger => sjanger.sjanger == "Action"));
            alleFilmer[18].Sjanger.Add(alleSjangere.Find(sjanger => sjanger.sjanger == "Science Fiction"));
            alleFilmer[19].Sjanger.Add(alleSjangere.Find(sjanger => sjanger.sjanger == "Action"));
            alleFilmer[19].Sjanger.Add(alleSjangere.Find(sjanger => sjanger.sjanger == "Science Fiction"));
            alleFilmer[20].Sjanger.Add(alleSjangere.Find(sjanger => sjanger.sjanger == "Action"));
            alleFilmer[20].Sjanger.Add(alleSjangere.Find(sjanger => sjanger.sjanger == "Science Fiction"));
            alleFilmer[21].Sjanger.Add(alleSjangere.Find(sjanger => sjanger.sjanger == "Action"));
            alleFilmer[21].Sjanger.Add(alleSjangere.Find(sjanger => sjanger.sjanger == "Science Fiction"));
            alleFilmer[22].Sjanger.Add(alleSjangere.Find(sjanger => sjanger.sjanger == "Action"));
            alleFilmer[22].Sjanger.Add(alleSjangere.Find(sjanger => sjanger.sjanger == "Science Fiction"));
            alleFilmer[23].Sjanger.Add(alleSjangere.Find(sjanger => sjanger.sjanger == "Animasjon"));
            alleFilmer[23].Sjanger.Add(alleSjangere.Find(sjanger => sjanger.sjanger == "Familie"));
            alleFilmer[24].Sjanger.Add(alleSjangere.Find(sjanger => sjanger.sjanger == "Romantikk"));
        }

    }
}