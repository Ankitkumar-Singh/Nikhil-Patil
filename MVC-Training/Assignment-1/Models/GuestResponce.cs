using System.ComponentModel.DataAnnotations;

namespace PartyInvites.Models
{
    public class GuestResponce
    {
        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        [Required(ErrorMessage = "Please enter your name.")]
        public string Name { get; set; }

        /// <summary>Gets or sets the email.</summary>
        /// <value>The email.</value>
        [Required(ErrorMessage = "Please enter your email.")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        /// <summary>Gets or sets the phone.</summary>
        /// <value>The phone.</value>
        [Required(ErrorMessage = "Please enter your phone number")]
        public string Phone { get; set; }

        /// <summary>Gets or sets the will attend.</summary>
        /// <value>The will attend.</value>
        [Required(ErrorMessage = "Please specify whether you'll attend")]
        public bool? WillAttend { get; set; }
    }
}