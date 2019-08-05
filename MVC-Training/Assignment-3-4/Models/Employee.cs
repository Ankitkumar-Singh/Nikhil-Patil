using System;
using System.ComponentModel.DataAnnotations;

namespace Assignment_3_4.Models
{
    public class Employee
    {
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        [Required]
        public string Name { get; set; }

        /// <summary>Gets or sets the gender.</summary>
        /// <value>The gender.</value>
        [Required]
        public string Gender { get; set; }

        /// <summary>Gets or sets the city.</summary>
        /// <value>The city.</value>
        [Required]
        public string City { get; set; }

        /// <summary>Gets or sets the date of birth.</summary>
        /// <value>The date of birth.</value>
        [Required]
        public DateTime? DateOfBirth { get; set; }
    }
}