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
    public class EnrollmentWithOutQualificationJobController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EnrollmentWithOutQualificationJob
        public ActionResult Index()
        {
            var enrollmentWithOutQualificationJob = db.EnrollmentWithOutQualificationJob.Include(e => e.Employee).Include(e => e.WithOutQualificationJob);
            return View(enrollmentWithOutQualificationJob.ToList());
        }

        // GET: EnrollmentWithOutQualificationJob/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnrollmentWithOutQualificationJob enrollmentWithOutQualificationJob = db.EnrollmentWithOutQualificationJob.Find(id);
            if (enrollmentWithOutQualificationJob == null)
            {
                return HttpNotFound();
            }
            return View(enrollmentWithOutQualificationJob);
        }

        // GET: EnrollmentWithOutQualificationJob/Create
        public ActionResult Create(int? id)
        {
            var currentUserId = User.Identity.GetUserId();
            var currentEmployee = db.Employees.Where(c => c.ApplicationUserId == currentUserId);

            var currentJobId = db.WithOutQualificationJobs.Where(c => c.Id == id);

            ViewBag.EmployeeId = new SelectList(currentEmployee, "Id", "FirstName");
            ViewBag.WithOutQualificationJobId = new SelectList(currentJobId, "Id", "JobName");

            //ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "FirstName");
            //ViewBag.WithOutQualificationJobId = new SelectList(db.WithOutQualificationJobs, "Id", "JobName");
            return View();
        }

        // POST: EnrollmentWithOutQualificationJob/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,EmployeeId,WithOutQualificationJobId")] EnrollmentWithOutQualificationJob enrollmentWithOutQualificationJob)
        {
            if (ModelState.IsValid)
            {
                db.EnrollmentWithOutQualificationJob.Add(enrollmentWithOutQualificationJob);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "FirstName", enrollmentWithOutQualificationJob.EmployeeId);
            ViewBag.WithOutQualificationJobId = new SelectList(db.WithOutQualificationJobs, "Id", "JobName", enrollmentWithOutQualificationJob.WithOutQualificationJobId);
            return View(enrollmentWithOutQualificationJob);
        }

        // GET: EnrollmentWithOutQualificationJob/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnrollmentWithOutQualificationJob enrollmentWithOutQualificationJob = db.EnrollmentWithOutQualificationJob.Find(id);
            if (enrollmentWithOutQualificationJob == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "FirstName", enrollmentWithOutQualificationJob.EmployeeId);
            ViewBag.WithOutQualificationJobId = new SelectList(db.WithOutQualificationJobs, "Id", "JobName", enrollmentWithOutQualificationJob.WithOutQualificationJobId);
            return View(enrollmentWithOutQualificationJob);
        }

        // POST: EnrollmentWithOutQualificationJob/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,EmployeeId,WithOutQualificationJobId")] EnrollmentWithOutQualificationJob enrollmentWithOutQualificationJob)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enrollmentWithOutQualificationJob).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "FirstName", enrollmentWithOutQualificationJob.EmployeeId);
            ViewBag.WithOutQualificationJobId = new SelectList(db.WithOutQualificationJobs, "Id", "JobName", enrollmentWithOutQualificationJob.WithOutQualificationJobId);
            return View(enrollmentWithOutQualificationJob);
        }

        // GET: EnrollmentWithOutQualificationJob/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnrollmentWithOutQualificationJob enrollmentWithOutQualificationJob = db.EnrollmentWithOutQualificationJob.Find(id);
            if (enrollmentWithOutQualificationJob == null)
            {
                return HttpNotFound();
            }
            return View(enrollmentWithOutQualificationJob);
        }

        // POST: EnrollmentWithOutQualificationJob/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EnrollmentWithOutQualificationJob enrollmentWithOutQualificationJob = db.EnrollmentWithOutQualificationJob.Find(id);
            db.EnrollmentWithOutQualificationJob.Remove(enrollmentWithOutQualificationJob);
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
