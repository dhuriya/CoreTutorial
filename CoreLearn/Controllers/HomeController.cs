using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using CoreLearn.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
namespace CoreLearn.Controllers;
//[Route("Home")] // Controller leve attribute route
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

    public IActionResult Index()
    {
        return View();
    }
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
    // public JsonResult Index()
    // {
    //     List<Student> allStudents = _repository?.GetAllStudents();
    //     _someOtherService?.SomeMethod();
    //     return Json(allStudents);
    // }
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

    //*********************************************************
    // ViewModel Start
    //*********************************************************
    public ViewResult StudentDetailsViewModel()
    {
        Student student = new Student()
        {
            StudentId = 101,
            Name = "Dillip",
            Branch = "CSE",
            Section ="A",
            Gender = "Male"
        };
        Address address = new Address()
        {
            StudentId = 101,
            City = "Delhi",
            State="new Delhi",
            Country = "India",
            Pin = "110044"
        };
        StudentDetailsViewModel studentDetailsViewModel = new StudentDetailsViewModel()
        {
            student = student,
            Address = address,
            Title = "Student Details Page",
            Header = "Student Details"
        };
        return View(studentDetailsViewModel);
    }
    //*********************************************************
    // ViewModel End
    //*********************************************************

    //*********************************************************
    // JsonResult Helper Method Start
    //*********************************************************
    public JsonResult jsonResultIndex()
    {
        var jsonData = new
        {
            Name = "Deepu",
            ID = 4,
            DataOfBirth = new DateTime(1999,08,15)
        };
        return Json(jsonData);
    }
    //*********************************************************
    // JsonResult Helper Method End
    //*********************************************************

    //*********************************************************
    // Returning a collection of Objects Start
    //*********************************************************
    public JsonResult ObjectCollection()
    {
        var jsonArray = new []
        {
            new { Name = "Deepu", Age = 25, Occupation ="Developer"},
            new {Name = "Ankit",Age = 22,Occupation ="Designer"}
        };
        return Json(jsonArray);
    }
    //*********************************************************
    // Returning a collection of Objects End
    //*********************************************************

    //*********************************************************
    // Specifyin JSON Serializer Setting in ASP.NET core Start
    //*********************************************************
    public JsonResult CollectionObject()
    {
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = null,
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            IgnoreReadOnlyProperties = true,
        };
        var jsonArray = new List<Employee>()
        {
            new Employee(){Id = 1,FirstName = "Pranaya",Age = 25,Occupation="Designer",Address="BBSR"},
            new Employee(){Id = 2,FirstName = "Ramesh",Age = 30,Occupation="Manager",Address="Delhi"},
        };
        return Json(jsonArray,options);
    }

    public class Employee
    {
        public int  Id { get; set; }
        public string FirstName { get; set; }
        public int  Age { get; set; }
        public string Occupation { get; set; }

        public string Address {get;set;}
        public string mixedCaseProperty { get; set; }
        public string ReadOnlyPropertyWithPrivateSetter { get; set; } = "ReadOnlyValue";
        public string? NullValueProperty { get; set; }
    }
    //*********************************************************
    // Specifyin JSON Serializer Setting in ASP.NET core End
    //*********************************************************

    //*********************************************************
    // Using Implicit JSON Result in ASP.NET core Start
    //*********************************************************
    public IActionResult ImplicitJSON()
    {
        var jsonArray = new []
        {
            new {Name = "Pranaya",Age = 25,Occupation = "Designer"},
            new {Name = "Ramesh", Age = 30, Occupation ="Developer"}
        };
        return Ok(jsonArray);
    }
    //*********************************************************
    // Using Implicit JSON Result in ASP.NET core End
    //*********************************************************

    //*********************************************************
    // Calling JsonResult Action Method using jQuery in AJAX Start
    //*********************************************************
    public ActionResult JsonResultUsingAjax(string category)
    {
        var options = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = null,
            WriteIndented = true
        };
        try
        {
            List<Product> products = new List<Product>
            {
                new Product{Id = 1001, Name = "Laptop",Description = "Dell Laptop"},
                new Product{Id = 1002, Name = "Desktop", Description="HP Desktop"},
                new Product{Id = 1003, Name = "Mobile", Description = "Apple Iphone"}
            };
            return Json(products,options);
        }
        catch(Exception ex)
        {
            var errorObject = new
            {
                Message = ex.Message,
                StackTrace = ex.StackTrace,
                ExceptionType = "Internal Server Error"
            };
            return new JsonResult (errorObject, options)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }
    }
    //*********************************************************
    // Calling JsonResult Action Method using jQuery in AJAX End
    //*********************************************************

    //*********************************************************
    // ContentResult Start
    //*********************************************************
    public ContentResult ContentResultMethod()
    {
        string plainText = "This is plain Text content.";
        return new ContentResult
        {
            ContentType ="text/plain",
            Content = plainText
        };
    }
    //*********************************************************
    // ContentResult End
    //*********************************************************

    //*********************************************************
    // ContentResult using Helper Method Start
    //*********************************************************
    public ContentResult contentResultHelperMethod()
    {
        string plainText = "This is plain Text content using Helper Method.";
        return Content(plainText,"text/plain");
    }
    //*********************************************************
    // ContentResult using Helper Method End
    //*********************************************************

    //*********************************************************
    // ContentResult Returing HTML Start
    //*********************************************************
    public ContentResult ReturingHtml()
    {
        string htmlContent = "<html><body><h1>Hello. Welcome to Dot Net </h1></body></html>";
        return Content(htmlContent,"text/html");
    }
    //*********************************************************
    // ContentResult Returing HTML End
    //*********************************************************

    //*********************************************************
    // ContentResult Returing XML Start
    //*********************************************************
    public ContentResult ReturingXml()
    {
        string xmlContent = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><data><item> Hello Dot net Tutorial</item></data>";
        return Content(xmlContent,"application/xml");
    }
    //*********************************************************
    // ContentResult Returing XML End
    //*********************************************************

    //*********************************************************
    // ContentResult Returing JSON Start
    //*********************************************************
    public ContentResult ReturingJson()
    {
        var jsonData = new { Name = "Deepu", Age = 26, Occuption = "Developer"};
        var jsonSerializedString = JsonConvert.SerializeObject(jsonData);
        return Content(jsonSerializedString,"application/json");
    }
    //*********************************************************
    // ContentResult Returing JSON End
    //*********************************************************

    //*********************************************************
    // ContentResult Returing String Directly Start
    //*********************************************************
    public ContentResult StringDirectly()
    {
        string content = "This is a simple string.";
        return Content(content);
    }
    //*********************************************************
    // ContentResult Returing String Directly End
    //*********************************************************

    //*********************************************************
    // Customizing Content Using ContentResult Start
    //*********************************************************
    public ContentResult CustomizingContent()
    {
        string customContent="Custom content with specific Settings.";
        return new ContentResult
        {
            Content = customContent,
            ContentType = "text/plain",
            StatusCode = 200
        };
    }
    //*********************************************************
    // Customizing Content Using ContentResult End
    //*********************************************************

    //*********************************************************
    // Using FileContentResult Start
    //*********************************************************
    public FileResult DownloadFile()
    {
        string filePath = Directory.GetCurrentDirectory()+"\\wwwroot\\PDFFiles\\"+"sample.pdf";
        var fileBytes = System.IO.File.ReadAllBytes(filePath);
        var fileRsult = File(fileBytes,"application/pdf");
        fileRsult.FileDownloadName="MySampleFile.pdf";
        fileRsult.LastModified = new DateTimeOffset(System.IO.File.GetLastAccessTimeUtc(filePath));
        fileRsult.EntityTag = new Microsoft.Net.Http.Headers.EntityTagHeaderValue("\"fileVersion\"");
        fileRsult.EnableRangeProcessing = true;
        return fileRsult;
    }
    //*********************************************************
    // Using FileContentResult End
    //*********************************************************

    //*********************************************************
    // Return a File using FileStreamResult Start
    //*********************************************************
    public FileResult usingFileStreamResult()
    {
        string filePath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","PDFFiles","Sample.pdf");
        var fileStrem = new FileStream(filePath,FileMode.Open,FileAccess.Read);
        var fileResult = new FileStreamResult(fileStrem,"application/pdf")
        {
            FileDownloadName = "MySampleFile.pdf",
            LastModified = new DateTimeOffset(System.IO.File.GetLastAccessTimeUtc(filePath)),
            EntityTag = new Microsoft.Net.Http.Headers.EntityTagHeaderValue("\"fileVersion\""),
            EnableRangeProcessing = true
        };
        return fileResult;
    }
    //*********************************************************
    // Return a File using FileStreamResult End
    //*********************************************************

    //*********************************************************
    // Return a File using VirtulaFileResult Start
    //*********************************************************
    public FileResult usingVirtulaFileResult()
    {
        string virtualFilePath = "/PDFFiles/Sample.pdf";
        var fileResult = new VirtualFileResult(virtualFilePath, "application/pdf")
        {
            FileDownloadName = "MySampleFile.pdf",
        };
        return fileResult;
    }
    //*********************************************************
    // Return a File using VirtulaFileResult End
    //*********************************************************

    //*********************************************************
    // Return a File using PhysicalFileResult Start
    //*********************************************************
    public FileResult usingPhysicalFileResult()
    {
        string physicalFilePath = "/PDFFiles/Sample.pdf";
        var fileResult = new PhysicalFileResult(physicalFilePath, "application/pdf")
        {
            FileDownloadName = "MySampleFile.pdf",
        };
        return fileResult;
    }
    //*********************************************************
    // Return a File using PhysicalFileResult End
    //*********************************************************

    //*********************************************************
    // Redirect Result Start
    //*********************************************************
    public RedirectResult simpleRedirect()
    {
        return new RedirectResult("https://www.geeksforgeeks.org/");
    }
    //*********************************************************
    // Redirect Result End
    //*********************************************************

    //*********************************************************
    // RedirectResult Using Helper Method Start
    //*********************************************************
    public RedirectResult redirectResultHelperMethod()
    {
        return Redirect("https://www.geeksforgeeks.org/");
    }
    //*********************************************************
    // RedirectResult Using Helper Method End
    //*********************************************************

    //*********************************************************
    // Customizing RedirectResult Start
    //*********************************************************
    public RedirectResult redirectCustomizing ()
    {
        var redirectResult = new RedirectResult("https://www.geeksforgeeks.org/")
        {
            Permanent = false,
            PreserveMethod = true
        };
        return redirectResult;
    }
    //*********************************************************
    // Customizing RedirectResult End
    //*********************************************************

    //*********************************************************
    // Understand Object Result Start
    //*********************************************************
    public IActionResult UnderstandObject ()
    {
        var person = new {FirstName = "Deepu", LastName = "Dhuriya", Age = 26};
        return new ObjectResult(person);
    }
    //*********************************************************
    // Understand Object Result End
    //*********************************************************

    //*********************************************************
    // Setting ObjectResult Start
    //*********************************************************
    public IActionResult SettingObjectResult()
    {
        var person = new {FirstName = "Deepu", LastName = "Dhuriya", Age = 26};
        var result = new ObjectResult(person)
        {
            StatusCode = 200,
            ContentTypes = new Microsoft.AspNetCore.Mvc.Formatters.MediaTypeCollection
            {
                "application/json"
            }
        };
        return result;
    }
    //*********************************************************
    // Setting ObjectResult End
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
