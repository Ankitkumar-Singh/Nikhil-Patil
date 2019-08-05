using Assignment_3_4.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Assignment_3_4.Controllers
{
    public class EmployeeController : Controller
    {
        #region List employee
        /// <summary>Displays list of employees.</summary>
        public ActionResult Index()
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            List<Employee> employees = employeeBusinessLayer.Employees.ToList();

            return View(employees);
        }
        #endregion

        #region Add new employee
        /// <summary>Creates the get.</summary>
        [HttpGet]
        [ActionName("Create")]
        public ActionResult CreateGet()
        {
            return View();
        }

        /// <summary>Creates the post.</summary>
        /// <param name="employee">The employee.</param>
        [HttpPost]
        [ActionName("Create")]
        public ActionResult CreatePost(Employee employee)
        {
            if (ModelState.IsValid)
            {
                EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
                employeeBusinessLayer.SaveEmployee(employee);

                return RedirectToAction("Index");
            }

            return View();
        }
        #endregion

        #region Updates old employee record
        /// <summary>Edits the employee.</summary>
        /// <param name="id">The identifier.</param>
        [HttpGet]
        [ActionName("Edit")]
        public ActionResult EditEmployee(int id)
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            Employee employee = employeeBusinessLayer.Employees.Single(emp => emp.Id == id);
            return View(employee);
        }

        /// <summary>Edits the employee.</summary>
        /// <param name="employee">The employee.</param>
        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
                employeeBusinessLayer.UpdateEmployee(employee);

                return RedirectToAction("Index");
            }

            return View();
        }
        #endregion

        #region Delete employee record
        /// <summary>Deletes the employee.</summary>
        /// <param name="id">The identifier.</param>
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteEmployee(int id)
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            employeeBusinessLayer.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
        #endregion
    }
}