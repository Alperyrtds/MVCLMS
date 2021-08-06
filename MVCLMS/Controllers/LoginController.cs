using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLMS.Models.Entity;
using System.Web.Security;

namespace MVCLMS.Controllers
{
    public class LoginController : Controller
    {
        DBLibraryEntities database = new DBLibraryEntities();
        public ActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(Users users)
        {

            var data = database.Users.FirstOrDefault(x => x.Mail == users.Mail && x.Password == users.Password);

            if (data != null)
            {
                FormsAuthentication.SetAuthCookie(data.Mail, false);

                //Session["user"] = data;
                Session["Mail"] = data.Mail.ToString();
                //TempData["Name"] = data.Name.ToString();
                //TempData["Id"] = data.Id.ToString();
                //TempData["Surname"] = data.Surname.ToString();
                //TempData["Username"] = data.Username.ToString();
                //TempData["Password"] = data.Password.ToString();
                //TempData["Phone"] = data.PhoneNumber.ToString();
                return RedirectToAction("Index", "UserPanel");
            }
            else
            {
                ViewBag.error = "Kullanıcı adınız veya şifreniz hatalıdır";
                return View();

            }
        }
    }
}