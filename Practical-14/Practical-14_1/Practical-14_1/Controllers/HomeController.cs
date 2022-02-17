using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practical_14_1.Controllers
{
    public class HomeController : Controller
    {
        //by default index page is access because current user is login
       /// <summary>
       /// Windows authentication is allow to access index page to current User
       /// </summary>
       /// <returns></returns>
        [Authorize(Users = @"SF-CPU-312\dhruvin")]
        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// if user access this page than first user must be login to Simfromsolution credential then after access this page
        /// </summary>
        /// <returns></returns>
        [Authorize(Users = @"SF-CPU-312\Simfromsolutions")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        /// <summary>
        /// if user access this page than first user must be login to Simfromsolution credential then after access this page
        /// </summary>
        /// <returns></returns>

        [Authorize(Users = @"SF-CPU-312\Simfromsolutions")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}