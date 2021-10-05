using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroomingSalonWebsite.Models;
using GroomingSalonWebsite.Data;
using Microsoft.EntityFrameworkCore;

namespace GroomingSalonWebsite.Controllers
{
    public class CustomerController : Controller
    {
        private readonly SalonContext _context;
        public CustomerController(SalonContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Customer> customers = await SalonDB.getAllCustomers(_context);
            return View(customers);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Customer c)
        {
            if (ModelState.IsValid)
            {
                await SalonDB.addCustomerAsync(_context, c);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            Customer c = await SalonDB.getCustomerAsync(_context,id);

            return View(c);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Customer c)
        {
            if(ModelState.IsValid)
            {
                _context.Entry(c).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                ViewData["Message"] = $"{c.FirstName} {c.LastName} updated successfully";
            }
            return View(c);
        }
    }
}
