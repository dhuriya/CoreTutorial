using Microsoft.AspNetCore.Mvc;

namespace CoreActionResult.Controllers
{
    public class ObjectResulController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetPerson()
        {
            var person = new { Firstname = "Deepu", lastname = "Dhuriya", Age = 35 };
            return new ObjectResult(person);
            //return Ok(person);
            var result = new ObjectResult(person)
            {
                StatusCode = 200,
                ContentTypes = new Microsoft.AspNetCore.Mvc.Formatters.MediaTypeCollection
                {
                    "application/json" // Content type(s)
                }
            };
            //return result;
        }
    }
}
