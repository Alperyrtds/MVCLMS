using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVCLMS.Models.Entity;

namespace MVCLMS.Controllers
{
    
    public class AdminLoginController : Controller
    {
        DBLibraryEntities database = new DBLibraryEntities();
        // GET: AdminLogin
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            var info = database.Admin.FirstOrDefault(x => x.Admin1 == admin.Admin1 && x.Password == admin.Password);
            if (info != null)
            {
                FormsAuthentication.SetAuthCookie(info.Admin1, false);
                Session["Admin"] = info.Admin1.ToString();
                return RedirectToAction("Index", "Book");
            }
            return View();
        }
    }
}