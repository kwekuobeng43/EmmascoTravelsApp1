

using EmmascoTravelsApp1.Data;
using EmmascoTravelsApp1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EmmascoTravelsApp1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Index(bool? loginSuccess = null, bool? registrationSuccess = null)
        {
            ViewBag.LoginSuccess = loginSuccess;
            ViewBag.RegistrationSuccess = registrationSuccess;

            if (TempData["ProfileUpdated"] != null)
                ViewBag.ProfileUpdated = TempData["ProfileUpdated"];

            // ✅ Fetch all packages from DB
            var allPackages = _context.Packages.ToList();

            // ✅ Randomly pick 3 packages each time
            var random = new Random();
            var randomPackages = allPackages
                .OrderBy(p => random.Next())
                .Take(3)
                .ToList();

            // ✅ Pass them to the view
            return View(randomPackages);
        }



        // ✅ GET: EditProfile
        [HttpGet]
        public IActionResult EditProfile()
        {
            var username = HttpContext.Session.GetString("username");
            if (string.IsNullOrEmpty(username))
                return RedirectToAction("Login", "Account");

            var user = _context.Users.FirstOrDefault(u => u.Username == username);
            if (user == null) return NotFound();

            return View(user);
        }



        [HttpPost]
        public IActionResult EditProfile(User updatedUser, IFormFile ProfilePicture)
        {
            var username = HttpContext.Session.GetString("username");
            var user = _context.Users.FirstOrDefault(u => u.Username == username);

            if (user == null) return NotFound();

            // 🔑 update fields
            user.FirstName = updatedUser.FirstName;
            user.LastName = updatedUser.LastName;
            user.Email = updatedUser.Email;
            user.PhoneNumber = updatedUser.PhoneNumber;
            user.Address = updatedUser.Address;


            // ✅ Handle password change (only if user entered new password)
            if (!string.IsNullOrEmpty(updatedUser.NewPassword))
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(updatedUser.NewPassword);
            }

            if (ProfilePicture != null && ProfilePicture.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    ProfilePicture.CopyTo(ms);
                    user.ProfilePicture = ms.ToArray();
                }
            }

            _context.Users.Update(user);   //now EF will mark it as modified
            _context.SaveChanges();

            TempData["ProfileUpdated"] = "Profile updated successfully!";

            // ✅ Redirect based on role
            if (user.Role == "Admin")
            {
                return RedirectToAction("Index", "Admin"); // send to admin dashboard
            }
            else
            {
                return RedirectToAction("Index", "Home"); // send to user homepage
            }

        }

        // Contact form
        public IActionResult Contact()
        {
            return View();
        }
    }
}
