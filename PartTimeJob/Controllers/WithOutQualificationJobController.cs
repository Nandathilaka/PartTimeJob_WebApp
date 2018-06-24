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
    public class WithOutQualificationJobController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: WithOutQualificationJob
        public ActionResult Index()
        {
            var withOutQualificationJobs = db.WithOutQualificationJobs.Include(w => w.User);
            return View(withOutQualificationJobs.ToList());
        }

        // GET: WithOutQualificationJob/Details/5
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

        // GET: WithOutQualificationJob/Create
        public ActionResult Create()
        {
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: WithOutQualificationJob/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,JobName,JobCategory,JobDescription,NumOfEmployee,Payment,Date,PhoneNumber,Location,ApplicationUserId")] WithOutQualificationJob withOutQualificationJob)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    db.WithOutQualificationJobs.Add(withOutQualificationJob);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email", withOutQualificationJob.ApplicationUserId);
            return View(withOutQualificationJob);
        }

        // GET: WithOutQualificationJob/Edit/5
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
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email", withOutQualificationJob.ApplicationUserId);
            return View(withOutQualificationJob);
        }

        // POST: WithOutQualificationJob/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,JobName,JobCategory,JobDescription,NumOfEmployee,Payment,Date,PhoneNumber,Location,ApplicationUserId")] WithOutQualificationJob withOutQualificationJob)
        {
            if (ModelState.IsValid)
            {
                db.Entry(withOutQualificationJob).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email", withOutQualificationJob.ApplicationUserId);
            return View(withOutQualificationJob);
        }

        // GET: WithOutQualificationJob/Delete/5
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

        // POST: WithOutQualificationJob/Delete/5
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
