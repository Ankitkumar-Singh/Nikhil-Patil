//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Assignment_5.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class Employee
    {
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        [Required]
        [Display(Name = "Employee name")]
        public string Name { get; set; }

        /// <summary>Gets or sets the gender.</summary>
        /// <value>The gender.</value>
        [Required]
        public string Gender { get; set; }

        /// <summary>Gets or sets the city.</summary>
        /// <value>The city.</value>
        [Required]
        public string City { get; set; }

        /// <summary>Gets or sets the department identifier.</summary>
        /// <value>The department identifier.</value>
        [Required]
        public Nullable<int> DepartmentId { get; set; }

        /// <summary>Gets or sets the department.</summary>
        /// <value>The department.</value>
        public virtual Department Department { get; set; }
    }
}