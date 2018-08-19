using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PartTimeJob.Controllers
{
    public class EmployeeHomePageController : Controller
    {
        // GET: EmployeeHomePage
        public ActionResult Home()
        {
            return View();
        }
    }
}