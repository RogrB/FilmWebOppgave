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
        public ActionResult Index()
        {
            var db = new DB();
            List<Models.IndexView> indexViewListe = db.HentIndexView();

            return View(indexViewListe);
        }

        public ActionResult Skuespillere(string sortering)
        {
            if (string.IsNullOrEmpty(sortering))
            {
                sortering = "Fornavn";
                ViewBag.SkuespillerSortering = "Fornavn";
            }
            else
            {
                ViewBag.SkuespillerSortering = sortering;
            }
            var db = new DB();
            List<Models.Skuespiller> alleSkuespillere = db.HentSkuespillerView(sortering);
            return View(alleSkuespillere);
        }

        public ActionResult Nyheter()
        {
            var db = new DB();
            List<Models.Nyhet> alleNyheter = db.HentAlleNyheter();
            return View(alleNyheter);
        }

        public ActionResult Filmer(string sortering)
        {
            if (string.IsNullOrEmpty(sortering))
            {
                sortering = "Alfabetisk";
                ViewBag.Sortering = "Alfabetisk";
            }
            else
            {
                ViewBag.Sortering = sortering;
            }
            var db = new DB();
            List<Models.Film> alleFilmer = db.HentFilmView(sortering);
            return View(alleFilmer);
        }

        public ActionResult Sjangere()
        {
            var db = new DB();
            List<Models.Sjanger> alleSjangere = db.HentAlleSjangere();
            return View(alleSjangere);
        }

        public ActionResult Registrer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registrer(Models.Kunde innKunde)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            var db = new DB();
            if(db.RegistrerBruker(innKunde))
            {
                Session["LoggetInn"] = true;
                Session["Brukernavn"] = innKunde.Brukernavn;
                ViewBag.Innlogget = true;
                return RedirectToAction("Velkommen");
            }
            else
            {
                ViewBag.RegistreringsStatus = "Feil under registrering";
                return View();
            }
        }

        public ActionResult Velkommen()
        {
            if (Session["LoggetInn"] != null)
            {
                if ((bool)Session["LoggetInn"])
                {
                    ViewBag.Brukernavn = Session["Brukernavn"];
                    return View();
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Loginn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Loginn(Models.Kunde innKunde)
        {
            var db = new DB();
            if(db.SjekkInnLogging(innKunde))
            {
                Session["LoggetInn"] = true;
                Session["Brukernavn"] = innKunde.Brukernavn;
                ViewBag.Brukernavn = innKunde.Brukernavn;
                return RedirectToAction("Index");
            }
            else
            {
                Session["LoggetInn"] = false;
                Session["Brukernavn"] = "";
                ViewBag.Brukernavn = "";
                return View();
            }
        }

        public ActionResult Bruker(string brukernavn)
        {
            if (Session["LoggetInn"] != null)
            {
                if ((bool)Session["LoggetInn"])
                {
                    var db = new DB();
                    var bruker = db.HentBruker(brukernavn);

                    return View(bruker);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Bruker(Models.Kunde innKunde)
        {
            // Foretar ikke noe innloggingssjekk her, da det ikke skal være mulig å komme hit uten å være innlogget
            // Foretar ikke noe sjekk på modelstate.isvalid, da man ikke nødvendigvis vil endre passord
            var db = new DB();
            if (db.EndreBruker(innKunde))
            {
                ViewBag.EndreStatus = "Informasjon oppdatert";
            }
            else
            {
                ViewBag.EndreStatus = "Klarte ikke å oppdatere informasjon";

            }
            return View(db.HentBruker(innKunde.Brukernavn));
        }

        [HttpPost]
        public ActionResult EndrePassord(Models.Kunde innKunde)
        {
            var db = new DB();
            if(ModelState.IsValid)
            {
                if(db.EndrePassord(innKunde))
                {
                    ViewBag.EndreStatus = "Passord endret";
                }
                else
                {
                    ViewBag.EndreStatus = "Klarte ikke å endre passordet";
                }
            }
            return View(db.HentBruker(innKunde.Brukernavn));
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

        public string HentSkuespillereIFilm(int id)
        {
            var db = new DB();
            List<Models.Skuespiller> skuespillere = db.HentSkuespillereIFilm(id);

            var jsonSerializer = new JavaScriptSerializer();
            string jsonData = jsonSerializer.Serialize(skuespillere);

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