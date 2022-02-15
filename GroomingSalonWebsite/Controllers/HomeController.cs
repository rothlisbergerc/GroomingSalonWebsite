﻿using GroomingSalonWebsite.Data;
using GroomingSalonWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

//Controller for the hompeage that contains all the main chunks of information from the users.
namespace GroomingSalonWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SalonContext _context;
        //Create a logger for use later if need arises. Think it was autogenerated by the page.
        public HomeController(ILogger<HomeController> logger, SalonContext context)
        {
            _logger = logger;
            _context = context;
        }
        //All basic functions that were auto generated so that they create the associated index,privacy pages.
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
        //Simple appointment confirmed page that will appear as soon as the customer submits all valid info.
        public IActionResult AppointmentConfirmation()
        {
            return View();
        }
        //Allows for redirection to reschedule page.
        [HttpGet]
        public IActionResult Reschedule()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Reschedule(Appointment appointment)
        {
            //Returning first customer in the list to test out.
            Appointment appt = (Appointment)(from appoint in _context.Appointment where appoint.ApptPhoneNumber == appointment.ApptPhoneNumber select appoint).FirstOrDefault();
            if (appt != null)
            {
                TempData["ApptDate"] = appt.ApptDate;
            }
            return View();
        }
        //Error page to create problems incase they need to arise, it was autogenerated by the controller.
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        //The get version of add to just display the page.
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        //Post version where everything important that needs to happen for adding to the DB will.
        [HttpPost]
        public async Task<IActionResult> AddAsync(Appointment appt)
        {
            //Checking to ensure that the state isn't actually just left on the "Choose..." option.
            //The first && checks whether or not the pet was not born in the future.
            //The second && checks whether or not the appointment is actually sometime in the future and not in a past date.
            if(appt.ApptState == "Choose..." || appt.ApptPetBirthDay > DateTime.Today || appt.ApptDate < DateTime.Now.AddHours(1))
            {
                return View("Index");
            }
            //Create a new customer to pass into the DB so they get logged correctly from the 
            //appointments information
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
            //Similar to above where it simply just creates a pet to keep track of getting adding to the DB.
            Pet p = new Pet()
            {
                Name = appt.ApptPetName,
                Breed = appt.ApptPetBreed,
                Age = petAge
            };
            if (ModelState.IsValid)
            {
                //Runs all the adds in the DB to put each piece of information in its correct spot.
                await SalonDB.addCustomerAsync(_context, c);
                await SalonDB.addPetAsync(_context, p);
                await SalonDB.addAppointmentAsync(_context, appt);
                return RedirectToAction("AppointmentConfirmation");
            }
            return View(appt);
        }
        /*
        public IActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(Account acc)
        {
            if(ModelState.IsValid)
            {
                await SalonDB.addNewAccount(_context, acc);
                return RedirectToAction("Login");
            }
            return View(acc);
        }*/
    }
}
