using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PartTimeJob.Models;

namespace PartTimeJob.Controllers
{
    public class AdminEnrollmentWithOutQualificationJobController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminEnrollmentWithOutQualificationJob
        public ActionResult Index()
        {
            var enrollmentWithOutQualificationJob = db.EnrollmentWithOutQualificationJob.Include(e => e.Employee).Include(e => e.WithOutQualificationJob);
            return View(enrollmentWithOutQualificationJob.ToList());
        }

        // GET: AdminEnrollmentWithOutQualificationJob/Details/5
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

        // GET: AdminEnrollmentWithOutQualificationJob/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "FirstName");
            ViewBag.WithOutQualificationJobId = new SelectList(db.WithOutQualificationJobs, "Id", "JobName");
            return View();
        }

        // POST: AdminEnrollmentWithOutQualificationJob/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EmployeeId,WithOutQualificationJobId,Date")] EnrollmentWithOutQualificationJob enrollmentWithOutQualificationJob)
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

        // GET: AdminEnrollmentWithOutQualificationJob/Edit/5
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

        // POST: AdminEnrollmentWithOutQualificationJob/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EmployeeId,WithOutQualificationJobId,Date")] EnrollmentWithOutQualificationJob enrollmentWithOutQualificationJob)
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

        // GET: AdminEnrollmentWithOutQualificationJob/Delete/5
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

        // POST: AdminEnrollmentWithOutQualificationJob/Delete/5
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
