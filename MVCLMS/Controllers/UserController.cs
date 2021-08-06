using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLMS.Models.Entity;
using PagedList;
using PagedList.Mvc;


namespace MVCLMS.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        DBLibraryEntities database = new DBLibraryEntities();
        public ActionResult Index(int page = 1)
        {
            //var values = database.Users.ToList();
            var values = database.Users.ToList().ToPagedList(page, 4);
            return View(values);
        }
        [HttpGet]
        public ActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddUser(Users user)
        {
            if (!ModelState.IsValid)
            {
                return View("AddUser");
            }
            database.Users.Add(user);
            database.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteUser(int id)
        {
            var user = database.Users.Find(id);
            database.Users.Remove(user);
            database.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetUser(int id)
        {
            var category = database.Users.Find(id);
            return View("GetUser", category);
        }
        public ActionResult UpdateUser(Users user)
        {
            var usr = database.Users.Find(user.Id);
            usr.Name = user.Name;
            usr.Surname = user.Surname;
            usr.Mail = user.Mail;
            usr.Password = user.Password;
            usr.PhoneNumber = user.PhoneNumber;
            usr.Photo = user.Photo;
            database.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult UserBookHistory(int id)
        {
            var bookhistory = database.Operations.Where(x => x.UserId == id).ToList();
            var userbook = database.Users.Where(x => x.Id == id).Select(x => x.Name + " " + x.Surname).FirstOrDefault();
            ViewBag.u1 = userbook;
            return View(bookhistory);
        }

    }
}