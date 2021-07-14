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
            return View();
        }
        [HttpPost]
        public ActionResult GiveAway(Operations operations)
        {
            if (!ModelState.IsValid)
            {
                return View("GiveAway");
            }
            database.Operations.Add(operations);
            database.SaveChanges();
            return View();
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