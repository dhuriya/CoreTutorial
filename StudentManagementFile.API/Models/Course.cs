using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace StudentManagementFile.API.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Course name is required")]
        [StringLength(100)]
        public string CourseName { get; set; } = string.Empty;
        [Required]
        [StringLength(20)]
        public string CourseCode {get; set; } = string.Empty;
        [Range(1, 8, ErrorMessage = "Duration 1 se 8 semesters ke beech honi chahiye")]
        public int DurationInSemesters { get; set; }
        [Range(1, 500000)]
        public decimal Fee { get; set; }
    }
}