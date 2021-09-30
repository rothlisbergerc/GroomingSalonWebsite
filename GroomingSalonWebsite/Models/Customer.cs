using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroomingSalonWebsite.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        //Can make this a varchar of length 15 or so for any phone number.
        public String PhoneNumber { get; set; }

        public String HomeAddress { get; set; }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}
