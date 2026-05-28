namespace CoreLearn.Models
{
    public static class ProductRepository
    {
        private static List<Product> _products;
        static ProductRepository()
        {
            _products = new List<Product>
            {
                new Product{Id = 1, Name = "Apple iPhone 14", Price=79900m,Description="Latest Apple iPhone with A15 chip",Stock = 25,CreatedDate=DateTime.Now.AddDays(-30)},
                new Product{Id = 2, Name = "Sumsung Galaxy S23", Price=69999m,Description="Flagship Samsung phone wiht great camera",Stock = 40,CreatedDate=DateTime.Now.AddDays(-20)},
                new Product{Id = 3, Name = "OnePlus 11", Price=55999m,Description="Powerful OnePlus device with fast chargin",Stock = 25,CreatedDate=DateTime.Now.AddDays(-10)}
            };
        }

        public static List<Product> GetAll()
        {
            return _products;
        }
        public static void Add(Product product)
        {
            product.Id = _products.Max(p=>p.Id)+1;
            product.CreatedDate = DateTime.Now;
            _products.Add(product); 
        }
    }
}