using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementFile.API.Models.DTOs
{
    public class StudentWithCourseDTO
    {
        public int Id {get; set;}
        public string Name {get; set;} = string.Empty;
        public string Email {get; set;} = string.Empty;
        public int Age {get; set;}
        public int CourseId {get; set;}

        public string CourseName {get; set;} = string.Empty;
        public string CourseCode { get; set;} = string.Empty;
    }
}