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
            if (!ModelState.IsValid)
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
        [HttpGet]
        public IActionResult Create2()
        {
            User2 user = new User2();
            ViewBag.Countries = new List<string>
            {
                "United States", "Canada","United Kingdom","Australlia","India"
            };
            ViewBag.Hobbies = new List<string>
            {
                "Reading","Traveling","Gaming","Cooking"
            };
            return View(user);
        }
        [HttpPost]
        public IActionResult Create2([FromForm(Name = "Name")] string UserName,
            [FromForm(Name ="Email")] string UserEmail, [FromForm] string Password,
            [FromForm] string Mobile, [FromForm] string Gender, [FromForm] string Country,
            [FromForm] List<string> Hobbies, [FromForm] DateTime? DateOfBirth,
            [FromForm] bool TermsAccepted)
        {
            var user = new User2
            {
                UserName = UserName,
                UserEmail = UserEmail,
                Password = Password,
                Mobile = Mobile,
                Gender = Gender,
                Country = Country,
                Hobbies = Hobbies,
                DateOfBirth = DateOfBirth,
                TermsAccepted = TermsAccepted
            };
            if(!ModelState.IsValid)
            {
                ViewBag.Countries = new List<string> { "United States", "Canada", "United Kingdom", "Australia", "India" };
                ViewBag.Hobbies = new List<string> { "Reading", "Traveling", "Gaming", "Cooking" };
                return View(user);
            }
            return RedirectToAction("Success2", user);
        }
        [HttpGet]
        public IActionResult Success2(User2 user)
        {
            return View(user);
        }
    }
}
