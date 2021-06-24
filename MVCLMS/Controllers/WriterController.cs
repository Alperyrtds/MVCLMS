using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLMS.Models.Entity;

namespace MVCLMS.Controllers
{
    public class WriterController : Controller
    {
        DBLibraryEntities database = new DBLibraryEntities();
        public ActionResult Index()
        {
            var values = database.Writers.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddWriter(Writers writer)
        {
            database.Writers.Add(writer);
            database.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteWriter(int id)
        {
            var writer = database.Writers.Find(id);
            database.Writers.Remove(writer);
            database.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult GetWriter(int id)
        {
            var writer = database.Writers.Find(id);
            return View("GetWriter", writer);
        }
        public ActionResult UpdateWriter (Writers w)
        {
            var writer = database.Writers.Find(w.Id);
            writer.Name = w.Name;
            writer.Surname = w.Surname;
            writer.Detail = w.Detail;
            database.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}