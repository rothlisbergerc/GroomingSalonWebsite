using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroomingSalonWebsite.Models;
using GroomingSalonWebsite.Data;

namespace GroomingSalonWebsite.Controllers
{
    public class CustomerController : Controller
    {
        private readonly SalonContext _context;
        public CustomerController(SalonContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
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
    }
}
