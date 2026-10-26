using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace StudentManagementFile.API.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is required")]
        [StringLength(50, MinimumLength =2)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [EmailAddress(ErrorMessage ="Enter Valid Email")]
        public string Email { get; set; } = string.Empty;
        [Range(5, 75, ErrorMessage ="Age between 5 to 75")]
        public int Age { get; set; }
        [Required]
        public string Course { get; set; } = string.Empty;
    }
}