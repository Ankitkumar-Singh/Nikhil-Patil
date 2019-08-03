using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_2.Models
{
    [Table("EmployeeDetails")]
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
    }
}