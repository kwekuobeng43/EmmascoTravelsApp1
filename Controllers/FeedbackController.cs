

using DocumentFormat.OpenXml.InkML;
using EmmascoTravelsApp1.Data;
using EmmascoTravelsApp1.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmmascoTravelsApp1.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly AppDbContext _context;

        public FeedbackController(AppDbContext context)
        {
            _context = context;
        }

        // View all messages
        public IActionResult ViewFeedbacks()
        {
            var feedbacks = _context.Feedbacks
                .OrderByDescending(f => f.Date)
                .ToList();
            return View(feedbacks);
        }

        // View one message in detail
        public IActionResult Details(int id)
        {
            var feedback = _context.Feedbacks.FirstOrDefault(f => f.Id == id);
            if (feedback == null) return NotFound();
            return View(feedback);
        }

        // Reply to customer via email (no DB change, just mailto:)
        public IActionResult Reply(int id)
        {
            var feedback = _context.Feedbacks.FirstOrDefault(f => f.Id == id);
            if (feedback == null) return NotFound();

            // open default email client with prefilled "To" and subject
            var mailto = $"mailto:{feedback.Email}?subject=Reply to your message&body=Hello {feedback.Name},%0D%0A%0D%0A";
            return Redirect(mailto);
        }
       

        // Admin: Delete feedback (with confirm in View)
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var feedback = _context.Feedbacks.Find(id);
            if (feedback != null)
            {
                _context.Feedbacks.Remove(feedback);
                _context.SaveChanges();
                TempData["Success"] = "Feedback deleted successfully!";
            }

            return RedirectToAction("ViewFeedbacks");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]//is an attribute used to protect your forms against CSRF attacks (Cross-Site Request Forgery).
        public IActionResult Submit(Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                feedback.Date = DateTime.Now;
                _context.Feedbacks.Add(feedback);
                _context.SaveChanges();

                TempData["Success"] = "Your message has been sent successfully!";
                return RedirectToAction("Contact", "Home");
            }

            // if invalid, reload Contact form with validation
            return View("~/Views/Home/Contact.cshtml", feedback);
        }

    }
}






