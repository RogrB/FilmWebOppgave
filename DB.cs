﻿using Graubakken_Filmsjappe.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace Graubakken_Filmsjappe
{
    public class DB
    {
        public IndexView HentIndexView()
        {
            IndexView indexView = new IndexView();
            indexView.Filmer = HentAlleFilmer();
            indexView.ActionFilmer = HentActionFilmer();
            indexView.Nyheter = HentIndexNyheter();

            return indexView;
        }

        public List<Film> HentFilmView(string sortering)
        {
            var db = new DBContext();
            List<Film> alleFilmer = new List<Film>();
            switch(sortering)
            {
                case "Dato":
                    alleFilmer = db.Filmer.OrderBy(f => f.ReleaseDate).ToList();
                    break;
                case "Visninger":
                    alleFilmer = db.Filmer.OrderByDescending(f => f.Visninger).ToList();
                    break;
                case "Stjerner":
                    alleFilmer = db.Filmer.OrderBy(f => f.Stemmer.Count()).ToList();
                    break;
                case "Sjanger":
                    alleFilmer = db.Filmer.OrderBy(f => f.Sjanger).ToList();
                    break;
                case "Kontinent":
                    alleFilmer = db.Filmer.OrderBy(f => f.Kontinent).ToList();
                    break;
                case "Produksjonsår":
                    alleFilmer = db.Filmer.OrderBy(f => f.Produksjonsår).ToList();
                    break;
                case "Alfabetisk":
                    alleFilmer = db.Filmer.OrderBy(f => f.Navn).ToList();
                    break;
                default:
                    alleFilmer = db.Filmer.ToList();
                    break;
            }
            return alleFilmer;
        }
        public List<Film> HentAlleFilmer()
        {
            using (var db = new Models.DBContext())
            {
                List<Film> alleFilmer = new List<Film>();
                alleFilmer = db.Filmer.ToList();

                return alleFilmer;
            }
        }

        public Skuespiller HentSkuespiller(int id)
        {
            using (var db = new DBContext())
            {
                var Skuespiller = db.Skuespillere.Find(id);

                return Skuespiller;
            }
        }

        public Film HentFilm(int id)
        {
            using (var db = new DBContext())
            {
                var Film = db.Filmer.Find(id);

                return Film;
            }

        }

        public bool RegistrerBruker(Kunde innKunde)
        {
            bool resultat = true;
            using (var db = new DBContext())
            {
                try
                {
                    string salt = LagSalt();
                    KundeDB nyKunde = new KundeDB()
                    {
                        Brukernavn = innKunde.Brukernavn,
                        Fornavn = innKunde.Fornavn,
                        Etternavn = innKunde.Etternavn,
                        Kort = innKunde.Kort,
                        Salt = salt,
                        Passord = LagHash(innKunde.Passord + salt),
                        Filmer = new List<Film>(),
                        Stemmer = new List<Stemmer>()
                    };
                    db.Kunder.Add(nyKunde);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    resultat = false;
                }
            }
                return resultat;
        }

        /*
         Metode for å Generere random salt
         Skrevet av Faglærer i webapplikasjoner ved Oslomet
         */
        private static string LagSalt()
        {
            byte[] randomArray = new byte[10];
            string randomString;

            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(randomArray);
            randomString = Convert.ToBase64String(randomArray);
            return randomString;
        }

         /*
         Metode for å Generere passordhash
         Skrevet av Faglærer i webapplikasjoner ved Oslomet
         */
        private static byte[] LagHash(string innStreng)
        {
            byte[] innData, utData;
            var algoritme = SHA256.Create();
            innData = System.Text.Encoding.UTF8.GetBytes(innStreng);
            utData = algoritme.ComputeHash(innData);
            return utData;
        }

        /*
        Metode for å sjekke innloggingsinfo
        Skrevet av Faglærer i webapplikasjoner ved Oslomet, og refaktorert for å passe modellene i dette prosjektet
        */
        public bool SjekkInnLogging(Kunde innKunde)
        {
            using (var db = new DBContext())
            {
                KundeDB funnetBruker = db.Kunder.FirstOrDefault(b => b.Brukernavn == innKunde.Brukernavn);
                if (funnetBruker != null)
                {
                    byte[] passordForTest = LagHash(innKunde.Passord + funnetBruker.Salt);
                    bool riktigBruker = funnetBruker.Passord.SequenceEqual(passordForTest);
                    return riktigBruker;
                }
                else
                {
                    return false;
                }
            }
        }

        public Kunde HentBruker(string brukernavn)
        {
            using (var db = new DBContext())
            {
                KundeDB funnetKunde = db.Kunder.FirstOrDefault(k => k.Brukernavn == brukernavn);
                if (funnetKunde != null)
                {
                    Kunde utKunde = new Kunde()
                    {
                        Brukernavn = funnetKunde.Brukernavn,
                        Fornavn = funnetKunde.Fornavn,
                        Etternavn = funnetKunde.Etternavn,
                        id = funnetKunde.id,
                        Kort = funnetKunde.Kort,
                        Filmer = funnetKunde.Filmer,
                        Stemmer = funnetKunde.Stemmer
                    };
                    return utKunde;
                }
                else
                {
                    return null;
                }
            }
        }

        public bool EndreBruker(Kunde innKunde)
        {
            var db = new DBContext();
            bool resultat = true;
            try
            {
                KundeDB endreKunde = db.Kunder.FirstOrDefault(k => k.Brukernavn == innKunde.Brukernavn);
                if(endreKunde != null)
                {
                    endreKunde.Fornavn = innKunde.Fornavn;
                    endreKunde.Etternavn = innKunde.Etternavn;
                    endreKunde.Kort = innKunde.Kort;
                    if (innKunde.Passord != null && innKunde.Passord != "")
                    {
                        endreKunde.Passord = LagHash(innKunde.Passord + endreKunde.Salt);
                    }
                    db.SaveChanges();
                }
                else
                {
                    resultat = false;
                }
            }
            catch(Exception e)
            {
                resultat = false;
            }
            return resultat;
        }

        public bool EndrePassord(Kunde innKunde)
        {
            bool resultat = true;
            var db = new DBContext();
            try
            {
                KundeDB endreKunde = db.Kunder.Find(innKunde.id);
                endreKunde.Passord = LagHash(innKunde.Passord + endreKunde.Salt);
                db.SaveChanges();
            }
            catch(Exception e)
            {
                resultat = false;
            }

            return resultat;
        }

        public List<Film> HentActionFilmer()
        {
            using (var db = new DBContext())
            {
                List<Film> actionFilmer = new List<Film>();
                List<Sjanger> sjangere = db.Sjangere.Where(k => k.sjanger == "Action").ToList();
                for (int i = 0; i < sjangere.Count(); i++)
                {
                    for (int j = 0; j < sjangere[i].Filmer.Count(); j++)
                    {
                        actionFilmer.Add(sjangere[i].Filmer[j]);
                    }
                }
           
                return actionFilmer;
            }
        }

        public List<Skuespiller> HentAlleSkuespillere()
        {
            using (var db = new DBContext())
            {
                return db.Skuespillere.ToList();
            }
        }

        public List<Skuespiller> HentSkuespillerView(string sortering)
        {
            using (var db = new DBContext())
            {
                List<Skuespiller> alleSkuespillere = new List<Skuespiller>();
                switch (sortering)
                {
                    case "Fornavn":
                        alleSkuespillere = db.Skuespillere.OrderBy(s => s.Fornavn).ToList();
                        break;
                    case "Etternavn":
                        alleSkuespillere = db.Skuespillere.OrderBy(s => s.Etternavn).ToList();
                        break;
                    case "Alder":
                        alleSkuespillere = db.Skuespillere.OrderBy(s => s.Alder).ToList();
                        break;
                    case "Land":
                        alleSkuespillere = db.Skuespillere.OrderBy(s => s.Land).ToList();
                        break;
                }
                return alleSkuespillere;
            }
        }

        public List<Nyhet> HentAlleNyheter()
        {
            using (var db = new DBContext())
            {
                return db.Nyheter.ToList();
            }
        }

        public List<Nyhet> HentIndexNyheter()
        {
            using (var db = new DBContext())
            {
                List<Nyhet> alleNyheter = db.Nyheter.OrderByDescending(n => n.id).ToList();

                return alleNyheter;
            }
        }

        public List<Sjanger> HentAlleSjangere()
        {
            var db = new DBContext();
            List<Sjanger> alleSjangere = db.Sjangere.ToList();
            for(int i = 0; i < alleSjangere.Count(); i++)
            {
                alleSjangere[i].antall = alleSjangere[i].Filmer.Count();
            }

            return alleSjangere;
        }

        public List<Film> HentFilmerFraSkuespillerID(int id)
        {
            var db = new DBContext(); // Får feilmelding om jeg prøver using(var db = new db())

            List<Film> filmer = db.Skuespillere.Find(id).Filmer.Select(f => new Film()
            {
                id = f.id,
                Navn = f.Navn,
                Bilde = f.Bilde,
                Studio = f.Studio,
                Visninger = f.Visninger,
                Beskrivelse = f.Kontinent,
                ReleaseDate = f.ReleaseDate
            }).ToList();
            return filmer;
        }

        public List<Skuespiller> HentSkuespillereIFilm(int id)
        {
            var db = new DBContext();

            List<Skuespiller> skuespillere = db.Filmer.Find(id).Skuespillere.Select(s => new Skuespiller()
            {
                id = s.id,
                Fornavn = s.Fornavn,
                Etternavn = s.Etternavn,
                Alder = s.Alder,
                Bilde = s.Bilde,
                Land = s.Land
            }).ToList();
            return skuespillere;
        }

        public bool InsertDBData()
        {
            var dbInsert = new DBinsert();
            bool ok = dbInsert.settInnIDB();
            if (ok)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Kunde> HentKunder()
        {
            var db = new DBContext();
            var alleKunder = db.Kunder.Select(k => new Kunde()
            {
                Fornavn = k.Fornavn,
                Etternavn = k.Etternavn,
                id = k.id,
                Brukernavn = k.Brukernavn,
                Filmer = k.Filmer
            }).ToList();

            return alleKunder;
        }

    }
}