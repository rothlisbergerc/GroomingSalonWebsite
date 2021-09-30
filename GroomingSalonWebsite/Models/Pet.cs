using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroomingSalonWebsite.Models
{
    public class Pet
    {
        public int PetId { get; set; }

        public String Name { get; set; }

        public String Breed { get; set; }

        //Made a float because most animals won't live past roughly 25-30 
        public float Age { get; set; }

        public override string ToString()
        {
            return Name + " " + Breed;
        }
    }
}
