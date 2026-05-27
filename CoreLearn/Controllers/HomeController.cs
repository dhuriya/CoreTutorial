using System.Diagnostics;
namespace CoreLearn.Controllers;

public class HomeController : Controller
{
    //private readonly ILogger<HomeController> _logger;
    // Create a reference variable of IStudentRepository
    private readonly IStudentRepository? _repository = null;
    private readonly SomeOtherService? _someOtherService = null;    

    // public HomeController(ILogger<HomeController> logger)
    // {
    //     _logger = logger;
    // }

    

    // public IActionResult Index()
    // {
    //     return View();
    // }
    // public ViewResult Index()
    // {
    //     return View();
    // }

    // public ViewResult Index()
    // {
    //     return View("Test");
    // }

    //************** How do you specify the Absolute View File Path ***************
    // public ViewResult Index()
    // {
    //     return View("Views/Home/Test.cshtml");
    // }
    //********************** Without Dependency Injection ******************
    // public JsonResult Index()
    // {
    //     StudentRepository repository = new StudentRepository();
    //     List<Student> students = repository.GetAllStudents();
    //     return Json(students);
    // }
    // public JsonResult GetStudentDetails(int id)
    // {
    //     StudentRepository repository = new StudentRepository();
    //     Student student = repository.GetStudentById(id);
    //     return Json(student);
    // }
    //****************************************************
    // Constructor Injection in ASP.NET Core MVC Application
    //*******************************************************
    // Initialize the variable through constructor
    // public HomeController(IStudentRepository repository)
    // {
    //     _repository = repository;
    // }   
    // public JsonResult Index()
    // {
    //     List<Student> students = _repository?.GetAllStudents();
    //     return Json(students);
    // }
    //--------------------------------------
    // Action Method Injection Start
    //--------------------------------------
    // public JsonResult Index([FromServices] IStudentRepository repository)
    // {
    //     List<Student> allStudents = _repository?.GetAllStudents();
    //     return Json(allStudents);
    // }
    //--------------------------------------
    // Action Method Injection end
    //--------------------------------------
    // public JsonResult GetStudentDetails(int id)
    // {
    //     Student? studentDetails = _repository?.GetStudentById(id);
    //     return Json(studentDetails);
    // }
    //*********************************************************
    // Get Services Manually in ASP.NET Core Start
    //*********************************************************
    // public JsonResult Index()
    // {
    //     var services = this.HttpContext.RequestServices;
    //     IStudentRepository? _repository = (IStudentRepository?)services.GetService(typeof(IStudentRepository));
    //     List<Student> allStudents = _repository?.GetAllStudents();
    //     return Json(allStudents);
    // }
    // public JsonResult GetStudentDetails(int id)
    // {
    //     var services = this.HttpContext.RequestServices;
    //     IStudentRepository? _repository = (IStudentRepository?)services.GetService(typeof(IStudentRepository));
    //     Student student = _repository?.GetStudentById(id);
    //     return Json(student);
    // }
    //*********************************************************
    // Get Services Manually in ASP.NET Core End
    //*********************************************************

    //*********************************************************
    // Singleton Start
    //*********************************************************
    public HomeController(IStudentRepository? repository,SomeOtherService someOtherService)
    {
        _repository = repository;
        _someOtherService = someOtherService;
    }
    public JsonResult Index()
    {
        List<Student> allStudents = _repository?.GetAllStudents();
        _someOtherService?.SomeMethod();
        return Json(allStudents);
    }
    public JsonResult GetStudentDetails(int id)
    {
        Student? studentDetails = _repository?.GetStudentById(id);
        _someOtherService?.SomeMethod();
        return Json(studentDetails);
    }
    //*********************************************************
    // Singleton End
    //*********************************************************
    //*********************************************************
    // ViewData Start
    //*********************************************************
    public ViewResult Details()
    {
        ViewData["Title"]="Student Details Page";
        ViewData["Header"]="Student Details";

        Student student = new Student()
        {
            StudentId = 101,
            Name = "James",
            Branch ="CSE",
            Section = "A",
            Gender = "Male"
        };
        ViewData["Student"] = student;
        return View();
    }
    //*********************************************************
    // ViewData End
    //*********************************************************

     //*********************************************************
    // ViewBag Start
    //*********************************************************
    public ViewResult Details2()
    {
        ViewBag.Title="Student Details Page";
        ViewBag.Header="Student Details";

        Student student = new Student()
        {
            StudentId = 101,
            Name = "James",
            Branch ="CSE",
            Section = "A",
            Gender = "Male"
        };
        ViewBag.Student = student;
        return View();
    }
    //*********************************************************
    // ViewBag End
    //*********************************************************

    //*********************************************************
    // Strongly Typed Start
    //*********************************************************
    public ViewResult StronglyType()
    {
        ViewBag.Title = "Student Details Page";
        ViewData["Header"] = "Student Details";
        Student student = new Student()
        {
            StudentId = 103,
            Name = "James",
            Branch ="CSE",
            Section = "A",
            Gender = "Male"
        };
        return View(student);
    }
    //*********************************************************
    // Strongly Typed End
    //*********************************************************
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
