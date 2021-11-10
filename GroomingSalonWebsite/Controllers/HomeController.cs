using GroomingSalonWebsite.Data;
using GroomingSalonWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GroomingSalonWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SalonContext _context;

        public HomeController(ILogger<HomeController> logger, SalonContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult AppointmentConfirmation()
        {
            return View();
        }

        public IActionResult Reschedule()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(Appointment appt)
        {
            Customer c = new Customer()
            {
                FirstName = appt.ApptFirstName,
                LastName = appt.ApptLastName,
                PhoneNumber = appt.ApptPhoneNumber,
                HomeAddress = appt.ApptAddress1
            };
            //Converts the date that was entered vs whatever todays date is as to get the pets
            //total days then divides that by 365 to get their age in years.
            TimeSpan years = DateTime.Today.Subtract(appt.ApptPetBirthDay);
            int petAge = years.Days / 365;
            Pet p = new Pet()
            {
                Name = appt.ApptPetName,
                Breed = appt.ApptPetBreed,
                Age = petAge
            };
            if (ModelState.IsValid)
            {
                await SalonDB.addCustomerAsync(_context, c);
                await SalonDB.addPetAsync(_context, p);
                await SalonDB.addAppointmentAsync(_context, appt);
                return RedirectToAction("AppointmentConfirmation");
            }
            return View(appt);
        }
    }
}
