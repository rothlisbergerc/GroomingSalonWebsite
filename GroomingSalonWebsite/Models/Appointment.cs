using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroomingSalonWebsite.Models
{
    public class Appointment
    {
        public int ApptId { get; set; }

        public String CustomerName { get; set; }

        public String PetName { get; set; }

        public String PhoneNumber { get; set; }

        public DateTime? ApptDate { get; set; }        

        public override string ToString()
        {
            return CustomerName + " " + ApptDate;
        }
    }
}
