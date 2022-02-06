using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
/// <summary>
/// Data from the user being logged into their account for their email part
/// </summary>
namespace GroomingSalonWebsite.Models
{
    public class Account
    {
        /// <summary>
        /// Auto generated ID to link with the users account.
        /// </summary>
        [Key]
        public int AccountId { get; set; }
        /// <summary>
        /// The users first name associated with their account. That gets put into the customer class
        /// </summary>
        [Required(ErrorMessage = "Need to associate full name with account.")]
        [DisplayName("First Name")]
        [RegularExpression(@"^[a-zA-Z'\s]*$", ErrorMessage = "Can only consist of letters and have at least 2")]
        [StringLength(20, MinimumLength = 2)]
        public string AccountFirstName { get; set; }
        /// <summary>
        /// The users last name that gets linked to their account and put into customer as well.
        /// </summary>
        [Required(ErrorMessage = "Need to associate full name with account.")]
        [DisplayName("Last Name")]
        [RegularExpression(@"^[a-zA-Z'\s]*$", ErrorMessage = "Can only consist of letters and have at least 2")]
        [StringLength(20,MinimumLength = 2)]
        public string AccountLastName { get; set; }
        /// <summary>
        /// The phone number the user has linked to their account.
        /// </summary>
        [Required(ErrorMessage = "Need to associate phone with account.")]
        [DisplayName("Phone Number")]
        [Phone]
        [RegularExpression(@"^\d+$", ErrorMessage = "Please enter numbers only")]
        [StringLength(10,MinimumLength = 10)]
        public string AccountPhoneNumber { get; set; }
        /// <summary>
        /// Makes use of the Identity scaffolding and makes the users email account for them.
        /// </summary>
        public IdentityUser Input { get; set; }

        /*Removing these parts of the class because Identity has a better usage of them.
        [Required(ErrorMessage = "Need your email as alternative to login")]
        [DisplayName("Email Address")]
        [DataType(DataType.EmailAddress)]
        public string AccountEmail { get; set; }

        [Required(ErrorMessage = "A username is needed to associate with your account.")]
        [DisplayName("Username")]
        [StringLength(16,MinimumLength = 6)]
        public string AccountName { get; set; }

        [Required(ErrorMessage = "An 8 letter password is required.")]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        [StringLength(32,MinimumLength = 8)]
        public string AccountPassword { get; set; }*/
    }
}
    