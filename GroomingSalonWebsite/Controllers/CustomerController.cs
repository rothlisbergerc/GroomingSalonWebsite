using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroomingSalonWebsite.Models;
using GroomingSalonWebsite.Data;
using Microsoft.EntityFrameworkCore;

//Customercontroller to handle all the different customers that will get added into the DB from the home page.
namespace GroomingSalonWebsite.Controllers
{
    public class CustomerController : Controller
    {
        //Creation of the context and passing it into the controller so it can be used later.
        private readonly SalonContext _context;
        public CustomerController(SalonContext context)
        {
            _context = context;
        }
        //Basic index page that displays all customers on the screen.
        public async Task<IActionResult> Index()
        {
            List<Customer> customers = await SalonDB.getAllCustomersAsync(_context);
            return View(customers);
        }
        //Preversion of add that just displays the page.
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        //Post version where it will actually add the customer to the DB so long as they are valid
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
        //Just allows you to update any customer in the DB
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            Customer c = await SalonDB.getCustomerAsync(_context,id);

            return View(c);
        }
        //Post version where the update will actually take effect
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
        //Similar to update where this loads the delete page.
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Customer c = await SalonDB.getCustomerAsync(_context, id);
            return View(c);
        }
        //Post version where it will actually take effect and run the delete commands.
        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Customer c = await SalonDB.getCustomerAsync(_context, id);
            _context.Entry(c).State = EntityState.Deleted;
            await _context.SaveChangesAsync();

            TempData["Message"] = $"{c.FirstName} {c.LastName} was deleted successfully";


            return RedirectToAction("Index");
        }
    }
}
