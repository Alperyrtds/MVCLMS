using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLMS.Models.Entity;

namespace MVCLMS.Controllers
{
    public class UserPanelController : Controller
    {
        DBLibraryEntities database = new DBLibraryEntities();
        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            var mail = Session["Mail"].ToString();
            var values = database.Users.FirstOrDefault(x => x.Mail == mail);
            return View(values);
        }
        [HttpPost]
        public ActionResult Index2(Users users)
        {
            var user = Session["Mail"].ToString();
            var u = database.Users.FirstOrDefault(x => x.Mail == user);
            u.Name = users.Name;
            u.Username = users.Username;
            u.PhoneNumber = users.PhoneNumber;
            u.Photo = users.Photo;
            u.Password = users.Password;
            database.SaveChanges();
            return View("Index");
        }

        public ActionResult MyBooks()
        {
            var user = Session["Mail"].ToString();
            var id = database.Users.Where(x => x.Mail == user.ToString()).Select(z => z.Id).FirstOrDefault();
            var values = database.Operations.Where(x => x.UserId == id).ToList();
            return View(values);
        }

    }
}