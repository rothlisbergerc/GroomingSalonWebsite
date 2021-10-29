using GroomingSalonWebsite.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroomingSalonWebsite.Data
{
    public class SalonContext : DbContext
    {
        public SalonContext(DbContextOptions<SalonContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Pet> Pets { get; set; }

        public DbSet<ContactUs> ContactUs { get; set; }

        public DbSet<GroomingSalonWebsite.Models.About> About { get; set; }
    }
}
