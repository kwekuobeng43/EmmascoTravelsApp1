



using EmmascoTravelsApp1.Data;
using EmmascoTravelsApp1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmmascoTravelsApp1.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILogger<LoginController> _logger;

        public LoginController(AppDbContext context, ILogger<LoginController> logger)
        {
            _context = context;
            _logger = logger;
        }

        //taking the details from the user to logging-in him
       


        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            if (!string.IsNullOrEmpty(returnUrl))
            {
                TempData["ReturnUrl"] = returnUrl;
            }

            return View();
        }



        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = _context.Users.FirstOrDefault(u => u.Username == model.Username);
                    if (user != null && BCrypt.Net.BCrypt.Verify(model.Password, user.Password))
                    {
                        HttpContext.Session.SetString("username", user.Username);
                        HttpContext.Session.SetString("role", user.Role);

                        // 🔒 ADMIN: never follow ReturnUrl
                        if (user.Role == "Admin")
                        {
                            return RedirectToAction("Index", "Admin");
                        }

                        // 👤 STANDARD USER: follow ReturnUrl if available
                        if (TempData["ReturnUrl"] != null)
                        {
                            string returnUrl = TempData["ReturnUrl"].ToString();
                            return Redirect(returnUrl);
                        }

                        // Default for standard user
                        return RedirectToAction("Index", "Home", new { loginSuccess = true });
                    }

                    ModelState.AddModelError("", "Invalid username or password");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while verifying password");
                    ModelState.AddModelError("", "An error occurred while verifying password");
                }
            }

            return View(model);
        }



        public IActionResult Logout() //Logout
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}