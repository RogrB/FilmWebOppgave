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

        public List<Film> HentActionFilmer()
        {
            using (var db = new DBContext())
            {
                List<Film> actionFilmer = new List<Film>();
                //actionFilmer = db.Filmer.Where(film => db.Sjangere.Where(k => k.sjanger == "Action")).ToList();

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
            using (var db = new DBContext())
            {
                List<Sjanger> alleSjangere = db.Sjangere.ToList();

                return alleSjangere;
            }
        }

        public List<Film> HentFilmerFraSkuespillerID(int id)
        {
            var db = new DBContext(); // Får feilmelding om jeg prøver using(var db = new db())

            List<Film> filmer = db.Skuespillere.Find(id).Filmer.Select(f => new Film()
            {
                id = f.id,
                Navn = f.Navn,
                Bilde = f.Bilde
            }).ToList();
            return filmer;
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

        /*
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
        }*/

    }
}