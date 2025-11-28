


using EmmascoTravelsApp1.Data;
using EmmascoTravelsApp1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmmascoTravelsApp1.Controllers
{
    public class TransactionController : Controller
    {
        private readonly AppDbContext _context;

        public TransactionController(AppDbContext context)
        {
            _context = context;
        }

        // USER view: My Transactions
        public IActionResult MyTransactions()
        {
            var username = HttpContext.Session.GetString("username");

            if (string.IsNullOrEmpty(username))
                return RedirectToAction("Login", "Login");

            var transactions = _context.Transactions
                .Where(t => t.Username == username)
                .OrderByDescending(t => t.TransactionDate)
                .ToList();

            return View(transactions);
        }

        // ADMIN view
        public IActionResult AllTransactions()
        {
            var role = HttpContext.Session.GetString("role");

            if (role != "Admin")
                return Unauthorized();

            var transactions = _context.Transactions
                .OrderByDescending(t => t.TransactionDate)
                .ToList();

            return View(transactions);
        }
    }
}

