using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLMS.Models.Entity;

namespace MVCLMS.Controllers
{
    public class RegisterController : Controller
    {
        DBLibraryEntities database = new DBLibraryEntities();
        // GET: Register
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(Users users)
        {
            if (!ModelState.IsValid)
            {
                return View("SignUp");
            }
            database.Users.Add(users);
            database.SaveChanges();
            return View();
        }
    }
}