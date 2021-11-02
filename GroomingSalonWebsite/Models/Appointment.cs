using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroomingSalonWebsite.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }

        public string AppointmentFirstName { get; set; }

        public string AppointmentLastName { get; set; }

        public string AppointmentPetName { get; set; }

        public string AppointmentPetBreed { get; set; }

        public DateTime AppointmentPetBirthday { get; set; }

        public int AppointmentPetWeight { get; set; }

        public string PhoneNumber { get; set; }

        public string Address1 { get; set; }

        //Does it need this nullable enable line? Creates screen squiggle without it.
        //#nullable enable
        public string? Address2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        //Needs to be an int because most zipcodes consist of 5 digits.
        public int Zipcode { get; set; }

        public bool Services { get; set; }

        public DateTime AppointmentDate { get; set; }

        public override string ToString()
        {
            return AppointmentDate + " for " + AppointmentFirstName + AppointmentLastName + " and " + AppointmentPetName;
        }

        /*
        public  int AppointmentId { get; set; }

        public DateTime AppointmentDate { get; set; }

        public String ApptPhoneNumber { get; set; }

        public string ApptName { get; set; }

        public string ApptPetName { get; set; }

        public override string ToString()
        {
            return AppointmentDate + " for " + ApptName + " and" + ApptPetName ;
        }*/
    }
}
