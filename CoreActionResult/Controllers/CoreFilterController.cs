using CoreActionResult.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CoreActionResult.Namespace
{
    public class CoreFilterController : Controller
    {
        // GET: CoreFilterController
        public ActionResult Index()
        {
            return View();
        }
        [CustomExceptionFilter]
        public ActionResult CustomExceptionFilterIndex()
        {
            int x = 10;
            int y = 0;
            int z = x / y;
            return View();
        }

    }
}
