using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
/// <summary>
/// The contactUs class where any message that gets passed into it will be stored and can be examined later.
/// </summary>
namespace GroomingSalonWebsite.Models
{
    public class ContactUs
    {
        [Key]
        public int messageId { get; set; }
        /// <summary>
        /// Name of the customer who sent the message
        /// </summary>
        [Required(ErrorMessage ="Please enter your full name")]
        [DisplayName("Customer Name")]
        public string name { get; set; }
        /// <summary>
        /// The customers email they enter.
        /// </summary>
        [Required(ErrorMessage ="Please enter an email")]
        [EmailAddress]
        [DisplayName("Customer Email")]
        public string email { get; set; }
        /// <summary>
        /// The main tagline for the email that is being sent
        /// </summary>
        [Required(ErrorMessage ="Please enter a title to name your message")]
        [DisplayName("Title of message")]
        public string subject { get; set; }
        /// <summary>
        /// The actual body of the message for the user to enter their reason for contacting.
        /// </summary>
        [Required(ErrorMessage ="Please enter a message to be sent.")]
        [DisplayName("Message body")]
        public string message { get; set; }
        /// <summary>
        /// The checkboxes at the bottom of the page weren't being accounted for in the page.
        /// </summary>
        [Required(ErrorMessage ="How did you hear about us?")]
        [DisplayName("Heard about")]
        public string hearabout { get; set; }
        /// <summary>
        /// Allows the return of all the information of the message in a toString format.
        /// </summary>
        public override string ToString()
        {
            return $"Name: {name} Email: {email} subject: {subject} message: {message}";
        }

    }
}
