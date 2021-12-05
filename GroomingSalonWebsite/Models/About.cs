using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//About class for the product nothing to crazy is needed to be had for it or displayed.
namespace GroomingSalonWebsite.Models
{
    public class About
    {
        public int aboutId { get; set; }
        public String aboutText { get; set; }
    }
}
