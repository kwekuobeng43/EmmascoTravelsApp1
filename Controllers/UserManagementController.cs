

using EmmascoTravelsApp1.Data;
using EmmascoTravelsApp1.Models;
using Microsoft.AspNetCore.Mvc;

public class UserManagementController : Controller
{
    private readonly AppDbContext _context;

    public UserManagementController(AppDbContext context)
    {
        _context = context;
    }

    // LIST USERS
    public IActionResult Index()
    {
        var users = _context.Users.ToList();
        return View(users);
    }

    // CREATE USER
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(User user, IFormFile ProfileImage)
    {
        if (string.IsNullOrEmpty(user.Password))
            user.Password = "12345"; // Default or generated password

        if (ModelState.IsValid)
        {
            if (ProfileImage != null && ProfileImage.Length > 0)
            {
                using var ms = new MemoryStream();
                ProfileImage.CopyTo(ms);
                user.ProfilePicture = ms.ToArray();
            }

            _context.Users.Add(user);
            _context.SaveChanges();
            TempData["Success"] = "User created successfully!";
            return RedirectToAction(nameof(Index));
        }

        return View(user);
    }

    // EDIT USER
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var user = _context.Users.Find(id);
        if (user == null)
            return NotFound();

        return View(user);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(User user, IFormFile ProfileImage)
    {
        // ❗ Remove fields that are not being edited in the form
        ModelState.Remove("Password");
        ModelState.Remove("Username");
        ModelState.Remove("ProfilePicture"); // Add this if your model marks it required

        var existingUser = _context.Users.Find(user.Id);
        if (existingUser == null)
            return NotFound();

        if (ModelState.IsValid)
        {
            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Email = user.Email;
            existingUser.PhoneNumber = user.PhoneNumber;
            existingUser.Address = user.Address;
            existingUser.Role = user.Role;

            if (ProfileImage != null && ProfileImage.Length > 0)
            {
                using var ms = new MemoryStream();
                ProfileImage.CopyTo(ms);
                existingUser.ProfilePicture = ms.ToArray();
            }

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        return View(user);
    }

    
    // DELETE USER
    public IActionResult Delete(int id)
    {
        var user = _context.Users.Find(id);
        if (user == null)
            return NotFound();

        _context.Users.Remove(user);
        _context.SaveChanges();
        TempData["Success"] = "User deleted successfully!";
        return RedirectToAction(nameof(Index));
    }
}




