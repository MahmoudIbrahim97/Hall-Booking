using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E7GeZlY.Models;
using System.Data.Entity;

namespace E7GeZlY.Controllers
{
    public class BookingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Bookings
        [Authorize]
        public ActionResult MyBookings()
        {
            var UserId = User.Identity.GetUserId();
            List<MyBooking> Mybookings = db.MyBookings.Where(a => a.UserId == UserId).ToList();
            return View(Mybookings);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            MyBooking booking = db.MyBookings.Single(a => a.Id == id);
            return View(booking);
        }

        [HttpPost]
        public ActionResult Edit(MyBooking mybooking)
        {
            if (ModelState.IsValid)
            {
                var Check = (mybooking.BookingDate - DateTime.Now).TotalDays;
                if(Check > 15)
                {
                    db.Entry(mybooking).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("MyBookings");
                }
                else
                {
                    ViewBag.Sorry = "Sorry, You can't edit your booking in less than 15 days of booking date";
                }
            }
            return View();
        }

        [Authorize(Roles = "Hall Owner")]
        public ActionResult OwnerBookedHalls()
        {
            string userid = User.Identity.GetUserId();
            var bookings = from booking in db.MyBookings
                           join hall in db.Halls
                           on booking.Id equals hall.Id
                           where hall.User.Id == userid
                           select booking;

            var grouped = from hall2 in bookings
                          group hall2 by hall2.MyHall.HallName
                          into group1
                          select new BookingsViewModel
                          {
                              HallName = group1.Key,
                              Items = group1
                          };


            return View(grouped.ToList());
        }

        [Authorize]
        public ActionResult Details(int id)
        {
            MyBooking booking = db.MyBookings.Single(a => a.Id == id);
            return View(booking);
        }

    }
}