using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GroomingSalonWebsite.Models;

//All the DB code that is needed to run the database aspect of the program.
namespace GroomingSalonWebsite.Data
{
    static public class SalonDB
    {
        //Gets a list of all customers that exist in the DB by use of a DB command.
        public static async Task<List<Customer>> getAllCustomersAsync(SalonContext _context)
        {
            return await (from c in _context.Customers 
                          orderby c.LastName ascending
                          select c).ToListAsync();
        }
        //The method to run to add a customer into the database asynchronously so as to be faster.
        public static async Task<Customer> addCustomerAsync(SalonContext _context, Customer c)
        {
            _context.Customers.Add(c);
            await _context.SaveChangesAsync();
            return c;
        }
        //Similar to the getting all customers but this grabs a singular customer vs the entire list.
        public static async Task<Customer> getCustomerAsync(SalonContext _context, int custId)
        {
            Customer c = await (from customers in _context.Customers
                                where customers.CustomerId == custId
                                select customers).SingleAsync();

            return c;
        }
        //Gets a list of all pets that exist in the DB by use of a DB command.
        public static async Task<List<Pet>> getAllPetsAsync(SalonContext _context)
        {
            return await (from p in _context.Pets
                          select p).ToListAsync();
        }
        //Adds a pet into the DB through the context.
        public static async Task<Pet> addPetAsync(SalonContext _context, Pet p)
        {
            _context.Pets.Add(p);
            await _context.SaveChangesAsync();
            return p;
        }
        //Same as getCustomer where instead it will grab a singular pet.
        public static async Task<Pet> getPetAsync(SalonContext _context, int petId)
        {
            Pet p = await (from pets in _context.Pets
                           where pets.PetId == petId
                           select pets).SingleAsync();
            return p;
        }
        //Gets a list of all appointments that exist in the DB by use of a DB command.
        public static async Task<List<Appointment>> getAllAppointmentsAsync(SalonContext _context)
        {
            return await (from ap in _context.Appointment
                          select ap).ToListAsync();
        }
        //Allows an appointment to get added into the DB.
        public static async Task<Appointment> addAppointmentAsync(SalonContext _context, Appointment ap)
        {
            _context.Appointment.Add(ap);
            await _context.SaveChangesAsync();
            return ap;
        }
        //Same as customer and pet where it will return a singular appointment instead of the whole list.
        public static async Task<Appointment> getAppointmnetAsync(SalonContext _context, int appointmentId)
        {
            Appointment ap = await (from appointments in _context.Appointment
                                    where appointments.AppointmentId == appointmentId
                                    select appointments).SingleAsync();
            return ap;
        }
        //Grabs all contactUs messages that currently reside in the DB
        public static async Task<List<ContactUs>> getContactMessageAsync(SalonContext _context)
        {
            return await (from cm in _context.ContactUs
                          select cm).ToListAsync();
        }
        //Adds a contactUs message into the DB
        public static async Task<ContactUs> addContactMessage(SalonContext _context, ContactUs cm)
        {
            _context.ContactUs.Add(cm);
            await _context.SaveChangesAsync();
            return cm;
        }
        //Grabs a singular contactUs message vs the whole list
        public static async Task<ContactUs> getMessageAsync(SalonContext _context, int cmId)
        {
            ContactUs message = await (from cm in _context.ContactUs
                                       where cm.messageId == cmId
                                       select cm).SingleAsync();
            return message;
        }
        //Getting all the customer accounts that exist in the database.
        public static async Task<List<Account>> getAllAccounts(SalonContext _context)
        {
            return await (from acc in _context.Accounts
                          select acc).ToListAsync();
        }
        //Adding a new users account into the DB.
        public static async Task<Account> addNewAccount(SalonContext _context, Account acc)
        {
            _context.Accounts.Add(acc);
            await _context.SaveChangesAsync();
            return acc;
        }
        //Retrieving a singular users account based on their id.
        public static async Task<Account> getAccountAsync(SalonContext _context, int accId)
        {
            Account userAcc = await (from acc in _context.Accounts
                                     where acc.AccountId == accId
                                     select acc).SingleAsync();
            return userAcc;
        }

        public static async Task<Reschedule> addRescheduleAsync(SalonContext _context, Reschedule r)
        {
            _context.Reschedules.Add(r);
            await _context.SaveChangesAsync();
            return r;
        }
    }
}
