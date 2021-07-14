using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLMS.Controllers
{
    public class UserPanelController : Controller
    {
        // GET: UserPanel
        public ActionResult Index()
        {
            return View();
        }
    }
}