using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace CoreActionResult.Controllers
{
    public class StatusResultsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult NotFoundExample()
        {
            return new StatusCodeResult(404);
            //return StatusCode(404);//sing StatusCodeResult Helper Method:
            //return StatusCode(404, new { message = "Resource Not Foound" });

            //HttpUnauthorizedResult in ASP.NET Core MVC
            //return new UnauthorizedResult();
            //return new UnauthorizedResult(new {Message = "You Have not Access to this page"});

            //NotFoundResult in ASP.NET Core MVC
            //return NotFound("Resource Not Found");

            //OkResult in ASP.NET Core MVC:
            var data  = new { Message = "Succes"};
            //return Ok(data);
        }
        public IActionResult CustomStatusCodeExample()
        {
            return new StatusCodeResult(403);
            //return StatusCode(403);//sing StatusCodeResult Helper Method:
            //return StatusCode(403, new { message = "Resource Not Foound" });
        }
        //HttpUnauthorizedResult in ASP.NET Core MVC

    }
}
