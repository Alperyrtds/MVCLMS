using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLMS.Models.Entity;
namespace MVCLMS.Controllers
{
    public class ShowCaseController : Controller
    {
        DBLibraryEntities database = new DBLibraryEntities();
        public ActionResult Index()
        {
            var variable = database.Books.ToList();
            return View(variable);
        }
    }
}