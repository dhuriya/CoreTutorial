using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    public class StudentController : Controller
    {
        // GET: StudentController
        public ActionResult Index()
        {
            return View();
        }

        public string GetAllStudents()
        {
            return "Return All Students";
        }
        // How to pass Parameters in Action Methods?
        public string GetStudentsByName(string name)
        {
            return $"Return All Students with Name : {name}";
        }

    }
}
