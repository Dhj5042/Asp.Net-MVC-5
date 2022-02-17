using Practical_09.Filters;
using Practical_09.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exception = Practical_09.Filters.Exception;

namespace Practical_09.Controllers
{
    public class HomeController : Controller
    {
        List<Employee> emp;
        /// <summary>
        /// HomeController has Constructor to assign some predefined values of lists
        /// </summary>
        public HomeController()
        {
            emp = new List<Employee>()
            {
                    new Employee{Id=1,Ename="Dhruvin" , Eage=21 },
                    new Employee{Id=2,Ename="Raju" , Eage=20 },
                    new Employee{Id=3,Ename="Dev" , Eage=29 },
            };
        }
        // GET: Home
        public ActionResult Index()
        {
            return View();
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

        /// <summary>
        /// Use OutPutCache filter
        /// date-time will be displayed for an interval of 5 minutes
        /// </summary>
        /// <returns></returns>
        [OutputCache(Duration = 300)]
        public ActionResult OutPutCache()
        {
            TempData["Date&Time"] = System.DateTime.Now.ToString();
            return View();

        }

        //call input page
        [HttpGet]
        public ActionResult Dividebyzero()
        {
            return View("Divide");
        }

        //use custom exception filter
        [Exception]
        [HttpPost]
        //user input data and submit form than this method invoked
        public ActionResult Divide(DivideByZero divideByZero)
        {
            divideByZero.Reslut = divideByZero.Num1 / divideByZero.Num2;
            string Reslut = divideByZero.Reslut.ToString();
            ViewBag.Reslut = "Your Output is " + Reslut;
            return View();
        }
    }
}