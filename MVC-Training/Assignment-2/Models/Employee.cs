using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_2.Models
{
    [Table("EmployeeDetails")]
    public class Employee
    {
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>Gets or sets the gender.</summary>
        /// <value>The gender.</value>
        public string Gender { get; set; }

        /// <summary>Gets or sets the city.</summary>
        /// <value>The city.</value>
        public string City { get; set; }

        /// <summary>Gets or sets the department identifier.</summary>
        /// <value>The department identifier.</value>
        public int DepartmentId { get; set; }
    }
}