using Microsoft.AspNetCore.Mvc;

namespace CoreActionResult.Namespace
{
    public class StateManagementController : Controller
    {
        // GET: StateManagementController
        const string CookieUserId = "UserId";
        const string CookieUserName = "Username";
        public IActionResult Index()
        {       
            CookieOptions options = new CookieOptions()
            {
                Domain = "localhost",
                Path = "/",
                Expires = DateTime.Now.AddDays(7),
                Secure = false,
                HttpOnly = true,
                IsEssential = true
            };
            Response.Cookies.Append(CookieUserId, "123456", options);
            Response.Cookies.Append(CookieUserName, "deepu@rrfcl.com", options);
            return View();
        }
        public string About()
        {
            string? UserName = Request.Cookies.ContainsKey("CookieUserName") ? Request.Cookies[CookieUserName] : null;
            int? UserId = null;
            if (Request.Cookies.ContainsKey(CookieUserId))
            {
                bool isValidInt = int.TryParse(Request.Cookies[CookieUserId], out int parseUserId);
                if (isValidInt)
                {
                    UserId = parseUserId;
                }
            }
            string Message = $"Username : {UserName}, UserId : {UserId}";
            return Message;
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public string DeleteCookie()
        {
            CookieOptions options = new CookieOptions()
            {
                Domain = "localhost",
                Path = "/",
            };
            Response.Cookies.Delete(CookieUserId, options);
            Response.Cookies.Delete(CookieUserName, options);
            return "Cookies are Deleted";
        }
﻿using Microsoft.AspNetCore.Mvc;

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
