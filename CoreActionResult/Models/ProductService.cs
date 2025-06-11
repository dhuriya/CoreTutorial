namespace CoreActionResult.Models
{
    public class ProductService
    {
        // Private field to store the list of products
        private readonly List<Product> _products;
        public ProductService()
        {
            _products = new List<Product>
            {
                new Product { Id = 1, Name = "Apple iPhone 13", PCategory = ProductCategory.Electronics, Price = 999, DateAdded = DateTime.Now.AddDays(-10) },
                new Product { Id = 2, Name = "Samsung Galaxy S21", PCategory = ProductCategory.Electronics, Price = 899, DateAdded = DateTime.Now.AddDays(-11) },
                new Product { Id = 3, Name = "Sony WH-1000XM4 Headphones", PCategory = ProductCategory.Accessories, Price = 349, DateAdded = DateTime.Now.AddDays(-12) },
                new Product { Id = 4, Name = "Apple MacBook Pro 16\"", PCategory = ProductCategory.Computers, Price = 2399, DateAdded = DateTime.Now.AddDays(-13) },
                new Product { Id = 5, Name = "Dell XPS 13 Laptop", PCategory = ProductCategory.Computers, Price = 1099, DateAdded = DateTime.Now.AddDays(-14) },
                new Product { Id = 6, Name = "Amazon Echo Dot (4th Gen)", PCategory = ProductCategory.SmartHome, Price = 49, DateAdded = DateTime.Now.AddDays(-15) },
                new Product { Id = 7, Name = "Apple Watch Series 7", PCategory = ProductCategory.Wearables, Price = 399, DateAdded = DateTime.Now.AddDays(-12) },
                new Product { Id = 8, Name = "Google Nest Thermostat", PCategory = ProductCategory.SmartHome, Price = 129, DateAdded = DateTime.Now.AddDays(-10) },
                new Product { Id = 9, Name = "Fitbit Charge 5", PCategory = ProductCategory.Wearables, Price = 179, DateAdded = DateTime.Now.AddDays(-2) },
                new Product { Id = 10, Name = "Bose QuietComfort 35 II", PCategory = ProductCategory.Accessories, Price = 299, DateAdded = DateTime.Now.AddDays(-11) },
                new Product { Id = 11, Name = "Nikon D3500 DSLR Camera", PCategory = ProductCategory.Cameras, Price = 499, DateAdded = DateTime.Now.AddDays(-2) },
                new Product { Id = 12, Name = "Sony PlayStation 5", PCategory = ProductCategory.Gaming, Price = 499, DateAdded = DateTime.Now.AddDays(-11) },
                new Product { Id = 13, Name = "Microsoft Xbox Series X", PCategory = ProductCategory.Gaming, Price = 499, DateAdded = DateTime.Now.AddDays(-10) },
                new Product { Id = 14, Name = "Apple AirPods Pro", PCategory = ProductCategory.Accessories, Price = 249, DateAdded = DateTime.Now.AddDays(-8) },
                new Product { Id = 15, Name = "JBL Flip 5 Bluetooth Speaker", PCategory = ProductCategory.Audio, Price = 119, DateAdded = DateTime.Now.AddDays(-7) },
                new Product { Id = 16, Name = "Canon EOS R6 Mirrorless Camera", PCategory = ProductCategory.Cameras, Price = 2499, DateAdded = DateTime.Now.AddDays(-6) },
                new Product { Id = 17, Name = "Nintendo Switch", PCategory = ProductCategory.Gaming, Price = 299, DateAdded = DateTime.Now.AddDays(-5) },
                new Product { Id = 18, Name = "LG 65\" OLED TV", PCategory = ProductCategory.HomeEntertainment, Price = 1999, DateAdded = DateTime.Now.AddDays(-4) },
                new Product { Id = 19, Name = "Samsung Galaxy Buds Pro", PCategory = ProductCategory.Accessories, Price = 199, DateAdded = DateTime.Now.AddDays(-3) },
                new Product { Id = 20, Name = "Asus ROG Strix Gaming Laptop", PCategory = ProductCategory.Computers, Price = 1499, DateAdded = DateTime.Now.AddDays(-1) }
            };
        }
        // Asynchronous method to get filtered, sorted, and paginated products
        public async Task<(IEnumerable<Product> Products, int TotalCount)> GetProductsAsync(ProductQueryParameters queryParameters)
        {
            // Convert the list of products to a queryable to use LINQ methods
            var products = _products.AsQueryable();
            // Filter: check if a search term is provided and filter products based on the term
            if (!string.IsNullOrEmpty(queryParameters.SearchTerm))
            {
                // Case-insensitive search in product names
                products = products.Where(p => p.Name.Contains(queryParameters.SearchTerm, StringComparison.OrdinalIgnoreCase));
            }
            // Filter: check if a category is specified and filter products by category
            if (!string.IsNullOrEmpty(queryParameters.Category))
            {
                // Try parsing the category string to the ProductCategory enum
                if (Enum.TryParse(queryParameters.Category, out ProductCategory category))
                {
                    // Filter products by the parsed category
                    products = products.Where(p => p.PCategory == category);
                }
            }
            // Get the total count of filtered products
            int totalCount = products.Count();
            // Sorting: check if a sort parameter is specified
            if (!string.IsNullOrEmpty(queryParameters.SortBy))
            {
                // Sort by price if specified
                if (queryParameters.SortBy.Equals("price", StringComparison.OrdinalIgnoreCase))
                {
                    // Apply ascending or descending order based on SortAscending flag
                    products = queryParameters.SortAscending ? products.OrderBy(p => p.Price) : products.OrderByDescending(p => p.Price);
                }
                // Sort by date added if specified
                else if (queryParameters.SortBy.Equals("date", StringComparison.OrdinalIgnoreCase))
                {
                    // Apply ascending or descending order based on SortAscending flag
                    products = queryParameters.SortAscending ? products.OrderBy(p => p.DateAdded) : products.OrderByDescending(p => p.DateAdded);
                }
            }
            // Pagination: calculate the number of items to skip and take based on page number and page size
            products = products.Skip((queryParameters.PageNumber - 1) * queryParameters.PageSize)
                               .Take(queryParameters.PageSize);
            // Return the filtered, sorted, and paginated products along with the total count
            return await Task.FromResult((products.ToList(), totalCount));
        }
    }
}
