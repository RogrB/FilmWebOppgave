using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Graubakken_Filmsjappe.Controllers
{
    public class FilmController : Controller
    {
        // GET: Film
        public ActionResult Index()
        {
            var db = new DB();
            List <Models.Film> alleFilmer = db.HentAlleFilmer();
            List<Models.Nyhet> alleNyheter = db.HentIndexNyheter();
            ProsesserIndexNyheter(alleNyheter); // Setter de 3 siste nyhetene inn i ViewBags

            return View(alleFilmer);
        }

        public ActionResult Skuespillere()
        {
            var db = new DB();
            List<Models.Skuespiller> alleSkuespillere = db.HentAlleSkuespillere();
            return View(alleSkuespillere);
        }

        public ActionResult Nyheter()
        {
            var db = new DB();
            List<Models.Nyhet> alleNyheter = db.HentAlleNyheter();
            return View(alleNyheter);
        }

        public ActionResult Filmer()
        {
            var db = new DB();
            List<Models.Film> alleFilmer = db.HentAlleFilmer();
            return View(alleFilmer);
        }

        public ActionResult Sjangere()
        {
            var db = new DB();
            List<Models.Sjanger> alleSjangere = db.HentAlleSjangere();
            return View(alleSjangere);
        }

        // Metode som setter de 3 siste nyhetene inn i ViewBags for å vises på indexsiden
        public void ProsesserIndexNyheter(List<Models.Nyhet> nyheter)
        {
            ViewBag.Beskjed0 = nyheter[0].Beskjed;
            ViewBag.Tittel0 = nyheter[0].Tittel;
            ViewBag.Dato0 = nyheter[0].Dato;

            ViewBag.Beskjed1 = nyheter[1].Beskjed;
            ViewBag.Tittel1 = nyheter[1].Tittel;
            ViewBag.Dato1 = nyheter[1].Dato;

            ViewBag.Beskjed2 = nyheter[2].Beskjed;
            ViewBag.Tittel2 = nyheter[2].Tittel;
            ViewBag.Dato2 = nyheter[2].Dato;
        }

        public string HentEnFilm(int id)
        {
            var db = new DB();
            Models.Film enFilm = db.HentFilm(id);
            var utFilm = new Models.Film()
            {
                id = enFilm.id,
                Navn = enFilm.Navn,
                Beskrivelse = enFilm.Beskrivelse,
                Bilde = enFilm.Bilde,
                Produksjonsår = enFilm.Produksjonsår,
                Kontinent = enFilm.Kontinent,
                ReleaseDate = enFilm.ReleaseDate,
                Studio = enFilm.Studio,
                Visninger = enFilm.Visninger,
                Sjanger = new List<Models.Sjanger>(),
                Stemmer = new List<Models.Stemmer>(),
                Skuespillere = new List<Models.Skuespiller>()
            };

            //utFilm.Skuespillere = enFilm.Skuespillere;
            //utFilm.Stemmer = enFilm.Stemmer;
            //utFilm.Sjanger = enFilm.Sjanger;
            
            var jsonSerializer = new JavaScriptSerializer();
            string jsonData = jsonSerializer.Serialize(utFilm);
            return jsonData;
        }

        public ActionResult Dbinsert()
        {
            var db = new DB();
            if (db.InsertDBData())
            {
                ViewBag.Message = "DB insert OK";
            }
            else
            {
                ViewBag.Message = "DB insert feilet";
            }
            return View();
        }

    }
}