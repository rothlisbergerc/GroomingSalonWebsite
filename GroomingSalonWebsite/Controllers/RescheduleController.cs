using GroomingSalonWebsite.Data;
using GroomingSalonWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroomingSalonWebsite.Controllers
{
    public class RescheduleController : Controller
    {
        private readonly SalonContext _context;
        //Create a logger for use later if need arises. Think it was autogenerated by the page.
        public RescheduleController(SalonContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult RescheduleCancel()
        {
            Reschedule rescheduled = (from resched in _context.Reschedules where resched.Confirmation == true select resched).Include(nameof(Appointment)).FirstOrDefault();
            TempData["ApptDate"] = rescheduled.Appointment.ApptDate;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RescheduleCancelAsync(string cancelButton)
        {
            Reschedule rescheduled = (from resched in _context.Reschedules where resched.Confirmation == true select resched).Include(nameof(Appointment)).FirstOrDefault();
            //Changing it back to false no matter what the user decides.
            rescheduled.Confirmation = false;
            //Catches the user incase they push yes after submitting the initial cancellation.
            if (cancelButton == "Yes" && rescheduled != null)
            {
                //Erasing out the appointment if the user selects yes.
                Appointment ap = await SalonDB.getAppointmentAsync(_context, rescheduled.Appointment.AppointmentId);
                _context.Entry(ap).State = EntityState.Deleted;
                _context.Entry(rescheduled).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
                TempData["ApptDate"] = "You have successfully cancelled this appointment.";
            }
            //Turns the user back to the reschedule page
            if (cancelButton == "No")
            {
                return RedirectToAction("Reschedule", "Home");
            }
            return View();
        }

        [HttpGet]
        public IActionResult RescheduleResched()
        {
            Reschedule rescheduled = (from resched in _context.Reschedules where resched.Confirmation == true select resched).Include(nameof(Appointment)).FirstOrDefault();
            TempData["ApptDate"] = rescheduled.Appointment.ApptDate;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RescheduleReschedAsync(Reschedule newerDate)
        {
            Reschedule rescheduled = (from resched in _context.Reschedules where resched.Confirmation == true select resched).Include(nameof(Appointment)).FirstOrDefault();
            //Changing it back to false no matter what the user decides.
            rescheduled.Confirmation = false;
            //Ensuring that the user enters a valid updated appointment date.
            ModelState.Clear();
            if (ModelState.IsValid && newerDate.Appointment.ApptDate > rescheduled.Appointment.ApptDate)
            {
                rescheduled.Appointment.ApptDate = newerDate.Appointment.ApptDate;
                _context.Entry(rescheduled.Appointment).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                //Editing slight tempdata so that the information is available to see the update.
                TempData["Rescheduled"] = "Good";
                TempData["ApptDate"] = "Great! Your appointment is set for " + newerDate.Appointment.ApptDate + " !";
            }
            else
            {
                return RedirectToAction("Reschedule", "Home");
            }
            return View();
        }

        [HttpGet]
        public IActionResult RescheduleUpdate()
        {
            Reschedule rescheduled = (from resched in _context.Reschedules where resched.Confirmation == true select resched).Include(nameof(Appointment)).FirstOrDefault();
            return View(rescheduled.Appointment);
        }
        
        [HttpPost]
        public async Task<IActionResult> RescheduleUpdateAsync(Appointment appt)
        {
            Reschedule rescheduled = (from resched in _context.Reschedules where resched.Confirmation == true select resched).Include(nameof(Appointment)).FirstOrDefault();
            //Changing it back to false no matter what the user decides.
            rescheduled.Confirmation = false;
            ModelState.Clear();
            if(ModelState.IsValid && appt != null)
            {
                Exchange(appt, rescheduled);
                _context.Entry(rescheduled.Appointment).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                TempData["Rescheduled"] = "Good";
                TempData["ApptDate"] = "You have successfully updated your appointment";
            }
            else
            {
                return RedirectToAction("Reschedule", "Home");
            }
            return View();
        }

        public void Exchange(Appointment a1, Reschedule r1)
        {
            r1.Appointment.ApptAddress1 = a1.ApptAddress1;
            r1.Appointment.ApptAddress2 = a1.ApptAddress2;
            r1.Appointment.ApptCity = a1.ApptCity;
            r1.Appointment.ApptFirstName = a1.ApptFirstName;
            r1.Appointment.ApptLastName = a1.ApptLastName;
            r1.Appointment.ApptPetBirthDay = a1.ApptPetBirthDay;
            r1.Appointment.ApptPetBreed = a1.ApptPetBreed;
            r1.Appointment.ApptPetName = a1.ApptPetName;
            r1.Appointment.ApptPetWeight = a1.ApptPetWeight;
            r1.Appointment.ApptPhoneNumber = a1.ApptPhoneNumber;
            r1.Appointment.ApptServices = a1.ApptServices;
            r1.Appointment.ApptState = a1.ApptState;
            r1.Appointment.ApptZipcode = a1.ApptZipcode;
        }
    }
}
