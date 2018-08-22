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
    public class EmployerViewByEmployeeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EmployerViewByEmployee
        public ActionResult Index()
        {
            var employers = db.Employers.Include(e => e.user);
            return View(employers.ToList());
        }

        // GET: EmployerViewByEmployee/Details/5
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

        // GET: EmployerViewByEmployee/Create
        public ActionResult Create()
        {
            var userId = User.Identity.GetUserId();
            var currentLoginId = db.Users.Where(c => c.Id == userId);
            ViewBag.ApplicationUserId = new SelectList(currentLoginId, "Id", "Email");
            return View();
        }

        // POST: EmployerViewByEmployee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CompanyName,FirstName,LastName,Position,Location,Country,ApplicationUserId")] Employer employer)
        {
            if (ModelState.IsValid)
            {
                db.Employers.Add(employer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var userId = User.Identity.GetUserId();
            var currentLoginId = db.Users.Where(c => c.Id == userId);

            ViewBag.ApplicationUserId = new SelectList(currentLoginId, "Id", "Email", employer.ApplicationUserId);
            return View(employer);
        }

        // GET: EmployerViewByEmployee/Edit/5
        public ActionResult Edit(int? id)
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
            var userId = User.Identity.GetUserId();
            var currentLoginId = db.Users.Where(c => c.Id == userId);
            ViewBag.ApplicationUserId = new SelectList(currentLoginId, "Id", "Email", employer.ApplicationUserId);
            return View(employer);
        }

        // POST: EmployerViewByEmployee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CompanyName,FirstName,LastName,Position,Location,Country,ApplicationUserId")] Employer employer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var userId = User.Identity.GetUserId();
            var currentLoginId = db.Users.Where(c => c.Id == userId);
            ViewBag.ApplicationUserId = new SelectList(currentLoginId, "Id", "Email", employer.ApplicationUserId);
            return View(employer);
        }

        // GET: EmployerViewByEmployee/Delete/5
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

        // POST: EmployerViewByEmployee/Delete/5
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
