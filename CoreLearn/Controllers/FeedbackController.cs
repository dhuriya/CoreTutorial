using CoreLearn.Models;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    public class FeedbackController : Controller
    {
        // GET: FeedbackController
        // GET: Display the form
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        // POST: Process the form
        [HttpPost]
        public IActionResult CreatePost(Feedback feedback)
        {
            if(ModelState.IsValid)
            {
                //Assume the feedback is saved to a database
                TempData["SuccessMessage"]="Thank you for your feedback!";
                return RedirectToAction("Confirmation");
            }
            return View(feedback);
        }
        //GET: Confirmation page
        [HttpGet]
        public IActionResult Confirmation()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }

    }
}
