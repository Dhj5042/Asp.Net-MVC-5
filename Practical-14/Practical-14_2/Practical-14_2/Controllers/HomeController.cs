using Practical_14_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Practical_14_2.Controllers
{
    public class HomeController : Controller
    {
        //database context file
        /// <summary>
        /// initialized object
        /// </summary>
        DbAuthenticationFormEntities1 db = new DbAuthenticationFormEntities1();

        /// <summary>
        /// authorize attribute filter checks the user is login or not 
        /// if user is not login than redirect login page
        /// </summary>
        /// <returns></returns>

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

   
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(Tbl_Admim tbl_Admim)
        {
            //check user is exist or not
            var User = db.Tbl_Admim.FirstOrDefault(x => x.UserName == tbl_Admim.UserName && x.PassWord == tbl_Admim.PassWord);
            //   
            if (User == null)
            {
                    //display message to client side if user not exist
                   ViewBag.Message="The user name or password provided is incorrect.";
            }
            else
            {
                //here FormsAuthentication is saved cookie to browser by username         
                FormsAuthentication.SetAuthCookie(tbl_Admim.UserName,true);
                return RedirectToAction("index");
             }
            return View(tbl_Admim);
        }

        [Authorize]
        public ActionResult SignOut()
        {
            //here FormsAuthentication.SignOut() is SignOut the current
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}