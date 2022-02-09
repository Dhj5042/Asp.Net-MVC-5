using Practical_08.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practical_08.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        // GET: Home
        public string Index()
        {
            var str = new ReturnString();
            return  str.ReturnStringvalue();
        }

        public ActionResult Home()
        {
            return View();
        }
    }
}