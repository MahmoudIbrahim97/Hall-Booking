using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Microsoft.AspNet.Identity;
using E7GeZlY.Models;
using System.Collections.Generic;
using System;

namespace E7GeZlY.Controllers
{
    public class HallsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Halls
        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            var halls = db.Halls.Include(h => h.MyCategory);
            return View(halls.ToList());
        }

        // GET: Halls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hall hall = db.Halls.Find(id);
            if (hall == null)
            {
                return HttpNotFound();
            }
            return View(hall);
        }

        // GET: Halls/Create
        [Authorize(Roles = "Hall Owner")]
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName");
            return View();
        }

        // POST: Halls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Hall hall, HttpPostedFileBase upload)
        {
            int Exist = db.Licenses.Where(a=> a.LicenseNumber==hall.License).Select(a => a.LicenseNumber).Count();
            int Taken = db.Halls.Where(a => a.License == hall.License).Select(a=> a.License).Count();
            if (ModelState.IsValid)
            {
                if (Exist > 0)
                {
                    if (Taken > 0)
                    {
                        ViewBag.Wrong = "This License is used by another Hall";
                    }

                    else
                    {
                        string path = Path.Combine(Server.MapPath("~/Images"), upload.FileName);
                        upload.SaveAs(path);
                        hall.Image = upload.FileName;
                        string myid = User.Identity.GetUserId();
                        hall.UserId = myid;
                        db.Halls.Add(hall);
                        db.SaveChanges();
                        return RedirectToAction("GetOwnerHalls");
                    }
                    
                }
                else
                {
                    ViewBag.Wrong = "Invalid License";
                }
                
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", hall.CategoryId);
            return View(hall);
        }

        // GET: Halls/Edit/5
        [Authorize(Roles = "Hall Owner")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hall hall = db.Halls.Find(id);
            if (hall == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", hall.CategoryId);
            return View(hall);
        }

        // POST: Halls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Hall hall , HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/Images"), upload.FileName);
                upload.SaveAs(path);
                hall.Image = upload.FileName;
                db.Entry(hall).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("GetOwnerHalls");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", hall.CategoryId);
            return View(hall);
        }

        // GET: Halls/Delete/5
        [Authorize(Roles = "Administrator,Hall Owner")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hall hall = db.Halls.Find(id);
            if (hall == null)
            {
                return HttpNotFound();
            }
            return View(hall);
        }

        // POST: Halls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hall hall = db.Halls.Find(id);
            db.Halls.Remove(hall);
            db.SaveChanges();
            return RedirectToAction("GetOwnerHalls");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [Authorize]
        public ActionResult Book(int id)
        {
            Session["HallId"] = id;
            ViewBag.Service1 = db.Halls.Where(a=> a.Id == id).Select(a => a.AdditionalService).Single();
            ViewBag.Service2 = db.Halls.Where(a => a.Id == id).Select(a => a.Service2).Single();
            ViewBag.Service3 = db.Halls.Where(a => a.Id == id).Select(a => a.Service3).Single();
            ViewBag.Service4 = db.Halls.Where(a => a.Id == id).Select(a => a.Service4).Single();
            ViewBag.Service5 = db.Halls.Where(a => a.Id == id).Select(a => a.Service5).Single();
            ViewBag.Service6 = db.Halls.Where(a => a.Id == id).Select(a => a.Service6).Single();
            ViewBag.Service7 = db.Halls.Where(a => a.Id == id).Select(a => a.Service7).Single();
            ViewBag.Service8 = db.Halls.Where(a => a.Id == id).Select(a => a.Service8).Single();
            ViewBag.Service9 = db.Halls.Where(a => a.Id == id).Select(a => a.Service9).Single();


            ViewBag.BookedDays = db.MyBookings.Where(a => a.HallId == id).Select(a => a.BookingDate).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Book(MyBooking booking)
        {
            int id = (int)Session["HallId"];

            ViewBag.BookedDays = db.MyBookings.Where(a => a.HallId == id).Select(a => a.BookingDate).ToList();


            ViewBag.Service1 = db.Halls.Where(a => a.Id == id).Select(a => a.AdditionalService).Single();
            ViewBag.Service2 = db.Halls.Where(a => a.Id == id).Select(a => a.Service2).Single();
            ViewBag.Service3 = db.Halls.Where(a => a.Id == id).Select(a => a.Service3).Single();
            ViewBag.Service4 = db.Halls.Where(a => a.Id == id).Select(a => a.Service4).Single();
            ViewBag.Service5 = db.Halls.Where(a => a.Id == id).Select(a => a.Service5).Single();
            ViewBag.Service6 = db.Halls.Where(a => a.Id == id).Select(a => a.Service6).Single();
            ViewBag.Service7 = db.Halls.Where(a => a.Id == id).Select(a => a.Service7).Single();
            ViewBag.Service8 = db.Halls.Where(a => a.Id == id).Select(a => a.Service8).Single();
            ViewBag.Service9 = db.Halls.Where(a => a.Id == id).Select(a => a.Service9).Single();
            booking.HallId = id;
            booking.UserId = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                char[] seperator = {':'};
                string s = db.MyBookings.Where(a => a.HallId == id && a.BookingDate == booking.BookingDate).Select(a => a.StartTime).Single();
                string[] StartDbArray = s.Split(seperator);
                int DbStart = Convert.ToInt32(StartDbArray[0]);
                string e = db.MyBookings.Where(a => a.HallId == id && a.BookingDate == booking.BookingDate).Select(a => a.EndTime).Single();
                string[] EndDbArray = e.Split(seperator);
                int DbEnd = Convert.ToInt32(EndDbArray[0]);

                string[] StartBookingArray = booking.StartTime.Split(seperator);
                int bookingStart = int.Parse(StartBookingArray[0]);

                string[] EndBookingArray = booking.EndTime.Split(seperator);
                int bookingEnd = int.Parse(EndBookingArray[0]);

                if (bookingStart > DbStart && bookingEnd < DbEnd)
                {
                    ViewBag.Failure = "Sorry, the hall is booked during this interval";
                }
                else if (bookingStart < DbStart && bookingEnd > DbStart)
                {
                    ViewBag.Failure = "Sorry, the hall is booked during this interval";
                }
                else
                {
                    db.MyBookings.Add(booking);
                    db.SaveChanges();
                    ViewBag.Success = "The Hall Booked Successfully";
                }

                //int Checking = db.MyBookings.Where(a => a.BookingDate == booking.BookingDate && a.HallId == booking.HallId).Count();
                //if (Checking < 1)
                //{
                //    db.MyBookings.Add(booking);
                //    db.SaveChanges();
                //    ViewBag.Success = "The Hall Booked Successfully";
                //}
                //else
                //{
                //    ViewBag.Failure = "Sorry, The Hall is booked during this day";

                //}
            }

            return View(booking);
        }
            

        [Authorize(Roles ="Hall Owner")]
        public ActionResult GetOwnerHalls()
        {
            var id = User.Identity.GetUserId();
            List<Hall> halls = db.Halls.Where(a => a.UserId == id).ToList();
            return View("Index", halls);
        }

        public ActionResult Search()
        {
            ViewBag.CategoryId = new SelectList(db.Categories.ToList(), "Id", "CategoryName");
            return View();
        }

        [HttpPost]
        public ActionResult Search(string SearchText)
        {
            Session["searchtext"] = SearchText;
            List<Hall> halls = db.Halls.Where(a => a.HallName.Contains(SearchText)
                                                || a.County.Contains(SearchText)
                                                || a.City.Contains(SearchText)
                                                || a.Address.Contains(SearchText)).ToList();
            ViewBag.CategoryId = new SelectList(db.Categories.ToList(), "Id", "CategoryName");
            return View(halls);
        }

        public ActionResult Filter()
        {
            ViewBag.CategoryId = new SelectList(db.Categories.ToList(), "Id", "CategoryName");
            return View("Search");
        }
        [HttpPost]
        public ActionResult Filter(int? CategoryId , int min=0 , int max=99999)
        {
            string SearchText = (string)Session["searchtext"];
            ViewBag.CategoryId = new SelectList(db.Categories.ToList(), "Id", "CategoryName");
            if (ModelState.IsValid)
            {
                if (CategoryId != null)
                {
                        List<Hall> halls = db.Halls.Where(a => (a.HallName.Contains(SearchText)
                                                        || a.County.Contains(SearchText)
                                                        || a.City.Contains(SearchText)
                                                        || a.Address.Contains(SearchText))
                                                        && (a.Price >= min) && (a.Price <= max) && (a.CategoryId== CategoryId)).ToList();
                        return View("Search",halls);
                }
                else
                {
                    List<Hall> halls = db.Halls.Where(a => (a.HallName.Contains(SearchText)
                                                        || a.County.Contains(SearchText)
                                                        || a.City.Contains(SearchText)
                                                        || a.Address.Contains(SearchText))
                                                        && (a.Price >= min) && (a.Price <= max)).ToList();
                    return View("Search", halls);
                }
                
            }
            return View("Search");
        }
    }
}