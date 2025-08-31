using Microsoft.AspNetCore.Mvc;
using FeedbackPortal.Models;
using System.Collections.Generic;

namespace FeedbackPortal.Controllers
{
    public class FeedbackController : Controller
    {
        private static List<Feedback> feedbackList = new();

        public IActionResult Index() => View();

        [HttpPost]
        public IActionResult Index(Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                feedbackList.Add(feedback);
                return RedirectToAction("Submitted");
            }
            return View();
        }

        public IActionResult Submitted() => View(feedbackList);
    }
}
