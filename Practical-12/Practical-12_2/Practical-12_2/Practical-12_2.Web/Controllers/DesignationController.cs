using Practical_12_2.Data.App_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practical_12_2.Web.Controllers
{
    public class DesignationController : Controller
    {
        DesignationDbContextDataContext db = new DesignationDbContextDataContext();
        // GET: Designation
        public ActionResult Index()
        {
            var desdata = from des in db.Designations select des;
            return View(desdata);
        }
        public ActionResult Details(int id)
        {
            var model = GetData(id);
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
        public ActionResult Create(Designation designation)
        {  
            try {
                db.Designations.InsertOnSubmit(designation);
                db.SubmitChanges();
                return RedirectToAction("Details", new { id = designation.Id });
            } catch {
                return View();
            }
            return View();
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var modeel = GetData(id);
            if (modeel == null)
            {
                return HttpNotFound();
            }
            return View(modeel);
        }

        [HttpPost]
        public ActionResult Edit(Designation designation)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add update logic here
                    Designation des = db.Designations.Single(x => x.Id == designation.Id);
                    des.designation_name = designation.designation_name;
                    db.SubmitChanges();
                    TempData["Message"] = "You have saved the restaurant!";
                    return RedirectToAction("Details", new { id = designation.Id });
                }
            }
            catch
            {
                return View();
            }
            return View(designation);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = GetData(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection designation)
        {
            var des = GetData(id);
            db.Designations.DeleteOnSubmit(des);
            db.SubmitChanges();
            TempData["Message"] = "You have deleted successfully!";
            return RedirectToAction("Index");
        }

        public Designation GetData(int id)
        {
           return db.Designations.Single(x => x.Id == id);
        }
    }
}