using CoreActionResult.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreActionResult.Controllers
{
    public class TagHelperController : Controller
    {
        private List<Student> listStudents;
        public TagHelperController()
        {
            listStudents = new List<Student>()
            {
               new Student() { StudentId = 101, Name = "James", Branch = "CSE", Section = "A", Gender = "Male" },
               new Student() { StudentId = 102, Name = "Smith", Branch = "ETC", Section = "B", Gender = "Male" },
               new Student() { StudentId = 103, Name = "David", Branch = "CSE", Section = "A", Gender = "Male" },
               new Student() { StudentId = 104, Name = "Sara", Branch = "CSE", Section = "A", Gender = "Female" },
               new Student() { StudentId = 105, Name = "Pam", Branch = "ETC", Section = "B", Gender = "Female" }
            };
        }
        public ViewResult Index()
        {
            return View(listStudents);
        }
        public ViewResult Details(int Id)
        {
            var studentDetails = listStudents.FirstOrDefault(std => std.StudentId == Id);
            return View(studentDetails);
        } 
    }
}
