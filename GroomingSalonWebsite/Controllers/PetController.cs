using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroomingSalonWebsite.Models;
using GroomingSalonWebsite.Data;
using Microsoft.EntityFrameworkCore;

//Controller for the pet class that will allow pets to be added to the DB
namespace GroomingSalonWebsite.Controllers
{
    public class PetController : Controller
    {
        private readonly SalonContext _context;
        public PetController(SalonContext context)
        {
            _context = context;
        }
        //The index page that will display all of the pets on the page and have access to the update,delete etc.
        public async Task<IActionResult> Index()
        {
            List<Pet> pets = await SalonDB.getAllPetsAsync(_context);
            return View(pets);
        }
        //Getter version of add that allows you to see the page.
        [HttpGet]
        public IActionResult add()
        {
            return View();
        }
        //Post version that will actually run the add in the DB.
        [HttpPost]
        public async Task<IActionResult> Add(Pet p)
        {
            if (ModelState.IsValid)
            {
                await SalonDB.addPetAsync(_context, p);
                return RedirectToAction("Index");
            }
            return View();
        }
        //Get version for update that allows you to see the information and passes them to the DB.
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            Pet p = await SalonDB.getPetAsync(_context, id);
            return View(p);
        }
        //Runs when a valid pet is entered and valid data is passed through.
        [HttpPost]
        public async Task<IActionResult> Update(Pet p)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(p).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                ViewData["Message"] = $"{p.Name} updated successfully";
            }
            return View(p);
        }
        //Get version for delete that will allow you to see the page.
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Pet p = await SalonDB.getPetAsync(_context, id);
            return View(p);
        }
        //Post version that will run when any data that gets correctly passed in to be erased.
        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Pet p = await SalonDB.getPetAsync(_context, id);
            _context.Entry(p).State = EntityState.Deleted;
            await _context.SaveChangesAsync();

            TempData["Message"] = $"{p.Name} was deleted successfully";

            return RedirectToAction("Index");
        }
    }
}
