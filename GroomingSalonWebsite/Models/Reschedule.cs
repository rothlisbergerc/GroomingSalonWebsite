using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroomingSalonWebsite.Models
{
    public class Reschedule
    {
        public Appointment Appointment { get; set; }

        public string ButtonState { get; set; }

        public bool popUpConfirm { get; set; }
    }
}
