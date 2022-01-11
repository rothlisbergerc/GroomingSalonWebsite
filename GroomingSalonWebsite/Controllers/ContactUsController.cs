using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroomingSalonWebsite.Models;
using GroomingSalonWebsite.Data;
using Microsoft.EntityFrameworkCore;

/**
 * This is the controller for the contactUs page that is used for redirecting all the actions and links on the page.
 **/
namespace GroomingSalonWebsite.Controllers
{
    public class ContactUsController : Controller
    {
        //Creation of the context and controller for the class.
        private readonly SalonContext _context;
        public ContactUsController(SalonContext context)
        {
            _context = context;
        }
        //Basic index page that just returns all the messages the are currently in the controller.
        public async Task<IActionResult> Index()
        {
            List<ContactUs> Messages = await SalonDB.getContactMessageAsync(_context);
            return View(Messages);
        }
        //Basic view.
        public IActionResult ContactUs()
        {
            return View();
        }
        //Basic add page that if the user submits valid information then it returns to the contactUs page again.
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(ContactUs cm)
        {
            if(ModelState.IsValid)
            {
                await SalonDB.addContactMessage(_context, cm);
                return RedirectToAction("ContactUs");
            }
            return View(cm);
        }
        //Used for the delete page and validation.
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            ContactUs cm = await SalonDB.getMessageAsync(_context, id);
            return View(cm);
        }
        //Same as the above but it is for the post version rather than the get.
        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ContactUs cm = await SalonDB.getMessageAsync(_context, id);
            _context.Entry(cm).State = EntityState.Deleted;
            await _context.SaveChangesAsync();

            return RedirectToAction("Index","Home");
        }
        //Lets the user update their contactUs message if they need to.
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            ContactUs cm = await SalonDB.getMessageAsync(_context, id);
            return View(cm);
        }
        //Same as above but post version.
        [HttpPost]
        public async Task<IActionResult> Update(ContactUs cm)
        {
            if(ModelState.IsValid)
            {
                _context.Entry(cm).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return View(cm);
        }
    }
}
