using System.Data.Entity;

namespace Assignment_2.Models
{
    public class EmployeeContext : DbContext
    {
        /// <summary>Gets or sets the employees.</summary>
        /// <value>The employees.</value>
        public DbSet<Employee> Employees { get; set; }

        /// <summary>Gets or sets the departments.</summary>
        /// <value>The departments.</value>
        public DbSet<Department> Departments { get; set; }
    }
}