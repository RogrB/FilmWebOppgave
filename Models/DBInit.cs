﻿using System;
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
            // Oppretter DBData Objekter
            DBData.FilmData filmDB = new DBData.FilmData();
            DBData.KundeData kundeDB = new DBData.KundeData();
            DBData.NyhetsData nyhetsDB = new DBData.NyhetsData();
            DBData.SkuespillerData skuespillerDB = new DBData.SkuespillerData();

            // Henter inn lister over all DB Data
            List<Kunde> alleKunder = kundeDB.HentKundeListe();
            List<Nyhet> alleNyheter = nyhetsDB.HentNyhetsListe();
            List<Skuespiller> alleSkuespillere = skuespillerDB.HentSkuespillerListe();
            List<Film> alleFilmer = filmDB.HentFilmListe();

            // Kaller metode for å legge skuespillere inn i filmene
            SettSkuespillereInnIFilmer(alleFilmer, alleSkuespillere);

            // Kaller metode for å legge filmer inn i Kunde-objekter (filmer som kunder har sett)
            SettFilmerInnIKundeObjekt(alleFilmer, alleKunder);

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

            base.Seed(context);
        }

        // Metode som setter et tilfeldig utvalg av skuespillere fra skuespiller-Datasettet inn i hver enkelt film
        public List<Film> SettSkuespillereInnIFilmer(List<Film> alleFilmer, List<Skuespiller> alleSkuespillere)
        {
            Random TilfeldigTall = new Random();
            for (int i = 0; i < alleFilmer.Count(); i++)
            {
                int AntallSkuespillere = TilfeldigTall.Next(1, 5); // Antall skuespillere i denne filmen
                List<int> BrukteSkuespillere = new List<int>(); // Liste over skuespillere som allerede har blitt lagt til i filmen
                for (int j = 0; j < AntallSkuespillere; j++)
                {
                    int TilfeldigSkuespiller = FinnNySkuespiller(BrukteSkuespillere, alleSkuespillere.Count());
                    BrukteSkuespillere.Add(TilfeldigSkuespiller);
                    alleFilmer[i].Skuespillere.Add(alleSkuespillere[TilfeldigSkuespiller]);
                }
            }
            return alleFilmer;
        }

        // Metode som finner en ny skuespiller - for å sikre at den samme skuespilleren ikke blir lagt til en film flere ganger
        public int FinnNySkuespiller(List<int> BrukteSkuespillere, int antallSkuespillere)
        {
            Random TilfeldigTall = new Random();
            bool UnikSkuespiller = true;
            int Skuespiller = 0;
            while(UnikSkuespiller)
            {
                Skuespiller = TilfeldigTall.Next(0, antallSkuespillere);
                UnikSkuespiller = BrukteSkuespillere.Contains(Skuespiller);
            }
            return Skuespiller;
        }

        // Metode som setter et tilfeldig utvalg av filmer inn i kunde-objektene
        public List<Kunde> SettFilmerInnIKundeObjekt(List<Film> alleFilmer, List<Kunde> alleKunder)
        {
            Random TilfeldigTall = new Random();
            for (int i = 0; i < alleKunder.Count(); i++)
            {
                int AntallFilmer = TilfeldigTall.Next(0, alleFilmer.Count());

            }

            return alleKunder;
        }

        /*
            // Oppretter tilfeldige dataset av skuespillere for å legge inn i Filmer
            List<Skuespiller> skuespillere01 = new List<Skuespiller>
            {
                alleSkuespillere[0],
                alleSkuespillere[3],
                alleSkuespillere[6]
            };

            // Legger skuespillere inn i Filmer
            alleFilmer[0].Skuespillere = skuespillere01;
            alleFilmer[15].Skuespillere = skuespillere01;         
         * */

    }
}