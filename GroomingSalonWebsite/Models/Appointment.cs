using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroomingSalonWebsite.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }

        [Required]
        public string ApptFirstName { get; set; }

        [Required]
        public string ApptLastName { get; set; }

        [Required]
        public string ApptPetName { get; set; }

        [Required]
        public string ApptPetBreed { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime ApptPetBirthDay { get; set; }

        [Required]
        public int ApptPetWeight { get; set; }

        [Required]
        public string ApptPhoneNumber { get; set; }

        [Required]
        public string ApptAddress1 { get; set; }

        [Required]
        public string? ApptAddress2 { get; set; }

        [Required]
        public string ApptCity { get; set; }

        [Required]
        public string ApptState { get; set; }

        //Needs to be an int because most zipcodes consist of 5 digits.
        [Required]
        public int ApptZipcode { get; set; }

        [Required]
        public string ApptServices { get; set; }

        [Required]
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
