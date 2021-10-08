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
    public class PetController : Controller
    {
        private readonly SalonContext _context;
        public PetController(SalonContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Pet> pets = await SalonDB.getAllPetsAsync(_context);
            return View(pets);
        }

        [HttpGet]
        public IActionResult add()
        {
            return View();
        }

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

        [HttpGet]
        public async Task<IActionResult> Update(int petId)
        {
            Pet p = await SalonDB.getPetAsync(_context, petId);
            return View(p);
        }

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
    }
}
