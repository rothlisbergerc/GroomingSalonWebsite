using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroomingSalonWebsite.Models
{
    public class About
    {
        public int aboutId { get; set; }
        public String aboutText { get; set; }
    }
}
