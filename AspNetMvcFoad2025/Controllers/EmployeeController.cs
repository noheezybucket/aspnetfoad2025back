using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspNetMvcFoad2025.Models;

namespace AspNetMvcFoad2025.Controllers
{
    public class EmployeeController : Controller
    {
        BdTrackingContext db = new BdTrackingContext();
        private object EmployeeID;

        public ActionResult Index()
        {
            return View();
        }
    //    public JsonResult List()
    //    {
    //        return Json(db.Employees.ToList(), JsonRequestBehavior.AllowGet);
    //    }
    //    public JsonResult Add(EmployeeController emp)
    //    {
    //        db.Employees.Add(emp);
    //        db.SaveChanges();
    //        return Json(1, JsonRequestBehavior.AllowGet);

    //    }
    //    public JsonResult GetbyID(int ID)
    //    {
    //        var Employee = db.Employees.ToList().Find(x => x.EmployeeID.Equals(ID));
    //        return Json(Employee, JsonRequestBehavior.AllowGet);
    //    }
    //    public JsonResult Update(EmployeeController emp)
    //    {
    //        Employee e = db.Employees.Find(emp.EmployeeID);
    //        e.Age = emp.Age;
    //        e.Country = emp.Country;
    //        e.State = emp.State;
    //        e.Name = emp.Name;
    //        db.SaveChanges();
    //        return Json(1, JsonRequestBehavior.AllowGet);
    //    }
    //    public JsonResult Delete(int ID)
    //    {
    //        Employee e = db.Employee.Find(ID);
    //        db.Employee.Remove(e);
    //        db.SaveChanges();
    //        return Json(0, JsonRequestBehavior.AllowGet);
    //    }
    }
}