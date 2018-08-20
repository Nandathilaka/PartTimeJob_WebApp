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
    public class WithOutQualificationJobEmployeeViewController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: WithOutQualificationJobEmployeeView
        public ActionResult Index()
        {
            var withOutQualificationJobs = db.WithOutQualificationJobs.Include(w => w.Employer);
            return View(withOutQualificationJobs.ToList());
        }

        // GET: WithOutQualificationJobEmployeeView/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WithOutQualificationJob withOutQualificationJob = db.WithOutQualificationJobs.Find(id);
            if (withOutQualificationJob == null)
            {
                return HttpNotFound();
            }
            return View(withOutQualificationJob);
        }

        // GET: WithOutQualificationJobEmployeeView/Create
        public ActionResult Create()
        {
            ViewBag.EmployerId = new SelectList(db.Employers, "Id", "CompanyName");
            return View();
        }

        // POST: WithOutQualificationJobEmployeeView/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EmployerId,JobName,JobCategory,JobDescription,NumOfEmployee,Payment,Date,PhoneNumber,Location,Status")] WithOutQualificationJob withOutQualificationJob)
        {
            if (ModelState.IsValid)
            {
                db.WithOutQualificationJobs.Add(withOutQualificationJob);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployerId = new SelectList(db.Employers, "Id", "CompanyName", withOutQualificationJob.EmployerId);
            return View(withOutQualificationJob);
        }

        // GET: WithOutQualificationJobEmployeeView/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WithOutQualificationJob withOutQualificationJob = db.WithOutQualificationJobs.Find(id);
            if (withOutQualificationJob == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployerId = new SelectList(db.Employers, "Id", "CompanyName", withOutQualificationJob.EmployerId);
            return View(withOutQualificationJob);
        }

        // POST: WithOutQualificationJobEmployeeView/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EmployerId,JobName,JobCategory,JobDescription,NumOfEmployee,Payment,Date,PhoneNumber,Location,Status")] WithOutQualificationJob withOutQualificationJob)
        {
            if (ModelState.IsValid)
            {
                db.Entry(withOutQualificationJob).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployerId = new SelectList(db.Employers, "Id", "CompanyName", withOutQualificationJob.EmployerId);
            return View(withOutQualificationJob);
        }

        // GET: WithOutQualificationJobEmployeeView/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WithOutQualificationJob withOutQualificationJob = db.WithOutQualificationJobs.Find(id);
            if (withOutQualificationJob == null)
            {
                return HttpNotFound();
            }
            return View(withOutQualificationJob);
        }

        // POST: WithOutQualificationJobEmployeeView/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WithOutQualificationJob withOutQualificationJob = db.WithOutQualificationJobs.Find(id);
            db.WithOutQualificationJobs.Remove(withOutQualificationJob);
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
