



using EmmascoTravelsApp1.Data;
using EmmascoTravelsApp1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmmascoTravelsApp1.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly AppDbContext _context;


        public RegistrationController(AppDbContext context)
        {
            _context = context;
        }

        //getting the details from the user to be used for the registration process before granting accesss to the home page
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        //now using that details to grant you access to the home page and also before checking your role before giving access
        //various role base whether standard user or admin
        [HttpPost]
        public IActionResult Register(RegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(model.Password);



                var user = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Username = model.Username,
                    Email = model.Email,
                    Password = hashedPassword,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address,
                    Role = model.Username.ToLower() == "admin" ? "Admin" : "Standard User"
                };


                _context.Users.Add(user);
                _context.SaveChanges();

                HttpContext.Session.SetString("username", user.Username);

                return RedirectToAction("Index", "Home", new { registrationSuccess = true });
            }

            return View(model);
        }
    }
}
        

        