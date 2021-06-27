using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLMS.Models.Entity;
using MVCLMS.Models.Class;

namespace MVCLMS.Controllers
{
    public class ShowCaseController : Controller
    {
        DBLibraryEntities database = new DBLibraryEntities();
        
        [HttpGet]
        public ActionResult Index()
        {
            Class1 class1 = new Class1();
            class1.Value1 = database.Books.ToList();
            class1.Value2 = database.Aboutus.ToList();
 
            return View(class1);
        }
        [HttpPost]
        public ActionResult Index(Contact cnt)
        {

            database.Contact.Add(cnt);
            database.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}