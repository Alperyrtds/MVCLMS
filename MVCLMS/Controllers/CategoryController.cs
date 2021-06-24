using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLMS.Models.Entity;

namespace MVCLMS.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        DBLibraryEntities database = new DBLibraryEntities();
        public ActionResult Index()
        {
            var values = database.Categories.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Categories categories)
        {
            database.Categories.Add(categories);
            database.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCategory(int id)
        {
            var category = database.Categories.Find(id);
            database.Categories.Remove(category);
            database.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetCategory(int id)
        {
            var category = database.Categories.Find(id);
            return View("GetCategory", category);
        }
        public ActionResult UpdateCategory(Categories category)
        {
            var ctg = database.Categories.Find(category.Id);
            ctg.Name = category.Name;
            database.SaveChanges();
            return View();

        }
    }
}