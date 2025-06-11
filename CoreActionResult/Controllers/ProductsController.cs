using CoreActionResult.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreActionResult.Controllers
{
    public class ProductsController : Controller
    {
        // Action method to handle the GET request for the Index view, which displays the product list
        public async Task<IActionResult> Index([FromQuery] ProductQueryParameters queryParameters)
        {
            // Create an instance of ProductService to access the list of products and perform operations on them
            var _productService = new ProductService();
            // Call the GetProductsAsync method of ProductService to get the filtered, sorted, and paginated list of products along with the total count
            var (products, totalCount) = await _productService.GetProductsAsync(queryParameters);
            // Generate a list of categories for the dropdown by getting all values of the ProductCategory enum
            var categories = Enum.GetValues(typeof(ProductCategory)) // Get all the values from the ProductCategory enum
                .Cast<ProductCategory>() // Cast them to ProductCategory type
                .Select(category => new SelectListItem { Value = category.ToString(), Text = category.ToString() }) // Convert each category to a SelectListItem for use in the dropdown
                .ToList(); // Convert the IEnumerable to a List
            // Define the sorting options for the Sort By dropdown list
            var sortOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "price", Text = "Price" }, // Option to sort by price
                new SelectListItem { Value = "date", Text = "Date Added" }, // Option to sort by date added
            };
            // Define the options for the Page Size dropdown list, allowing users to select how many products to display per page
            var pageSizeOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "3", Text = "3" }, // Option to display 3 products per page
                new SelectListItem { Value = "5", Text = "5" }, // Option to display 5 products per page
                new SelectListItem { Value = "10", Text = "10" }, // Option to display 10 products per page
                new SelectListItem { Value = "20", Text = "20" }, // Option to display 20 products per page
                new SelectListItem { Value = "25", Text = "25" }, // Option to display 25 products per page
                new SelectListItem { Value = "35", Text = "35" }  // Option to display 35 products per page
            };
            // Create a view model object and populate it with the data needed for the view
            var viewModel = new ProductListViewModel
            {
                Products = products, // Assign the list of products to the view model
                PageNumber = queryParameters.PageNumber, // Assign the current page number from the query parameters
                PageSize = queryParameters.PageSize, // Assign the page size (number of products per page) from the query parameters
                TotalPages = (int)Math.Ceiling((double)totalCount / queryParameters.PageSize), // Calculate the total number of pages needed based on the total product count and page size
                SearchTerm = queryParameters.SearchTerm, // Assign the search term entered by the user, if any
                Category = queryParameters.Category, // Assign the selected category for filtering
                SortBy = queryParameters.SortBy, // Assign the selected sorting option (price or date added)
                SortAscending = queryParameters.SortAscending, // Assign whether the sorting is in ascending order
                Categories = categories, // Assign the generated list of categories for the dropdown
                SortOptions = sortOptions, // Assign the generated sorting options for the dropdown
                PageSizeOptions = pageSizeOptions // Assign the generated page size options for the dropdown
            };
            // Return the view along with the populated view model, so the view can display the product list and related controls
            return View(viewModel);
        }
    }
}
