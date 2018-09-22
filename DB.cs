using Graubakken_Filmsjappe.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace Graubakken_Filmsjappe
{
    public class DB
    {
        public List<Models.Film> HentAlleFilmer()
        {
            var db = new Models.DBContext();
            List<Models.Film> alleFilmer = new List<Models.Film>();
            /*
            List<Models.Film> alleFilmer = db.Filmer.Select(f => new Models.Film()
            {
                id = f.id,
                Navn = f.Navn,
                Produksjonsår = f.Produksjonsår,
                Kontinent = f.Kontinent,
                Sjanger1 = f.Sjanger1,
                Sjanger2 = f.Sjanger2,
                Studio = f.Studio,
                Visninger = f.Visninger,
                Beskrivelse = f.Beskrivelse,
                Skuespillere = f.Skuespillere,
                Stemmer = f.Stemmer
            }).ToList();*/

            alleFilmer = db.Filmer.ToList();

            return alleFilmer;
        }

        public List<Skuespiller> HentSkuespillereIFilm(int id)
        {
            var db = new Models.DBContext();

            //List<Models.Skuespiller> skuespillere = db.Skuespillere.Where(f => f.Filmer[0].id = id).ToList();
            var skuespillere = new List<Models.Skuespiller>(); // Trenger riktig query her
            return skuespillere;
        }

        public Models.Skuespiller HentSkuespiller(int id)
        {
            var db = new Models.DBContext();

            var Skuespiller = db.Skuespillere.Find(id);

            if(Skuespiller == null)
            {
                return null;
            }
            else
            {
                var utSkuespiller = new Models.Skuespiller()
                {
                    id = Skuespiller.id,
                    Fornavn = Skuespiller.Fornavn,
                    Etternavn = Skuespiller.Etternavn,
                    Alder = Skuespiller.Alder,
                    Land = Skuespiller.Land
                };
                var filmer = new List<Models.Film>(); // Husk å oppdatere med riktig query
                utSkuespiller.Filmer = filmer;

                return utSkuespiller;
            }
        }

        public Models.Film HentFilm(int id)
        {
            var db = new Models.DBContext();

            var Film = db.Filmer.Find(id);

            if(Film == null)
            {
                return null;
            }
            else
            {
                var utFilm = new Models.Film()
                {
                    id = Film.id,
                    Navn = Film.Navn,
                    Produksjonsår = Film.Produksjonsår,
                    Beskrivelse = Film.Beskrivelse,
                    Bilde = Film.Bilde,
                    Kontinent = Film.Kontinent,
                    Sjanger1 = Film.Sjanger1,
                    Sjanger2 = Film.Sjanger2,
                    Studio = Film.Studio,
                    Visninger = Film.Visninger
                };
                var skuespillere = new List<Models.Skuespiller>(); // Husk å oppdatere med riktig query, og legge til stemmer
                utFilm.Skuespillere = skuespillere;

                return utFilm;
            }
        }

        public List<Models.Skuespiller> HentAlleSkuespillere()
        {
            var db = new Models.DBContext();
            return db.Skuespillere.ToList();
        }

        public void testInsert()
        {
            var db = new DBContext();
            Models.DBData.FilmData filmDB = new Models.DBData.FilmData();
            var alleFilmer = filmDB.HentFilmListe();
            var NySkuespiller = new Skuespiller
            {
                Fornavn = "Ole",
                Etternavn = "Olsen",
                Alder = 26,
                Land = "Norge",
                Bilde = "hallo"
            };
            List<Film> noenFilmer = new List<Film>();
            noenFilmer.Add(alleFilmer[3]);
            noenFilmer.Add(alleFilmer[7]);
            NySkuespiller.Filmer = noenFilmer;
            try
            {
                db.Skuespillere.Add(NySkuespiller);
                db.SaveChanges();
            }
            catch(Exception e)
            {
                // jepp..
            }
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

    }
}