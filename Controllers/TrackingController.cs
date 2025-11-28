

using EmmascoTravelsApp1.Data;
using EmmascoTravelsApp1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EmmascoTravelsApp1.Controllers
{
    public class TrackingController : Controller
    {
        private readonly AppDbContext _context;

        public TrackingController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Tracking
        public IActionResult Index()
        {
            var trackings = _context.Trackings
                .Include(t => t.Booking)
                .ThenInclude(b => b.Package)
                .OrderByDescending(t => t.Date)
                .ToList();

            return View(trackings);
        }

        // GET: /Tracking/Details/5
        public IActionResult Details(int id)
        {
            var track = _context.Trackings
                .Include(t => t.Booking)
                .ThenInclude(b => b.Package)
                .FirstOrDefault(t => t.Id == id);

            if (track == null) 

                return NotFound();

            return View(track);
        }

        // GET: /Tracking/Edit/5




        [HttpPost]
        public IActionResult Details(string email, int bookingId)
        {
            if (string.IsNullOrEmpty(email) || bookingId == 0)
            {
                ViewBag.Error = "Email and Booking ID are required.";
                return View("TrackForm"); // your form view
            }

            // Find tracking by BookingID + Email
            var tracking = _context.Trackings
                .Include(t => t.Booking)
                .ThenInclude(b => b.Package)
                .FirstOrDefault(t =>
                    t.BookingId == bookingId &&
                    t.Booking.CustomerEmail.ToLower() == email.ToLower()
                );

            if (tracking == null)
            {
                ViewBag.Error = "No tracking information found for these details.";
                return View("TrackForm");
            }

            return View(tracking); // show tracking details
        }



        public IActionResult Edit(int id)
        {
            var track = _context.Trackings
                .Include(t => t.Booking)
                .ThenInclude(b => b.Package)
                .FirstOrDefault(t => t.Id == id);

            if (track == null) return NotFound();

            ViewBag.StatusList = new List<string> { "Pending", "Confirmed", "Cancelled", "Completed" };
            // Check for null navigation properties
            if (track.Booking == null)
                track.Booking = new Booking();
            return View(track);
        }

        // POST: /Tracking/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Tracking track)
        {
            if (id != track.Id) return NotFound();

            if (ModelState.IsValid)
            {
                // Update Date whenever editing
                track.Date = DateTime.Now;
                _context.Update(track);
                _context.SaveChanges();
                TempData["Success"] = "Tracking updated successfully!";
                return RedirectToAction(nameof(Index));
            }

            return View(track);
        }

        // GET: /Tracking/AdminIndex
        public IActionResult AdminViewer(string searchString)
        {
            var trackings = _context.Trackings
                .Include(t => t.Booking)
                .ThenInclude(b => b.Package)
                .OrderByDescending(t => t.Date)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                trackings = trackings.Where(t =>
                    t.Booking.CustomerName.Contains(searchString) ||
                    t.Booking.Package.Name.Contains(searchString) ||
                    t.Id.ToString().Contains(searchString)
                );
            }

            return View(trackings.ToList());
        }

        // GET: /Tracking/Create
       


        // GET: Tracking/Create
        public IActionResult Create()
        {
            // Assuming you want to select from existing bookings
            var bookings = _context.Bookings
                                   .Include(b => b.Package)
                                   .Select(b => new { b.Id, Display = b.CustomerName + " - " + b.Package.Name })
                                   .ToList();

            ViewBag.Bookings = new SelectList(bookings, "Id", "Display");
            return View();
        }


        // POST: /Tracking/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Tracking track)
        {
            if (ModelState.IsValid)
            {
                track.Date = DateTime.Now; // Set timestamp on creation
                _context.Trackings.Add(track);
                _context.SaveChanges();
                TempData["Success"] = "Tracking added successfully!";
                return RedirectToAction(nameof(AdminViewer));
            }

            return View(track);
        }



        [HttpGet]
        public IActionResult AdminDetails(int id)
        {
            var tracking = _context.Trackings
                .Include(t => t.Booking)
                .ThenInclude(b => b.Package)
                .FirstOrDefault(t => t.Id == id);

            if (tracking == null)
                return NotFound();

            return View(tracking); // AdminDetails.cshtml
        }


        // POST: /Tracking/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var track = _context.Trackings.Find(id);
            if (track != null)
            {
                _context.Trackings.Remove(track);
                _context.SaveChanges();
                TempData["Success"] = "Tracking deleted successfully!";
            }
            return RedirectToAction(nameof(AdminViewer));
        }
    }
}
