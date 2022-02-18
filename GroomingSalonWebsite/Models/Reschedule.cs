using System;
using System.Collections.Generic;
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
        /// Takes the appointment that gets passed in and stores it for later reference
        /// </summary>
        public Appointment Appointment { get; set; }
        /// <summary>
        /// Button state is whether it was a reschedule,update or cancel.
        /// </summary>
        public string ButtonState { get; set; }
        /// <summary>
        /// popUpConfirm is for when the pop up comes back and ensures whether the user wants to continue.
        /// </summary>
        public bool popUpConfirm { get; set; }
    }
}
