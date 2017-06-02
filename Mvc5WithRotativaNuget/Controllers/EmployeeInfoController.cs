using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc5WithRotativaNuget.Models;
using Rotativa;

namespace Mvc5WithRotativaNuget.Controllers
{
    public class EmployeeInfoController : Controller
    {
        private DatabaseEntities ctx;

        public EmployeeInfoController()
        {
            ctx = new DatabaseEntities();
        }

        public ActionResult Index()
        {
            var employees = ctx.EmployeeInfo.ToList();
            return View(employees);
        }

        public ActionResult PrintAllEmployees()
        {
            var report = new ActionAsPdf("Index");
            return report;
        }

        public ActionResult PrintEmployeeById(int id)
        {
            var report = new ActionAsPdf("ExecutePrintEmployeeById", new {id = id});
            return report;
        }

        public ActionResult ExecutePrintEmployeeById(int id)
        {
            var employee = ctx.EmployeeInfo.First(x => x.EmpNo == id);
            return View(employee);
        }
    }
}