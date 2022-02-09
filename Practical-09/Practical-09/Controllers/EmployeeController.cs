using Practical_09.Filters;
using Practical_09.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exception = Practical_09.Filters.Exception;

namespace Practical_09.Controllers
{
    public class EmployeeController : Controller
    {
        List<Employee> emp;
        public EmployeeController()
        {
            emp = new List<Employee>()
            {
                    new Employee{Id=1,Ename="Dhruvin" , Eage=21 },
                    new Employee{Id=2,Ename="Raju" , Eage=20 },
                    new Employee{Id=3,Ename="Dev" , Eage=29 },
            };
        }

        // GET: Employee
        [Route("Employee/", Name = "Mark")]
        public string Index(string Name)
        {
            return "Hello " + Name;
        }
        public ActionResult Pages()
        {
            return View("Index");
        }
        public ContentResult contentResult()
        {
            return Content("<b>Hello</b>, World! this message is from Employee Controller using the Action Result, <script> alert('Hi! I am Dhruvin Jariwala') </script>");
        }

        public JsonResult JsonResult()
        {
            var output = emp;
            return Json(output, JsonRequestBehavior.AllowGet);
        }
        public EmptyResult emptyResult()
        {
            return new EmptyResult();
        }
        [HttpGet]
        public JavaScriptResult javaScriptResult()
        {
            return JavaScript("alert('Hello')");
        }

        public FileResult FileResult()
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(Server.MapPath("~/ReadFile.txt"));
            return File(fileBytes, "text/plain");
        }

        public RedirectResult RedirectResult()
        {
            return Redirect("https://localhost:44348/Employee/Mark");
        }

        [Exception]
        public Decimal Dividebyzero(decimal num1,decimal num2)
        {

            num1 = 10;
            num2 = 2;
            return num1 / num2;
  
        }
    }
}