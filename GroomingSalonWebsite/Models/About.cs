using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroomingSalonWebsite.Models
{
    [Keyless]
    public class About
    {
        public String aboutText { get; set; }
    }
}
