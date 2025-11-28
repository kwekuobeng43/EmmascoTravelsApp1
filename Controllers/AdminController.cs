
using ClosedXML.Excel;
using EmmascoTravelsApp1.Data;
using EmmascoTravelsApp1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmmascoTravelsApp1.Controllers
{
    public class AdminController : BaseController
    {
        public AdminController(AppDbContext context) : base(context) { }

        public IActionResult Index()
        {
            var model = new AdminDashboardViewModel
            {
                TotalUsers = _context.Users.Count(),
                //TotalCustomers = _context.Users.Count(),
                TotalPackages = _context.Packages.Count(),
                TotalBookings = _context.Bookings.Count(),
                TotalTrackings = _context.Trackings.Count(),



                // Status Counts
                CompletedBookings = _context.Trackings.Count(t => t.Status == "Completed"),
                PendingBookings = _context.Trackings.Count(t => t.Status == "Pending"),
                CancelledBookings = _context.Trackings.Count(t => t.Status == "Cancelled"),

                 

            };

            return View(model);

        }



        
    }
}

    




