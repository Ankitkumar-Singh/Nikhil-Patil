using Assignment_2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Assignment_2.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult Index()
        {
            EmployeeContext employeeContext = new EmployeeContext();
            List<Employee> employees = employeeContext.Employees.ToList();

            return View(employees);
        }

        //public ActionResult Details()
        //{
        //    EmployeeContext employeeContext = new EmployeeContext();
        //    Employee employee = employeeContext.Employees.Single(emp => emp.Id == id);

        //    return View(employee);
        //}
    }
}