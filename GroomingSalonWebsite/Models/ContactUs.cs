using System;
using System.Collections.Generic;
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
        public string name { get; set; }
        //The customers email they enter.
        public string email { get; set; }
        //The main tagline for the email that is being sent
        public string subject { get; set; }
        //The actual body of the message for the user to enter their reason for contacting.
        public string message { get; set; }
        //Allows the return of all the information of the message in a toString format.
        public override string ToString()
        {
            return $"Name: {name} Email: {email} subject: {subject} message: {message}";
        }

    }
}
