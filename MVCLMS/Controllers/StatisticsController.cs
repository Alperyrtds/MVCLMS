using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLMS.Models.Entity;
namespace MVCLMS.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        DBLibraryEntities database = new DBLibraryEntities();
        public ActionResult Index()
        {
            var value1 = database.Users.Count();
            var value2 = database.Books.Count();
            var value3 = database.Books.Where(x => x.Status == false).Count();
            var value4 = database.Penalties.Sum(x => x.Penalty);
            ViewBag.val2 = value2;
            ViewBag.val1 = value1;
            ViewBag.val3 = value3;
            ViewBag.val4 = value4;
            return View();
        }
        public ActionResult Gallery()
        {
            return View();
        }
        
    }
}