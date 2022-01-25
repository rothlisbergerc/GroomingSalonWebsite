using GroomingSalonWebsite.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//DBContext class that sets up all the different contexts that get accessed throughout the entire project.
namespace GroomingSalonWebsite.Data
{
    public class SalonContext : IdentityDbContext<IdentityUser>
    {
        public SalonContext(DbContextOptions<SalonContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Pet> Pets { get; set; }

        public DbSet<ContactUs> ContactUs { get; set; }

        public DbSet<About> About { get; set; }

        public DbSet<Appointment> Appointment { get; set; }

        public DbSet<Account> Accounts { get; set; }
    }
}
