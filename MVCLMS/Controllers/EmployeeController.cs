using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLMS.Models.Entity;

namespace MVCLMS.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        DBLibraryEntities database = new DBLibraryEntities();
        public ActionResult Index()
        {
            var values = database.Emplooyes.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(Emplooyes emp)
        {
            if (!ModelState.IsValid)
            {
                return View("AddEmployee");
            }
            database.Emplooyes.Add(emp);
            database.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteEmployee(int id)
        {
            var employee = database.Emplooyes.Find(id);
            database.Emplooyes.Remove(employee);
            database.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetEmployee(int id)
        {
            var emplooyes = database.Emplooyes.Find(id);
            return View("GetEmployee", emplooyes);
        }
        [HttpPost]
        public ActionResult UpdateEmployee(Emplooyes emp)
        {
            var employee = database.Emplooyes.Find(emp.Id);
            employee.Employee = emp.Employee;
            database.SaveChanges();
            return RedirectToAction("Index");
           
        }
    }
}