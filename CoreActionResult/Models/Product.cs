namespace CoreActionResult.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ProductCategory PCategory { get; set; }
        public string? Description { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
