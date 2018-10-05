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
            Models.IndexView indexView = db.HentIndexView();

            return View(indexView);
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
                ViewBag.RegistreringsStatus = "Skjemaet er ikke fylt inn riktig";
                return View();
            }
            var db = new DB();
            if (!db.SjekkOmBrukernavnErLedig(innKunde.Brukernavn))
            {
                ViewBag.RegistreringsStatus = "Brukernavnet er opptatt";
                return View();
            }
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

        public ActionResult Logut()
        {
            Session["LoggetInn"] = false;
            Session["Brukernavn"] = "";
            ViewBag.Brukernavn = "";

            return RedirectToAction("Index");
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
            return RedirectToAction("Loginn");
        }

        [HttpPost]
        public ActionResult Bruker(Models.EndreKunde innKunde)
        {
            // Foretar ikke noe innloggingssjekk her, da det ikke skal være mulig å komme hit uten å være innlogget
            var db = new DB();
            if (ModelState.IsValid)
            {
                if (db.EndreBruker(innKunde, (string)Session["Brukernavn"]))
                {
                    ViewBag.EndreStatus = "Informasjon oppdatert";
                }
                else
                {
                    ViewBag.EndreStatus = "Klarte ikke å oppdatere informasjon";
                }
            }
            return View(db.HentBruker((string)Session["Brukernavn"]));
        }

        public ActionResult Film(int id = 0)
        {
            var db = new DB();
            var filmInfo = db.HentFilmInfo(id);

            return View(filmInfo);
        }

        public ActionResult Skuespiller(int id = 0)
        {
            var db = new DB();
            var skuespillerInfo = db.HentSkuespillerInfo(id);

            return View(skuespillerInfo);
        }

        public ActionResult FilmVisning(int id = 0)
        {
            if (Session["LoggetInn"] != null && Session["Brukernavn"] != null)
            {
                if ((bool)Session["LoggetInn"])
                {
                    var db = new DB();
                    db.OppdaterFilmVisningData(id);
                    var film = db.HentFilmInfo(id);
                    db.LeggFilmIKundeObjekt((string)Session["Brukernavn"], id);

                    return View(film);
                }
            }
            return RedirectToAction("Loginn");
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
                Stemmer = new List<Models.Stemme>(),
                Skuespillere = new List<Models.Skuespiller>()
            };

            //utFilm.Skuespillere = enFilm.Skuespillere;
            //utFilm.Stemmer = enFilm.Stemmer;
            //utFilm.Sjanger = enFilm.Sjanger;
            
            var jsonSerializer = new JavaScriptSerializer();
            string jsonData = jsonSerializer.Serialize(utFilm);

            return jsonData;
        }

        public string StemPåFilm(int FilmID, int stemme)
        {
            string resultat = "";
            var jsonSerializer = new JavaScriptSerializer();
            if (Session["Brukernavn"] != null && (string)Session["Brukernavn"] != "")
            {
                var db = new DB();
                if (db.StemPåFilm(FilmID, (string)Session["Brukernavn"], stemme))
                {
                    resultat = "OK";
                }
                else
                {
                    resultat = "Feil";
                }
            }
            else
            {
                resultat = "Feil innlogging";
            }
            return jsonSerializer.Serialize(resultat);
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

        public string SjekkOmBrukernavnErLedig(string brukernavn)
        {
            var db = new DB();
            var jsonSerializer = new JavaScriptSerializer();
            string resultat = "";
            if (db.SjekkOmBrukernavnErLedig(brukernavn))
            {
                resultat = "Brukernavn Ledig";
            }
            else
            {
                resultat = "Brukernavn opptatt";
            }
            return jsonSerializer.Serialize(resultat);
        }

        public string LeggIØnskeliste(int FilmID)
        {
            var db = new DB();
            var jsonSerializer = new JavaScriptSerializer();
            string resultat = "";
            if (Session["Brukernavn"] != null && (string)Session["Brukernavn"] != "")
            {

                if (db.LeggIØnskeliste(FilmID, (string)Session["Brukernavn"]))
                {
                    resultat = "OK";
                }
                else
                {
                    resultat = "Feil";
                }
            }
            else
            {
                resultat = "Feil innlogging";
            }
            return jsonSerializer.Serialize(resultat);
        }

        public string SlettFraØnskeliste(int id)
        {
            var db = new DB();
            string resultat = "";
            var jsonSerializer = new JavaScriptSerializer();
            if (db.SlettFraØnskeliste(id, (string)Session["Brukernavn"]))
            {
                resultat = "OK";
            }
            else
            {
                resultat = "Feil";
            }
            return jsonSerializer.Serialize(resultat);
        }

        public string HentSøkeforslag(string streng)
        {
            var jsonSerializer = new JavaScriptSerializer();
            var db = new DB();
            var søkeforslag = db.HentSøkeforslag(streng);

            return jsonSerializer.Serialize(søkeforslag);
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