using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PartTimeJob.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.TheMessage = "Having trouble.? Send us a Message";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(string message)
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.TheMessage = "Thanks.!, We got Your Message";

            return View();
        }

        public ActionResult Foo()
        {
            return View("About");
        }

        public ActionResult Serial(string letterCase)
        {
            var serial = "ASPDOTNETMVC5";
            if (letterCase == "lower")
            {
                return Content(serial.ToLower());
            }
            else {
                //return Content(serial);
                //return Json(new { name = "Thilina", value = serial }, JsonRequestBehavior.AllowGet);
                return RedirectToAction("Index");
            }
        }
    }
}