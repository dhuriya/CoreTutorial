using CoreActionResult.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Text.Json;

namespace CoreActionResult.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public ViewResult Index()
        {
            Product product = new Product()
            {
                Id = 1,
                Name = "Test",
            };
            return View(product);
        }
        public PartialViewResult PartialViewIndex()
        {
            Product product = new Product()
            {
                Id = 1,
                Name = "Test",
            };
            return PartialView("_ProductDetailsPartialView",product);
        }
        [AjaxOnly]
        public PartialViewResult Details(int ProductId)
        {
            // Get the HTTP method of the current request (GET,POST)
            string method = HttpContext.Request.Method;
            // Get the value of the "X-Requested-With" header from the current request
            string? requestedWith = HttpContext?.Request?.Headers.XRequestedWith;
            // Check if the HTTP method is either POST or GET
            if(method == "POST" || method == "GET")
            {
                // Check if the request was made via AJAX
                if(requestedWith == "XMLHttpRequest")
                {
                    Product product = new Product()
                    {
                        Id = ProductId,
                        Name = "Test",
                    };
                    return PartialView("_ProductDetailsPartialView", product);
                }
            }
            // If the request is not valid (not an AJAX request), return the "_InvalidRequestPartialView" partial view
            return PartialView("_InvalidRequestPartialView");
        }
        // JsonResult
        public JsonResult JsonResultIndex()
        {
            var jsonData = new
            {
                Name = "Deepu",
                ID = 4,
                DateOfBirth = new DateTime(1999, 08, 15)
            };
            // Returing a JsonResult  using the Json Method of the controller class
            // the Json method  takes the JsonData object and serialized it to json formate
            // and sets appropriate headers for the headers for the response to indicate the content tuep as application/json.
            // using JsonResult Helper Method
            return Json(jsonData);

            //return new JsonResult(jsonData);
        }
        //Returning a Collection of Objects:
        public JsonResult JsonCollection()
        {
            var jsonArray = new[]
            {
                new { Name = "Deepu", Age = 26, Occupation = "Developer"},
                new { Name = "Ankite", Age = 25, Occupation = "Designer"}
            };
            return Json(jsonArray);
        }
        // Specifying JSON Serializer Settings in ASP.NET Core MVC:
        public JsonResult JsonCollectionSerializer()
        {
            // Create a new instance of jsonSerializerOptions
            var optios = new JsonSerializerOptions
            {
                // Property name will remain as defined in the  class
                PropertyNamingPolicy = null,
                // JSON will be formatted with indents for readablility
                WriteIndented = true,
                // Properties with null values will be ignored
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault,
                // Read-only properties will be igoned during serialization
                IgnoreReadOnlyProperties = true,
            };
            // Create a list of Employees objects with sample data
            var jsonArray = new List<Employees>()
            {
                new Employees() {Id = 1, FirstName = "Deepu", Age = 26, Occupation = "Developer", Address = "Delhi"},
                new Employees() {Id = 2, FirstName = "Aditya" ,Age = 24 , Occupation = "Developer", Address = "UP"}
            };

            // Return the list as a Json result, using specified jsonSerializerOpetions
            return Json(jsonArray, optios);
        }

        //Using Implicit JSON Result in ASP.NET Core MVC:
        public IActionResult ImplictJsoon()
        {
            var jsonArray = new[]
            {
                new { Name = "Deepu", Age = 26, Occupation = "Developer"},
                new { Name = "Ankite", Age = 25, Occupation = "Designer"}
            };

            // this will be automatically serizlized to JSON
            return Ok(jsonArray);
        }

        // Calling JsonResult Action Method using jQuery AJAX:
        public ActionResult JsonResultByAjax(string Category)
        {
            var optinons = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = null,
                WriteIndented = true,
            };
            try
            {
                // Based on the Category Fetch the Data from the database
                List<Product> products = new List<Product>()
                {
                    new Product{Id = 1001,Name = "Laptop",Description = "Dell Laptop"},
                    new Product{Id = 1002,Name = "Desktop",Description = "HP Desktop"},
                    new Product{Id = 1003,Name = "Moblie",Description = "Apple IPhone"}
                };
                //Please uncomment the following two lines if you want see what happend when exception occurred
                //int a = 10, b = 0;
                //int c = a / b;
                return Json(products, optinons);
            }
            catch(Exception ex)
            {
                var errorobject = new
                {
                    Message = ex.Message,
                    StackTrace = ex.StackTrace,
                    ExceptionType = "Internal Server Error"
                };
                return new JsonResult(errorobject, optinons)
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }
        // Content Result
        public ContentResult ContentresultIndex()
        {
            string plainText = "This is plain text content.";
            // create and return a new ContentResult object
            return new ContentResult
            {
                ContentType = "text/plain",
                Content = plainText
            };
        }
        //Using ContentResult Helper Method:
        public ContentResult ContentResultHelperMethod()
        {
            string plainText = "Using ContentResult Helper Method:";
            return Content(plainText, "text/plain");
        }
        //Returning HTML:
        public ContentResult ContentResultHtml()
        {
            string htmlContent = "<html><body><h1>Hello, Welcome to Dot Net Tutorials</h1></body></html>";
            return Content(htmlContent, "text/html");
        }
        //Returning JSON:
        public ContentResult ContentResultJson()
        {
            var jsonData = new { Name = "Pranaya", Age = 35, Occupation = "Manager" };
            var jsonSerializedString = JsonConvert.SerializeObject(jsonData);
            return Content(jsonSerializedString, "application/json");
        }
        //Customizing Content using ContentResult in ASP.NET Core MVC:
        public ContentResult ContentResultCustomizing()
        {
            string customContent = "Custom content with specific settings.";
            return new ContentResult
            {
                Content = customContent,
                ContentType = "text/plain",
                StatusCode = 200,
            };
        }

        //Example using FileContentResult in ASP.NET Core MVC:
        public FileResult FileContentResultDownload()
        {
            // Get the current directory of the application and construct the file path
            // for the PDF file
            string filePath = Directory.GetCurrentDirectory() + "\\wwwroot\\Files\\" + "linq.pdf";
            // Read all the bytes of the PDF fill byte array
            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            // create a fileResult object using array and specify the cotent type as "application/pdf"
            var fileResult = File(fileBytes, "application/pdf");
            //set the name of the file to be downloaded by the user
            fileResult.FileDownloadName = "linq.pdf";
            // set the last modified date
            fileResult.LastModified = new DateTimeOffset(System.IO.File.GetLastWriteTime(filePath));
            fileResult.EntityTag = new Microsoft.Net.Http.Headers.EntityTagHeaderValue("\"fileVersion1\"");
            fileResult.EnableRangeProcessing=true;
            return fileResult;
        }
        //Example to Return a File using FileStreamResult in ASP.NET Core MVC:
        public FileStreamResult DownloadFile()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Files", "linq.pdf");
            // Create a FileStream to the PDF file
            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            var fileResult = new FileStreamResult(fileStream, "application/pdf")
            {
                LastModified = new DateTimeOffset(System.IO.File.GetLastWriteTimeUtc(filePath)),
                EntityTag = new Microsoft.Net.Http.Headers.EntityTagHeaderValue("\"fileVersion1\""),
                EnableRangeProcessing = true
            };
            return fileResult;
        }
        //Example to return a File using VirtualFileResult in ASP.NET Core MVC:
        public VirtualFileResult VirtualFileDownload()
        {
            string virtualFilePath = "/Files/linq.pdf";
            var fileResult = new VirtualFileResult(virtualFilePath, "application/pdf")
            {
                FileDownloadName = "MySamplefile.pdf"
            };
            return fileResult;
        }
        //Example to Return a File using PhysicalFileResult in ASP.NET Core MVC:
        public PhysicalFileResult PhysicalFileDownload()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "linq.pdf");
            var fileResult = new PhysicalFileResult(filePath, "application/pdf")
            {
                // Set the name of the file to be downloaded by the user
                FileDownloadName = "MySampleFile.pdf",
            };
            return fileResult;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}

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
    // Define the Employee class
    public class Employees
    {
        // Read-write properties
        public int Id { get; set; }
        public string FirstName { get; set; }
        public int Age { get; set; }
        public string Occupation { get; set; }
        // Read-only property
        public string Address { get; set; }
        // Mixed case property names
        public string mixedCasePropety { get; set; }
        // Property with private setter to make it read-only for serialization
        public string ReadOnlyPropertyWithPrivateSetter { get; private set; } = "ReadOnlyValue";
        // Property with null value to show DefalutiIgnoreCondition
        public string? NullValueProperty { get; set; }
    }
}
