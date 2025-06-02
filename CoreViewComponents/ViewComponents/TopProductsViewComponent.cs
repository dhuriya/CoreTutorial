using CoreViewComponents.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreViewComponents.ViewComponents
{
    // create a class , and it should inherit from ViewComponet class
    public class TopProductsViewComponent : ViewComponent
    {
        // The Invoke method for view component
        public async Task<IViewComponentResult> InvokeAsync(int count)
        {
            // Your logic for preparing data
            ProductRepository repository = new ProductRepository();
            var products = await repository.GetTopProductsAsync(count);
            return View(products);
        }
    }
}
