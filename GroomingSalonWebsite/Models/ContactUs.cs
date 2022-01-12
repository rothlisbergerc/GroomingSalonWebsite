using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
//The contactUs class where any message that gets passed into it will be stored and can be examined later.
namespace GroomingSalonWebsite.Models
{
    public class ContactUs
    {
        [Key]
        public int messageId { get; set; }
        //Name of the customer who sent the message
        [Required(ErrorMessage ="Please enter your full name")]
        [DisplayName("Customer Name")]
        public string name { get; set; }
        //The customers email they enter.
        [Required(ErrorMessage ="Please enter an email")]
        [EmailAddress]
        [DisplayName("Customer Email")]
        public string email { get; set; }
        //The main tagline for the email that is being sent
        [Required(ErrorMessage ="Please enter a title to name your message")]
        [DisplayName("Title of message")]
        public string subject { get; set; }
        //The actual body of the message for the user to enter their reason for contacting.
        [Required(ErrorMessage ="Please enter a message to be sent.")]
        [DisplayName("Message body")]
        public string message { get; set; }
        //The checkboxes at the bottom of the page weren't being accounted for in the page.
        [Required(ErrorMessage ="How did you hear about us?")]
        [DisplayName("Heard about")]
        public string hearabout { get; set; }
        //Allows the return of all the information of the message in a toString format.
        public override string ToString()
        {
            return $"Name: {name} Email: {email} subject: {subject} message: {message}";
        }

    }
}
