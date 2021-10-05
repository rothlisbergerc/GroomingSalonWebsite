using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GroomingSalonWebsite.Models;

namespace GroomingSalonWebsite.Data
{
    static public class SalonDB
    {
        public async static Task<List<Customer>> getAllCustomers(SalonContext _context)
        {
            return await (from c in _context.Customers 
                          orderby c.LastName ascending
                          select c).ToListAsync();
        }

        public async static Task<Customer> addCustomerAsync(SalonContext _context, Customer c)
        {
            _context.Customers.Add(c);
            await _context.SaveChangesAsync();
            return c;
        }

        public static async Task<Customer> getCustomerAsync(SalonContext _context, int custId)
        {
            Customer c = await (from customers in _context.Customers
                                where customers.CustomerId == custId
                                select customers).SingleAsync();

            return c;
        }
    }
}
