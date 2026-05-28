using Microsoft.AspNetCore.Mvc;
using CoreLearn.Models;

namespace MyApp.Namespace
{
    public class ProductController : Controller
    {
        // GET: ProducController
        public IActionResult Index()
        {
            var product = ProductRepository.GetAll();
            ViewBag.SuccessMessage = TempData["SuccessMessage"];
            return View(product);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                ProductRepository.Add(product);
                TempData["SuccessMessage"] = $"Product '{product.Name}' created successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

    }
}
