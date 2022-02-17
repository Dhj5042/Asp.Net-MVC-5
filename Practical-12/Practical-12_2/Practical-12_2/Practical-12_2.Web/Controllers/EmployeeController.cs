using Newtonsoft.Json;
using Practical_12_2.Data.App_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practical_12_2.Web.Controllers
{
    public class EmployeeController : Controller
    {
        DesignationDbContextDataContext db1 = new DesignationDbContextDataContext();
        EmployeeDbContextDataContext db = new EmployeeDbContextDataContext();
        // GET: Employee
        public ActionResult Index()
        {
            List<Employee> emp = db.Employees.ToList();
            List<Designation> des = db1.Designations.ToList();
            var empdata = (from pd in emp
                     join od in des on pd.DesignationId equals od.Id
                     select new MultipleModels
                     {
                        Employee= pd,
                        Designation=od
                     });
            return View(empdata);
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
            var desdata = from des in db1.Designations select des;
            ViewBag.deslist = new SelectList(db1.Designations, "Id", "designation_name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            try
            {
                db.Employees.InsertOnSubmit(employee);
                db.SubmitChanges();
                return RedirectToAction("Details", new { id = employee.Id });
            }
            catch
            {
                return View();
            }
            return View();
        }


        public Employee GetData(int id)
        {
            return db.Employees.Single(x => x.Id == id);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var modeel = GetData(id);
            var desdata = from des in db1.Designations select des;
            ViewBag.deslist = new SelectList(db1.Designations, "Id", "designation_name");
            if (modeel == null)
            {
                return HttpNotFound();
            }
            return View(modeel);
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add update logic here
                    Employee employee1 = GetData(employee.Id);
                    employee1.First_Name = employee.First_Name;
                    employee1.Last_Name = employee.Last_Name;
                    employee1.Middle_Name = employee.Middle_Name;
                    employee1.DOB = employee.DOB;
                    employee1.Mobile_Number = employee.Mobile_Number;
                    employee1.Address = employee.Address;
                    employee1.Salary = employee.Salary;
                    employee1.DesignationId = employee.DesignationId;

                    db.SubmitChanges();
                    TempData["Message"] = "You have saved the restaurant!";
                    return RedirectToAction("Details", new { id = employee.Id });
                }
            }
            catch
            {
                return View();
            }
            return View(employee);
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
        public ActionResult Delete(int id, FormCollection formCollection)
        {
            var des = GetData(id);
            db.Employees.DeleteOnSubmit(des);
            db.SubmitChanges();
            TempData["Message"] = "You have deleted successfully!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CountRecords()
        {
            List<Employee> emp = db.Employees.ToList();
            List<Designation> des = db1.Designations.ToList();

            var QSCount1 = (from employee in emp
                            join sa in db1.Designations on employee.DesignationId equals sa.Id
                            group sa by sa.designation_name into data
                            select new CountEmp
                            {
                                Desidnation = data.Max(r=>r.designation_name),
                                Count = data.Count(),
                            });
            string json = JsonConvert.SerializeObject(QSCount1);
            List<CountEmp> countEmps = JsonConvert.DeserializeObject<List<CountEmp>>(json);
            return View(countEmps);
           // TempData["Count"] = "Total Records:" + json;
            //return RedirectToAction("Index");
        }
    }
}