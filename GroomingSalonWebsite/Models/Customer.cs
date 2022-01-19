using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//Customer class that stores all users information from when they are registering for an appointment.
namespace GroomingSalonWebsite.Models
{
    public class Customer
    {
        //Auto generated id provided by the system
        public int CustomerId { get; set; }
        //Customers first name
        public String FirstName { get; set; }
        //Customers last name
        public String LastName { get; set; }

        //Can make this a varchar of length 15 or so for any phone number.
        public String PhoneNumber { get; set; }
        //The home address of the customer
        public String HomeAddress { get; set; }
        //Same as pet where if needed it will return an overridden version of toString to display the customer.
        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}
