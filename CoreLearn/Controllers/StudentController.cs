using Microsoft.AspNetCore.Mvc;
using CoreLearn.Models;

namespace MyApp.Namespace
{
    public class StudentController : Controller
    {
        // GET: StudentController
        [Route(" ")]
        [Route("Home")]
        [Route("Home/Index")] // multiple Route attribute\
        // [HttpGet(" ")]
        // [HttpGet("Home")]
        // [HttpGet("Home/Index")]
        public string Index()
        {
            return $"Index() Action Method of StudentController";
        }
        public string Detials(string id)
        {
            return $"Details({id}) Action Method of StudentController";
        }

        // public string GetAllStudents()
        // {
        //     return "Return All Students";
        // }
        // How to pass Parameters in Action Methods?
        public string GetStudentsByName(string name)
        {
            return $"Return All Students with Name : {name}";
        }

        public JsonResult GetStudentDetails(int Id)
        {
            StudentRepository repository = new StudentRepository();
            Student studentDetials=repository.GetStudentById(Id);
            return Json(studentDetials);
        }
        static List<Student> students = new List<Student>()
        {
            new Student() { StudentId = 101, Name = "James", Branch="CSE",Section ="A",Gender="Male"},
                new Student() { StudentId = 102, Name = "Smith", Branch="ETC",Section ="B",Gender="Male"},
                new Student() { StudentId = 103, Name = "David", Branch="CSE",Section ="A",Gender="Male"},
                new Student() { StudentId = 104, Name = "Sara", Branch="CSE",Section ="A",Gender="Female"},
                new Student() { StudentId = 105, Name = "Pam", Branch="ETC",Section ="B",Gender="Female"}
        };

        //URL Pattern : /Student/All
        [Route("Student/All")] //attribute routing
        //[HttpGet("Student/All")]
        public List<Student> GetAllStudents()
        {
            return students;
        }
        //URL Pattern : /Student/1/Details
        [Route("Student/{studentID}/Details")]
        public Student GetStudentByID(int studentID)
        {
            Student? studetnDetails = students.FirstOrDefault(s=>s.StudentId==studentID);
            return studetnDetails?? new Student();
        }

        //URL Pattern : /Student/1/Coursed
        [Route("Student/{studentID}/Courses")]
        public List<string> GetStudentCourses(int studentID)
        {
            List<string> CourseList = new List<string>();
            if(studentID == 101)
                CourseList= new List<string>(){"Asp.NET Core","C#.NET","SQL Server"};
            else if(studentID ==102)
                CourseList= new List<string>(){"Asp.NET Core MVC","C#.NET","SQL Server"};
            else if(studentID == 103)
                CourseList= new List<string>(){"Asp.NET Core","C#.NET","Entity Framework"};
            else
                CourseList= new List<string>(){"Bootstrap","jQuery","AngularJs"};
            return CourseList;
        }

    }
}
