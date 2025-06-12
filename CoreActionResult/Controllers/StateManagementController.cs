using Microsoft.AspNetCore.Mvc;

namespace CoreActionResult.Controllers
{
    public class StateManagementController : Controller
    {
        const string CookieUserId = "UserId";
        const string CookieName = "Deepu";
        public IActionResult Index()
        {
            CookieOptions options = new CookieOptions()
            {

            };
            return View();
        }
    }
}
