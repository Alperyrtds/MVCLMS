using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLMS.Models.Entity;

namespace MVCLMS.Controllers
{
    public class OnLoanController : Controller
    {
        DBLibraryEntities database = new DBLibraryEntities();
        public ActionResult Index()
        {
            var values = database.Operations.Where(x => x.OperationStatus == false).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult GiveAway()
        {
            List<SelectListItem> value1 = (from x in database.Users.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Name + " " + x.Surname,
                                               Value = x.Id.ToString()
                                           }).ToList();
            ViewBag.val1 = value1;

            List<SelectListItem> value2 = (from x in database.Books.Where(x=>x.Status==true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Name,
                                               Value = x.Id.ToString()
                                           }).ToList();
            ViewBag.val2 = value2;

            List<SelectListItem> value3 = (from x in database.Emplooyes.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Employee,
                                               Value = x.Id.ToString()
                                           }).ToList();
            ViewBag.val3 = value3;

            return View();


        }
        [HttpPost]
        public ActionResult GiveAway(Operations operations)
        {
            var v1 = database.Users.Where(x => x.Id ==operations.Users.Id).FirstOrDefault();
            var v2 = database.Books.Where(x => x.Id == operations.Books.Id).FirstOrDefault();
            var v3 = database.Emplooyes.Where(x => x.Id == operations.Emplooyes.Id).FirstOrDefault();
            operations.Users = v1;
            operations.Books = v2;
            operations.Emplooyes = v3;
            database.Operations.Add(operations);
            database.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ReturnAway(Operations operations)
        {
            var onloan = database.Operations.Find(operations.Id);
            DateTime d1 = DateTime.Parse(onloan.ReturnDate.ToString());
            DateTime d2 = DateTime.Parse(DateTime.Now.ToShortDateString());
            TimeSpan d3 = d2 - d1;

            ViewBag.dgr = d3.TotalDays;
            return View("ReturnAway", onloan);
        }
        public ActionResult UpdateOnLoan(Operations opr)
        {
            var update = database.Operations.Find(opr.Id);
            update.UserReturnDate = opr.UserReturnDate;
            update.OperationStatus = true;
            database.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}