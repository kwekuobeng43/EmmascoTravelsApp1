

using EmmascoTravelsApp1.Data;
using EmmascoTravelsApp1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmmascoTravelsApp1.Controllers
{
    public class PackageController : Controller
    {
        private readonly AppDbContext _context;

        public PackageController(AppDbContext context)
        {
            _context = context;
        }

        // All the packages
        public IActionResult Index()
        {
            var packages = _context.Packages.ToList();
            return View(packages);
        }

        // Get package by ID
        public Package GetPackage(int id)
        {
            return _context.Packages.Find(id);
        }

        public async Task<IActionResult> Details(int id)
        {
            var package = await _context.Packages
                .Include(p => p.Reviews)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (package == null)
                return NotFound();

            return View(package);
        }

        [HttpPost]
        public async Task<IActionResult> AddReview(int packageId, string reviewerName, string comment, int rating)
        {
            var review = new Review
            {
                PackageId = packageId,
                ReviewerName = reviewerName,
                Comment = comment,
                Rating = rating,
                Date = DateTime.Now
            };

            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", new { id = packageId });
        }

        // GET: Package/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //retreive and display the packages details for CRUD actions in trhe admin index side
        public IActionResult AdminIndex()
        {
            var packages = _context.Packages.ToList();
            return View(packages);
        }

        //this creates a new package into the database by providing the form to be filled and display on the
        //packages index/view
        [HttpPost]
        public IActionResult Create(Package package)
        {
            if (ModelState.IsValid)
            {
                _context.Packages.Add(package);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(package);
        }


        // GET: Package and make a changes to the package and return it to the view 
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var package = _context.Packages.Find(id);
            if (package == null)
            {
                return NotFound();
            }
            return View(package);
        }

        //now we display the updated packages made by any changes and redirect to the index
        [HttpPost]
        public IActionResult Edit(Package package)
        {
            if (ModelState.IsValid)
            {
                var existingPackage = _context.Packages.Find(package.Id);
                if (existingPackage == null)
                {
                    return NotFound();
                }

                // Explicitly update allowed fields
                existingPackage.Name = package.Name;
                existingPackage.Description = package.Description;
                existingPackage.Price = package.Price;
                existingPackage.ImageUrl = package.ImageUrl;
                existingPackage.Status = package.Status;
                existingPackage.Duration = package.Duration;
                existingPackage.Accommodation = package.Accommodation;
                existingPackage.Meals = package.Meals;
                existingPackage.Transport = package.Transport;
                existingPackage.Activities = package.Activities;
                existingPackage.Country = package.Country;

                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(package);
        }

        //deletion of a package by finding it with its id and redirect to the action view "AdminIndex"
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var package = _context.Packages.Find(id);
            if (package == null)
            {
                return NotFound();
            }

            _context.Packages.Remove(package);
            _context.SaveChanges();

            return RedirectToAction("AdminIndex");  
        }

    }
}

