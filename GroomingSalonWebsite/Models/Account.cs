using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
//Data from the user being logged into their account.
namespace GroomingSalonWebsite.Models
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        [Required(ErrorMessage = "Need to associate full name with account.")]
        public string AccountFirstName { get; set; }
        [Required(ErrorMessage = "Need to associate full name with account.")]
        public string AccountLastName { get; set; }
        [Required(ErrorMessage = "Need to associate phone with account.")]
        public string AccountPhoneNumber { get; set; }

        [Required(ErrorMessage = "Need your email as alternative to login")]
        [DataType(DataType.EmailAddress)]
        public string AccountEmail { get; set; }

        [Required(ErrorMessage = "A username is needed to associate with your account.")]
        [StringLength(16,MinimumLength = 6)]
        public string AccountName { get; set; }

        [Required(ErrorMessage = "A password is needed to protect your account.")]
        [DataType(DataType.Password)]
        [StringLength(32,MinimumLength = 8)]
        public string AccountPassword { get; set; }
    }
}
    