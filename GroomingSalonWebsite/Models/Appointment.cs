using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
/// <summary>
/// The appointment class that does almost all the heavy lifting on the page. Establishes the customer and the pet for the DB.
/// </summary>
namespace GroomingSalonWebsite.Models
{
    public class Appointment
    {
        /// <summary>
        /// Creates the customersId automatically.
        /// </summary>
        [Key]
        public int AppointmentId { get; set; }
        /// <summary>
        /// Customers first name that gets entered with certain constraints
        /// </summary>
        [Required(ErrorMessage = "We need a first name")]
        [DisplayName("First Name")]
        [RegularExpression(@"^[a-zA-Z'\s]*$", ErrorMessage = "Can only consist of letters and have at least 2")]
        //Most first and last names have at least 2 letters at minimum.
        [StringLength(20, MinimumLength = 2)]
        public string ApptFirstName { get; set; }
        /// <summary>
        /// Customers last name that gets entered with certain contraints
        /// </summary>
        [Required(ErrorMessage = "Last name is required")]
        [DisplayName("Last Name")]
        [RegularExpression(@"^[a-zA-Z'\s]*$", ErrorMessage = "Can only consist of letters and have at least 2")]
        //Most first and last names have at least 2 letters at minimum.
        [StringLength(20, MinimumLength = 2)]
        public string ApptLastName { get; set; }
        /// <summary>
        /// The pet name that gets entered along with the customer
        /// </summary>
        [Required(ErrorMessage = "Every pet has a name")]
        [DisplayName("Pet Name")]
        public string ApptPetName { get; set; }
        /// <summary>
        /// The breed of the pet that gets entered
        /// </summary>
        [Required(ErrorMessage = "Your pet has some kind of breed")]
        [DisplayName("Animal Breed")]
        [RegularExpression(@"^[a-zA-Z'\s]*$", ErrorMessage = "Animal breed needs to be at least 2 letters long")]
        //Breeds need at least 2 letters to state what they are.
        [StringLength(20, MinimumLength = 2)]
        public string ApptPetBreed { get; set; }
        /// <summary>
        /// The pets birthday that gets put into the system.
        /// </summary>
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "An estimate is ok for birthday")]
        [DisplayName("Pets Birthday")]
        public DateTime ApptPetBirthDay { get; set; }
        /// <summary>
        /// The weight of the pet within certain restrictions
        /// </summary>
        [Required(ErrorMessage = "An estimate is ok for weight")]
        [DisplayName("Pets Weight")]
        [Range(1,999)]
        public int ApptPetWeight { get; set; }
        /// <summary>
        /// Enters a users phone number and allows for only numbers.
        /// </summary>
        [Required(ErrorMessage = "Must be a valid phone number")]
        [DisplayName("Your phone number")]
        [Phone]
        [RegularExpression(@"^\d+$", ErrorMessage = "Please enter numbers only")]
        [StringLength(10,MinimumLength = 10)]
        public string ApptPhoneNumber { get; set; }
        /// <summary>
        /// The users home mailing address and where they live.
        /// </summary>
        [Required(ErrorMessage = "Need a mailing address")]
        [DisplayName("Home Address")]
        public string ApptAddress1 { get; set; }
        /// <summary>
        /// Most locations only have 1 address but the optional address 2 can get added in as well.
        /// </summary>
        [DisplayName("Secondary Address")]
        public string? ApptAddress2 { get; set; }
        /// <summary>
        /// The city that the users address resides in
        /// </summary>
        [Required(ErrorMessage = "Mailing address' city")]
        [DisplayName("Address City")]
        public string ApptCity { get; set; }
        /// <summary>
        /// The state that the user resides in
        /// </summary>
        [Required(ErrorMessage = "Mailing address' state")]
        [DisplayName("Address State")]
        public string ApptState { get; set; }
        /// <summary>
        /// The zipcode of the users house, is stored as an int because most zipcodes are 5 digits long
        /// </summary>
        [Required(ErrorMessage = "Please enter 5 digit zipcode")]
        [DisplayName("Address Zipcode")]
        [StringLength(5,MinimumLength = 5)]
        [RegularExpression(@"^\d+$", ErrorMessage = "Please enter numbers only")]
        public string ApptZipcode { get; set; }
        /// <summary>
        /// The services that the user will select for their pet.
        /// </summary>
        [Required(ErrorMessage = "Need at least 1 service chosen")]
        [DisplayName("Chosen Service")]
        public string ApptServices { get; set; }
        /// <summary>
        /// The date of their appointment with time choices as well.
        /// </summary>
        [Required(ErrorMessage = "Need to know what date your coming in")]
        [DisplayName("Appointment date")]
        public DateTime ApptDate { get; set; }
        /// <summary>
        /// A toString override that will display the date the firstname lastname and pet associated for the customer to bring
        /// </summary>
        public override string ToString()
        {
            return ApptDate + " for " + ApptFirstName + ApptLastName + " and " + ApptPetName;
        }
    }
}
