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
            List<Models.IndexView> indexViewListe = new List<Models.IndexView>();
            Models.IndexView indexView = new Models.IndexView();
            indexView.Filmer = db.HentAlleFilmer();
            indexView.ActionFilmer = db.HentActionFilmer();
            indexView.Nyheter = db.HentIndexNyheter();

            indexViewListe.Add(indexView);
            return View(indexViewListe);
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

        public string HentFilmerFraSkuespillerID(int id)
        {
            var db = new DB();
            List<Models.Film> filmer = db.HentFilmerFraSkuespillerID(id);

            var jsonSerializer = new JavaScriptSerializer();
            string jsonData = jsonSerializer.Serialize(filmer);

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

        public ActionResult Kunder()
        {
            var db = new DB();
            var kunder = db.HentKunder();
            return View(kunder);
        }

    }
}