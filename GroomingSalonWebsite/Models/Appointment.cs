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

        public string ApptFirstName { get; set; }

        public string ApptLastName { get; set; }

        public string ApptPetName { get; set; }

        public string ApptPetBreed { get; set; }

        public DateTime ApptPetBirthDay { get; set; }

        public int ApptPetWeight { get; set; }

        public string ApptPhoneNumber { get; set; }

        public string ApptAddress1 { get; set; }

        //Does it need this nullable enable line? Creates screen squiggle without it.
        //#nullable enable
        public string? ApptAddress2 { get; set; }

        public string ApptCity { get; set; }

        public string ApptState { get; set; }

        //Needs to be an int because most zipcodes consist of 5 digits.
        public int ApptZipcode { get; set; }

        public bool ApptServices { get; set; }

        public DateTime ApptDate { get; set; }

        public override string ToString()
        {
            return ApptDate + " for " + ApptFirstName + ApptLastName + " and " + ApptPetName;
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
