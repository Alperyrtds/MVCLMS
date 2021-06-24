using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLMS.Models.Entity;

namespace MVCLMS.Controllers
{
    public class OperationController : Controller
    {
        DBLibraryEntities database = new DBLibraryEntities();
        public ActionResult Index()
        {
            var values = database.Operations.Where(x => x.OperationStatus == true).ToList();
            return View(values);
        }
    }
}