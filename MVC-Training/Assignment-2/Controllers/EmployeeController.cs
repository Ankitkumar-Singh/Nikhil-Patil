using Assignment_2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Assignment_2.Controllers
{
    public class EmployeeController : Controller
    {
        #region Department list
        /// <summary>Displays list of departments.</summary>
        public ActionResult Index()
        {
            EmployeeContext employeeContext = new EmployeeContext();
            List<Department> departments = employeeContext.Departments.ToList();

            return View(departments);
        }
        #endregion

        #region Employee list
        /// <summary>Employees by the department.</summary>
        /// <param name="departmentId">The department identifier.</param>
        public ActionResult EmployeeByDepartment(int departmentId)
        {
            EmployeeContext employeeContext = new EmployeeContext();
            List<Employee> employees = employeeContext.Employees.Where(emp => emp.DepartmentId == departmentId).ToList();

            return View(employees);
        }
        #endregion

    }
}