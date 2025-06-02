using CoreActionResult.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreActionResult.Controllers
{
    public class ModelBindingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            var model = new User();
            ViewBag.Countries = new List<string>
            {
                "United States",
                "Canada",
                "United Kingdom",
                "Australia",
                "India"
            };
            ViewBag.Hobbies = new List<string>
            {
                "Reading",
                "Traveling",
                "Gaming",
                "Cooking"
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Create([FromForm] User user)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.Countries = new List<string>
                {
                    "United States",
                    "Canada",
                    "United Kingdom",
                    "Australia",
                    "India"
                };
                    ViewBag.Hobbies = new List<string>
                {
                    "Reading",
                    "Traveling",
                    "Gaming",
                    "Cooking"
                };
                return View(user);
            }
            return RedirectToAction("Success", user);
        }
        [HttpGet]
        public IActionResult Success(User user)
        {
            return View(user);
        }
    }
}
