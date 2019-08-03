using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_2.Models
{
    [Table("Departments")]
    public class Department
    {
        /// <summary>Gets or sets the department identifier.</summary>
        /// <value>The department identifier.</value>
        public int DepartmentId { get; set; }

        /// <summary>Gets or sets the name of the department.</summary>
        /// <value>The name of the department.</value>
        public string DepartmentName { get; set; }
    }
}