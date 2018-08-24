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
    public class AdminEmployeeViewByAdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminEmployeeViewByAdmin
        public ActionResult Index()
        {
            var employees = db.Employees.Include(e => e.user);
            return View(employees.ToList());
        }

        // GET: AdminEmployeeViewByAdmin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: AdminEmployeeViewByAdmin/Create
        public ActionResult Create()
        {
            //ViewBag.ApplicationUserId = new SelectList(db.ApplicationUsers, "Id", "Email");
            return View();
        }

        // POST: AdminEmployeeViewByAdmin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,BirthDay,PhoneNumber,Gender,Qualification,ApplicationUserId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.ApplicationUserId = new SelectList(db.ApplicationUsers, "Id", "Email", employee.ApplicationUserId);
            return View(employee);
        }

        // GET: AdminEmployeeViewByAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            //ViewBag.ApplicationUserId = new SelectList(db.ApplicationUsers, "Id", "Email", employee.ApplicationUserId);
            return View(employee);
        }

        // POST: AdminEmployeeViewByAdmin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,BirthDay,PhoneNumber,Gender,Qualification,ApplicationUserId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.ApplicationUserId = new SelectList(db.ApplicationUsers, "Id", "Email", employee.ApplicationUserId);
            return View(employee);
        }

        // GET: AdminEmployeeViewByAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: AdminEmployeeViewByAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
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
