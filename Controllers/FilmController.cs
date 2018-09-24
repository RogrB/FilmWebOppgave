using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Graubakken_Filmsjappe.Controllers
{
    public class FilmController : Controller
    {
        // GET: Film
        public ActionResult Index()
        {
            var db = new DB();
            List <Models.Film> alleFilmer = db.HentAlleFilmer();
            //ViewBag["IndexNyheter"] = db.HentIndexNyheter();
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