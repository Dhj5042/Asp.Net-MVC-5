using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Practical_13.Models;
using PagedList;
using Microsoft.Ajax.Utilities;

namespace Practical_13.Controllers
{
    public class employeesController : Controller
    {
        //database Context is initialized
        private DbEmpEntities1 db = new DbEmpEntities1();

        // GET: employees
        //public ActionResult Index(int? page,string eName)
        //{

        //    if(String.IsNullOrWhiteSpace(eName))
        //        eName=null;
        //   // List<employee> emp = new List<employee>();
        //    if (eName != null)
        //    {
        //        var emps = from c in db.employees
        //                  where c.Name.Contains(eName)
        //                  select c;
        //        return View(emps.ToList().ToPagedList(page ?? 1, 3));
        //    }
        //    return View(db.employees.ToList().ToPagedList(page ?? 1, 3));

        //}

        /// <summary>
        /// Here page and row is optional parameter so by default 1 page render and 3 rows update
        /// if user enter row number and submit button than row parameter has received value and rendered row
        /// </summary>
        /// <param name="page"></param>
        /// <param name="row"></param>
        /// <returns></returns>

        public ActionResult Index(int? page,int? row)
        {
            if (row == null)
                row = 3;
            else
                //dynamic row binding
                return Json(db.employees.ToList().ToPagedList(page ?? 1, (int)row), JsonRequestBehavior.AllowGet);
            //default row binding
            return View(db.employees.ToList().ToPagedList(page ?? 1, (int)row));
        }

        // GET: employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employee employee = db.employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Dob,Age")] employee employee)
        {
            if (ModelState.IsValid)
            {
                db.employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employee employee = db.employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Dob,Age")] employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employee employee = db.employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            employee employee = db.employees.Find(id);
            db.employees.Remove(employee);
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
        /// <summary>
        /// this request come from with the help of ajax
        /// textBox keyUp event is occur to execute this request
        /// </summary>
        /// <param name="eName"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Search(string eName, int? page)
        {
           
            var emp = from c in db.employees
                      where c.Name.Contains(eName)
                      select c;
            return Json(emp.ToList().ToPagedList(page ?? 1, 3));
            //List<employee> emp = new List<employee>();
            //if (eName != null)
            //{
            //    emp = db.employees.Where(x => x.Name.Contains(eName)).ToList();
            //    return Json(emp, JsonRequestBehavior.AllowGet);
            //}
            //return Json(JsonRequestBehavior.AllowGet);
        }
    }
}
