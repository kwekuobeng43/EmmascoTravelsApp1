


using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore;
using EmmascoTravelsApp1.Data;
using EmmascoTravelsApp1.Migrations;
using EmmascoTravelsApp1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmmascoTravelsApp1.Controllers
{
    public class BookingController : Controller
    {
        private readonly AppDbContext _context;

        public BookingController(AppDbContext context)
        {
            _context = context;
        }

        //Booking Form

        [HttpGet]
        public IActionResult Create(int packageId)
        {
            // ✅ Check if user is logged in
            var username = HttpContext.Session.GetString("username");
            if (string.IsNullOrEmpty(username))
            {
                // Save return URL in TempData so we can redirect back after login
                TempData["ReturnUrl"] = Url.Action("Create", "Booking", new { packageId });
               
                return RedirectToAction("Login", "Login", new { returnUrl = Url.Action("Create", "Booking", new { packageId }) });

            }

            var package = _context.Packages.Find(packageId);
            if (package == null)
            {
                return NotFound();
            }

            var booking = new Booking
            {
                PackageId = packageId,
                Package = package,
                BookingDate = DateTime.Now
            };

            return View(booking);
        }

      


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("PackageId,CustomerName,CustomerEmail,NumberOfPeople,TravelDate,ArrivalDate,PaymentOption")] Booking booking)
        {
            var username = HttpContext.Session.GetString("username");
            if (string.IsNullOrEmpty(username))
            {
                TempData["ReturnUrl"] = Url.Action("Create", "Booking", new { packageId = booking.PackageId });
                return RedirectToAction("Login", "Login", new { returnUrl = Url.Action("Create", "Booking", new { packageId = booking.PackageId }) });
            }

            if (!ModelState.IsValid)
            {
                booking.Package = _context.Packages.Find(booking.PackageId);
                return View(booking);
            }

            booking.BookingDate = DateTime.Now;
            _context.Bookings.Add(booking);
            _context.SaveChanges();

            // Automatically add tracking
            var tracking = new Tracking
            {
                BookingId = booking.Id,
                Status = "Pending"
            };
            _context.Trackings.Add(tracking);
            _context.SaveChanges();

            // ==============================
            // CREATE TRANSACTION RECORD
            // ==============================
            var package = _context.Packages.Find(booking.PackageId);

            var transaction = new Transaction
            {
                Username = username,
                BookingId = booking.Id,
                PackageId = package.Id,
                PackageName = package.Name,
                Amount = package.Price,
                PaymentOption = booking.PaymentOption,
                Status = "Pending",
                TransactionDate = DateTime.Now
            };

            _context.Transactions.Add(transaction);
            _context.SaveChanges();
            // ==============================

            return RedirectToAction("Confirmation", new { id = booking.Id });
        }






        //Booking Confirmation using of id to confirm
        public IActionResult Confirmation(int id)
        {
            var booking = _context.Bookings
                .Include(b => b.Package)
                .FirstOrDefault(b => b.Id == id);

            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }


        //MyBookings with a search
        public IActionResult MyBookings(string searchString)
        {
           

            var bookings = _context.Bookings
    .Include(b => b.Package)
    .Include(b => b.Trackings) // load statuses
    .AsQueryable();


            if (!string.IsNullOrEmpty(searchString))
            {
                bookings = bookings.Where(b =>
                    b.CustomerName.Contains(searchString) ||
                    b.CustomerEmail.Contains(searchString) ||
                    b.Package.Name.Contains(searchString) ||
                    b.Id.ToString().Contains(searchString)
                );
            }

            ViewData["CurrentFilter"] = searchString;

            return View(bookings.ToList());
        }

        // GET: Booking/Details
        public IActionResult Details(int id)
        {
            var booking = _context.Bookings
                .Include(b => b.Package)
                .FirstOrDefault(b => b.Id == id);

            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        public IActionResult Edit(int id)
        {
            var booking = _context.Bookings
                .Include(b => b.Package)
                .Include(b => b.Trackings) // load statuses
                .FirstOrDefault(b => b.Id == id);

            if (booking == null)
            {
                return NotFound();
            }

            // Get latest status
            ViewBag.CurrentStatus = booking.Trackings
                .OrderByDescending(t => t.Id)
                .Select(t => t.Status)
                .FirstOrDefault();

            ViewBag.Packages = _context.Packages.ToList();
            return View(booking);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Booking booking, string newStatus)
        {
            if (id != booking.Id)
            {
                return NotFound();
            }

            // Must remove validation errors for navigation props not bound in form
            ModelState.Remove("Package");
            ModelState.Remove("Trackings");

            if (ModelState.IsValid)
            {
                var existingBooking = _context.Bookings
                    .Include(b => b.Trackings)
                    .FirstOrDefault(b => b.Id == id);

                if (existingBooking == null)
                    return NotFound();

                // ✅ Update editable fields only
                existingBooking.PackageId = booking.PackageId;
                existingBooking.CustomerName = booking.CustomerName;
                existingBooking.CustomerEmail = booking.CustomerEmail;
                existingBooking.NumberOfPeople = booking.NumberOfPeople;
                existingBooking.TravelDate = booking.TravelDate;
                existingBooking.ArrivalDate = booking.ArrivalDate;
                existingBooking.PaymentOption = booking.PaymentOption;

                // ✅ Add a new tracking record if status changed
                if (!string.IsNullOrEmpty(newStatus))
                {
                    var tracking = new Tracking
                    {
                        BookingId = existingBooking.Id,
                        Status = newStatus
                    };
                    _context.Trackings.Add(tracking);
                }

                _context.SaveChanges();
                TempData["Success"] = "Booking updated successfully!";
                return RedirectToAction(nameof(MyBookings));
            }

            ViewBag.Packages = _context.Packages.ToList();
            return View(booking);
        }

        //Delete action
        [HttpPost]
        [ValidateAntiForgeryToken]//Prevents CSRF attacks when posting forms.
        public IActionResult Delete(int id)
        {
            var booking = _context.Bookings.Find(id);
            if (booking == null)
            {
                return NotFound();
            }

            _context.Bookings.Remove(booking);
            _context.SaveChanges();

            return RedirectToAction(nameof(MyBookings));
        }



    }
}