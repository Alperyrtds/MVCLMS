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
            database.Operations.Add(operations);
            database.SaveChanges();
            return View();
        }
        public ActionResult ReturnAway(int id)
        {
            var onloan = database.Operations.Find(id);
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