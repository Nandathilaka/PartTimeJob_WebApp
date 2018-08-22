using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PartTimeJob.Models;
using Microsoft.AspNet.Identity;

namespace PartTimeJob.Controllers
{
    public class EmployerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Employer
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var employers = db.Employers.Include(e => e.user).Where(e => e.ApplicationUserId==userId);
            return View(employers.ToList());
        }

        // GET: Employer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employer employer = db.Employers.Find(id);
            if (employer == null)
            {
                return HttpNotFound();
            }
            return View(employer);
        }

        // GET: Employer/Create
        public ActionResult Create()
        {
            var userId = User.Identity.GetUserId();
            var currentLoginId = db.Users.Where(c => c.Id == userId);
            //ViewBag.ApplicationUserId = currentLoginId ;
            ViewBag.ApplicationUserId = new SelectList(currentLoginId, "Id", "Email");
            return View();
        }

        // POST: Employer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CompanyName,FirstName,LastName,Position,Location,Country,ApplicationUserId")] Employer employer)
        {
            var userId = User.Identity.GetUserId();
            var currentLoginId = db.Users.Where(c => c.Id == userId);
            if (ModelState.IsValid)
            {
                db.Employers.Add(employer);
                db.SaveChanges();
                //return RedirectToAction("Index");
                return RedirectToAction("GoEmail", "Account");
            }

            ViewBag.ApplicationUserId = new SelectList(currentLoginId, "Id", "Email", employer.ApplicationUserId);
            return View(employer);
        }

        // GET: Employer/Edit/5
        public ActionResult Edit(int? id)
        {
            var userId = User.Identity.GetUserId();
            var currentLoginId = db.Users.Where(c => c.Id == userId);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employer employer = db.Employers.Find(id);
            if (employer == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicationUserId = new SelectList(currentLoginId, "Id", "Email", employer.ApplicationUserId);
            return View(employer);
        }

        // POST: Employer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CompanyName,FirstName,LastName,Position,Location,Country,ApplicationUserId")] Employer employer)
        {
            var userId = User.Identity.GetUserId();
            var currentLoginId = db.Users.Where(c => c.Id == userId);
            if (ModelState.IsValid)
            {
                db.Entry(employer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationUserId = new SelectList(currentLoginId, "Id", "Email", employer.ApplicationUserId);
            return View(employer);
        }

        // GET: Employer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employer employer = db.Employers.Find(id);
            if (employer == null)
            {
                return HttpNotFound();
            }
            return View(employer);
        }

        // POST: Employer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employer employer = db.Employers.Find(id);
            db.Employers.Remove(employer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
