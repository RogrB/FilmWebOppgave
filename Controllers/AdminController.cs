using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Graubakken_Filmsjappe.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Admin()
        {
            if (AdminLoggetInn())
            {
                return View();
            }
            return RedirectToAction("AdminLoginn");
        }

        public bool AdminLoggetInn()
        {
            return Session["Admin"] != null && (string)Session["Admin"] != "";
        }

        public ActionResult AdminLoginn()
        {
            return View();
        }
    }
}
