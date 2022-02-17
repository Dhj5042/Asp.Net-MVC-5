using Practical_10_1.Data.Model;
using Practical_10_1.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practical_10_1.Controllers
{
    public class userController : Controller
    {
        //this interface defined in different project as Class library
        private readonly IUserData db;
        /// <summary>
        /// use dependency injection
        /// for parameterized constructor to pass interface as parameter
        /// Register ContainerConfig in Global.assx
        /// </summary>
        /// <param name="db"></param>
        public userController(IUserData db)
        {
            //initialized IuserData object 
            this.db = db;
        }

        // GET: user
        //to get all data 
        public ActionResult Index()
        {
            //call ViewAll method by context
            var model = db.ViewAll();
            return View(model);
        }

        //create a view
        //by default get method execute
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //when user submit this form than post method execute
        public ActionResult Create(User user)
        {
            //check if model is valid or not else empty or not
            if (ModelState.IsValid)
            {
                //call context as a create method and pass user model
                db.create(user);
                TempData["Message"] = "You have saved the user data!";
                return RedirectToAction("Details", new { id = user.Id });
            }
            return View();
        }
        //display user details
        public ActionResult Details(int id)
        {
            //find by user id
            var model = db.Get(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        /// <summary>
        /// by default called this method by clicking on edit link
        /// and display as per users data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// when user submit form post method called and changes invoked
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                db.update(user);
                TempData["Message"] = "You have update the Data!";
                return RedirectToAction("Details", new { id = user.Id});
            }
            return View(user);
        }

        /// <summary>
        /// get method invoked and ask user are you conform
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        //user confirm to delete than delete method invoked
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection form)
        {
            db.Delete(id);
            TempData["Message"] = "You have Deleted the user ID="+id;
            return RedirectToAction("Index");
        }
    }
}