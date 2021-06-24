using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLMS.Models.Entity;

namespace MVCLMS.Controllers
{
    public class BookController : Controller
    {
        DBLibraryEntities database = new DBLibraryEntities();
        public ActionResult Index(string x)
        {
            var books = from b in database.Books select b;
            if (!string.IsNullOrEmpty(x))
            {
                books = books.Where(z => z.Name.Contains(x));
            }
            

            return View(books.ToList());
        }
        [HttpGet]
        public ActionResult AddBook()
        {
            List<SelectListItem> value1 = (from i in database.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Name,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.val1 = value1;

            List<SelectListItem> value2 = (from i in database.Writers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Name + " " + i.Surname,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.val2 = value2;
            
            return View();
        }
        [HttpPost]
        public ActionResult AddBook(Books book)
        {
            var category = database.Categories.Where(x => x.Id == book.Categories.Id).FirstOrDefault();
            var writer = database.Writers.Where(w => w.Id == book.Writers.Id).FirstOrDefault();
            book.Categories = category;
            book.Writers = writer;
            database.Books.Add(book);
            database.SaveChanges();
            return RedirectToAction("Index");


        }
        public ActionResult DeleteBook(int id)
        {
            var book = database.Books.Find(id);
            database.Books.Remove(book);
            database.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetBook(int id)
        {
            var book = database.Books.Find(id);
            List<SelectListItem> value1 = (from i in database.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Name,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.val1 = value1;

            List<SelectListItem> value2 = (from i in database.Writers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Name + " " + i.Surname,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.val2 = value2;
            return View("GetBook",book);
        }
        public ActionResult UpdateBook(Books book)
        {
            var bk = database.Books.Find(book.Id);
            bk.Name = book.Name;
            bk.PublicationYear = book.PublicationYear;
            bk.Publisher = book.Publisher;
            bk.Page = book.Page;
            bk.Status = true;
            var category = database.Categories.Where(x => x.Id == book.Categories.Id).FirstOrDefault();
            var writer = database.Writers.Where(x => x.Id == book.Writers.Id).FirstOrDefault();
            bk.Categories.Id = category.Id;
            bk.Writers.Id = writer.Id;
            database.SaveChanges();
            return RedirectToAction("Index");

        }
       
    }
}