using System.ComponentModel.DataAnnotations;

namespace CoreLearn.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product name is required.")]
        [StringLength(100)]
        public string Name { get; set; } = null!;
        [StringLength(500)]
        public string? Description { get; set; }
        [Range(0,1000000,ErrorMessage ="Price must be a positive value.")]
        public decimal Price { get; set; }
        [Range(0, int.MaxValue,ErrorMessage ="Stock cannot be negative.")]
        public int Stock { get; set; }
        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
    }
}