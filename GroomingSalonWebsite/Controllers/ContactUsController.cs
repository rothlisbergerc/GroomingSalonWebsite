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
    public class ContactUsController : Controller
    {
        private readonly SalonContext _context;
        public ContactUsController(SalonContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<ContactUs> Messages = await SalonDB.getContactMessageAsync(_context);
            return View(Messages);
        }

        [HttpGet]
        public IActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ContactUs cm)
        {
            if(ModelState.IsValid)
            {
                await SalonDB.addContactMessage(_context, cm);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            ContactUs cm = await SalonDB.getMessageAsync(_context, id);
            return View(cm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ContactUs cm = await SalonDB.getMessageAsync(_context, id);
            _context.Entry(cm).State = EntityState.Deleted;
            await _context.SaveChangesAsync();

            return RedirectToAction("Index","Home");
        }
        /*
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        
        public async Task<IActionResult> Add(ContactUs cm)
        {
            if (ModelState.IsValid)
            {
                await SalonDB.addContactMessage(_context, cm);
                return RedirectToAction("Index");
            }
            return View();
        }*/
    }
}
