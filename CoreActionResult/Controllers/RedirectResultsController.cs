using Microsoft.AspNetCore.Mvc;

namespace CoreActionResult.Controllers
{
    public class RedirectResultsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //Example to Understand Redirect Result in ASP.NET Core MVC
        public RedirectResult Redirectres()
        {
            return new RedirectResult("www.youtube.coom");
        }
        //Using RedirectResult Helper Method:
        public RedirectResult RedirectHelperres()
        {
            return Redirect("www.youtube.coom");
        }
        //Customizing RedirectResult:
        public RedirectResult CustomizingRedirect()
        {
            var redirectResult = new RedirectResult("www.youtube.coom")
            {
                Permanent = false,
                PreserveMethod = true
            };
            return redirectResult;
        }
        //RedirectToRouteResult in ASP.NET Core MVC
    }
}
