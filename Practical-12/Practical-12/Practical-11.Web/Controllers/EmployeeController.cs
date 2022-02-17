using Practical_11.Data.Model;
using Practical_11.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practical_11.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmpoyeeData db;
        public EmployeeController(IEmpoyeeData db)
        {
            this.db = db;
        }
        // GET: Employee
        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(employee employee)
        {

            if (ModelState.IsValid)
            {
                db.Add(employee);
                return RedirectToAction("Details", new { id = employee.ID });
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var modeel = db.Get(id);
            if (modeel == null)
            {
                return HttpNotFound();
            }
            return View(modeel);
        }

        [HttpPost]
        public ActionResult Edit(employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Update(employee);
                TempData["Message"] = "You have saved the restaurant!";
                return RedirectToAction("Details", new { id = employee.ID });
            }
            return View(employee);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection form)
        {
            db.Delete(id);
            TempData["Message"] = "You have deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}