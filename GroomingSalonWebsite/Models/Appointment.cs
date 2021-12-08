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

        [Required(ErrorMessage = "We need a first name")]
        [DisplayName("First Name")]
        [RegularExpression(@"^[a-zA-Z'\s]*$", ErrorMessage = "Can only consist of letters and have at least 2")]
        //Most first and last names have at least 2 letters at minimum.
        [StringLength(20, MinimumLength = 2)]
        public string ApptFirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [DisplayName("Last Name")]
        [RegularExpression(@"^[a-zA-Z'\s]*$", ErrorMessage = "Can only consist of letters and have at least 2")]
        //Most first and last names have at least 2 letters at minimum.
        [StringLength(20, MinimumLength = 2)]
        public string ApptLastName { get; set; }

        [Required(ErrorMessage = "Every pet has a name")]
        [DisplayName("Pet Name")]
        public string ApptPetName { get; set; }

        [Required(ErrorMessage = "Your pet has some kind of breed")]
        [DisplayName("Animal Breed")]
        [RegularExpression(@"^[a-zA-Z'\s]*$", ErrorMessage = "Animal breed needs to be at least 2 letters long")]
        //Breeds need at least 2 letters to state what they are.
        [StringLength(20, MinimumLength = 2)]
        public string ApptPetBreed { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "An estimate is ok for birthday")]
        [DisplayName("Pets Birthday")]
        public DateTime ApptPetBirthDay { get; set; }

        [Required(ErrorMessage = "An estimate is ok for weight")]
        [DisplayName("Pets Weight")]
        [Range(1,999)]
        public int ApptPetWeight { get; set; }

        [Required(ErrorMessage = "Must be a valid phone number")]
        [DisplayName("Your phone number")]
        [Phone]
        [RegularExpression(@"^\d+$", ErrorMessage = "Please enter numbers only")]
        [StringLength(10,MinimumLength = 10)]
        public string ApptPhoneNumber { get; set; }

        [Required(ErrorMessage = "Need a mailing address")]
        [DisplayName("Home Address")]
        public string ApptAddress1 { get; set; }

        [DisplayName("Secondary Address")]
        public string? ApptAddress2 { get; set; }

        [Required(ErrorMessage = "Mailing address' city")]
        [DisplayName("Address City")]
        public string ApptCity { get; set; }

        [Required(ErrorMessage = "Mailing address' state")]
        [DisplayName("Address State")]
        public string ApptState { get; set; }

        //Needs to be an int because most zipcodes consist of 5 digits.
        [Required(ErrorMessage = "Please enter 5 digit zipcode")]
        [DisplayName("Address Zipcode")]
        [StringLength(5,MinimumLength = 5)]
        [RegularExpression(@"^\d+$", ErrorMessage = "Please enter numbers only")]
        public string ApptZipcode { get; set; }

        [Required(ErrorMessage = "Need at least 1 service chosen")]
        [DisplayName("Chosen Service")]
        //Could add hidden field in javascript and as they click on the checkboxes you could add to the value.
        //Stays 1 string vs it being broken and only displaying most recent choice in database.
        //When unchecked also remove that choice from the string.
        public string ApptServices { get; set; }

        [Required(ErrorMessage = "Need to know what date your coming in")]
        [DisplayName("Appointment date")]
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
