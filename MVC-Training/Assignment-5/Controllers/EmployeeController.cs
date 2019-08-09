using Assignment_5.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Assignment_5.Controllers
{
    public class EmployeeController : Controller
    {
        #region Variable declarations
        /// <summary>The database</summary>
        private readonly EmployeeContext db = new EmployeeContext();
        #endregion

        #region Display list method
        // GET: Employee
        public ActionResult Index()
        {
            var employees = db.Employees.Include(e => e.Department);
            return View(employees.ToList());
        }
        #endregion

        #region Create method
        /// <summary>Creates this instance.</summary>
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName");
            return View();
        }

        /// <summary>Creates the specified employee.</summary>
        /// <param name="employee">The employee.</param>
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,Name,Gender,City,DepartmentId")] Employee employee)
        {
            if (string.IsNullOrEmpty(employee.Name))
            {
                ModelState.AddModelError("Name", "The Name field is required.");
            }

            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName", employee.DepartmentId);
            return View(employee);
        }
        #endregion

        #region Edit method
        // GET: Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName", employee.DepartmentId);
            return View(employee);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Exclude = "Name")] Employee employee)
        {
            Employee employeeFromDB = db.Employees.Single(x => x.Id == employee.Id);
            employeeFromDB.Id = employee.Id;
            employeeFromDB.Gender = employee.Gender;
            employeeFromDB.City = employee.City;
            employeeFromDB.DepartmentId = employee.DepartmentId;

            employee.Name = employeeFromDB.Name;


            if (ModelState.IsValid)
            {
                db.Entry(employeeFromDB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName", employee.DepartmentId);
            return View(employee);
        }
        #endregion

        #region Delete method
        /// <summary>Deletes the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        /// <summary>Deletes the confirmed.</summary>
        /// <param name="id">The identifier.</param>
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion

        #region Connection dispose
        /// <summary>Releases unmanaged resources and optionally releases managed resources.</summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion
    }
}
