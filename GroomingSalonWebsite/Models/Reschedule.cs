using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroomingSalonWebsite.Models
{
    /// <summary>
    /// Takes a part of the reschedule page to keep track of the data.
    /// </summary>
    public class Reschedule
    {
        /// <summary>
        /// Simple ID to keep track of all the reschedules so I can make use of the context.
        /// </summary>
        [Key]
        public int RescheduleId { get; set; }
        /// <summary>
        /// Takes the appointment that gets passed in and stores it for later reference
        /// </summary>
        public Appointment Appointment { get; set; }
        /// <summary>
        /// Button state is whether it was a reschedule,update or cancel.
        /// </summary>
        /// Removing because no longer have a need for it.
        //public string ButtonState { get; set; }
        /// <summary>
        /// popUpConfirm is for when the pop up comes back and ensures whether the user wants to continue.
        /// </summary>
        public bool Confirmation { get; set; }
    }
}
