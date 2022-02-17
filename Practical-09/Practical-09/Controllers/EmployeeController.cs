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


        // GET: Employee
        [Route("Employee/", Name = "Mark")]
        public string Index(string Name)
        {
            return "Hello " + Name;
        }
 
    }
}