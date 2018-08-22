using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PartTimeJob.Controllers
{
    public class AdminHomePageController : Controller
    {
        // GET: AdminHomePage
        public ActionResult Index()
        {
            return View();
        }
    }
}