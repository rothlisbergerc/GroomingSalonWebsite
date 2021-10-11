using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroomingSalonWebsite.Models
{
    public class ContactUs
    {
        public int messageId { get; set; }

        public string name { get; set; }

        public string email { get; set; }

        public string subject { get; set; }

        public string message { get; set; }

        public override string ToString()
        {
            return $"Name: {name} Email: {email} subject: {subject} message: {message}";
        }

    }
}
