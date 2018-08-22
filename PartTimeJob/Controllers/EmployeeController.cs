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
    public class EmployeeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Employee
        
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var employees = db.Employees.Include(e => e.user).Where(e => e.ApplicationUserId==userId);
            return View(employees.ToList());
        }

        // GET: Employee/Details/5
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

        // GET: Employee/Create
        public ActionResult Create()
        {
            var userId = User.Identity.GetUserId();
            var currentLogin = db.Users.Where(c => c.Id == userId);
            ViewBag.ApplicationUserId = new SelectList(currentLogin, "Id", "Email");
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,BirthDay,PhoneNumber,Gender,Qualification,ApplicationUserId")] Employee employee)
        {
            var userId = User.Identity.GetUserId();
            var currentLogin = db.Users.Where(c => c.Id == userId);
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                //return RedirectToAction("Index");
                return RedirectToAction("GoEmail","Account");
               
            }

            ViewBag.ApplicationUserId = new SelectList(currentLogin, "Id", "Email", employee.ApplicationUserId);
            return View(employee);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            var userId = User.Identity.GetUserId();
            var currentLogin = db.Users.Where(c => c.Id == userId);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicationUserId = new SelectList(currentLogin, "Id", "Email", employee.ApplicationUserId);
            return View(employee);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,BirthDay,PhoneNumber,Gender,Qualification,ApplicationUserId")] Employee employee)
        {
            var userId = User.Identity.GetUserId();
            var currentLogin = db.Users.Where(c => c.Id == userId);
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationUserId = new SelectList(currentLogin, "Id", "Email", employee.ApplicationUserId);
            return View(employee);
        }

        // GET: Employee/Delete/5
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

        // POST: Employee/Delete/5
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
