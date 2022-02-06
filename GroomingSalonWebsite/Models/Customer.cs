using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/// <summary>
/// Customer class that stores all users information from when they are registering for an appointment.
/// </summary>
namespace GroomingSalonWebsite.Models
{
    public class Customer
    {
        /// <summary>
        /// Auto generated id provided by the system
        /// </summary>
        public int CustomerId { get; set; }
        /// <summary>
        /// Customers first name to be associated with them
        /// </summary>
        public String FirstName { get; set; }
        /// <summary>
        /// Customers last name to be associated with them
        /// </summary>
        public String LastName { get; set; }

        /// <summary>
        /// Customers phone number to be associated with them. Can make this a varchar of length 15 or so for any phone number.
        /// </summary>
        public String PhoneNumber { get; set; }
        /// <summary>
        /// The home address of the customer
        /// </summary>
        public String HomeAddress { get; set; }
        /// <summary>
        /// Same as pet where if needed it will return an overridden version of toString to display the customer.
        /// </summary>
        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}
