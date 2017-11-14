using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Laboration1.Controllers
{
    public class HomeController : Controller
    {
       

        public ActionResult About()
        {
            ViewBag.Message = "Applikationsutveckling för internet ht17, laboration 1";

            return View();
        }

     
    }
}