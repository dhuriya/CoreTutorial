using CoreActionResult.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreActionResult.Namespace
{
    public class StateManagementController : Controller
    {
        // GET: StateManagementController
        const string CookieUserId = "UserId";
        const string CookieUserName = "Username";

        //Declare a private field to hold MyCookieService instance
       private readonly MyCookieService _myCookieService;

        public StateManagementController(MyCookieService myCookieService)
        {
            _myCookieService = myCookieService;
        }
        public IActionResult Index()
        {
            // Let us assume the User is logged in and we need to store the user information in the cookie
            // var cookieOptions = new CookieOptions
            // {
            //     HttpOnly = true, // Set cookie as HttpOnly
            //     Secure = true, // Set cookie as Secure
            //     Expires = DateTime.Now.AddDays(7) // Set cookie expiration date
            // };
            // try
            // {
            //     // Encrypt the Cookie Value for UserId
            //     string encryptedUserId = _myCookieService.Protect("1234567");
            //      // Store the Encrypted value in the Cookies Response Header
            //     Response.Cookies.Append(CookieUserId, encryptedUserId, cookieOptions);
            //     // Encrypt the Cookie Value for UserName
            //     string encryptedUserName = _myCookieService.Protect("pranaya@dotnettutotials.net");
                
            //     // Store the Encrypted value in the Cookies Response Header
            //     Response.Cookies.Append(CookieUserName, encryptedUserName, cookieOptions);
            // }
            // catch (Exception ex)
            // {
            //     // Handle the exception (e.g., log the error)
            //     // For simplicity, we'll just display the error message in ViewBag
            //     ViewBag.Error = $"Error encrypting cookies: {ex.Message}";
            // }
            // try
            // {
            //     // Fetch and decrypt UserName from cookies if it exists
            //     string? encryptedUserNameValue = Request.Cookies[CookieUserName];
            //     if (encryptedUserNameValue != null)
            //     {
            //         ViewBag.UserName = _myCookieService.Unprotect(encryptedUserNameValue);
            //     }
            //     // Fetch and decrypt UserId from cookies if it exists
            //     string? encryptedUserIdValue = Request.Cookies[CookieUserId];
            //     if (encryptedUserIdValue != null)
            //     {
            //         ViewBag.UserId = Convert.ToInt32(_myCookieService.Unprotect(encryptedUserIdValue));
            //     }
            // }
            // catch (Exception ex)
            // {
            //     // Handle the exception (e.g., log the error)
            //     // For simplicity, we'll just display the error message in ViewBag
            //     ViewBag.Error = $"Error decrypting cookies: {ex.Message}";
            // }
            // CookieOptions options = new CookieOptions()
            // {
            //     Domain = "localhost",
            //     Path = "/",
            //     Expires = DateTime.Now.AddDays(7),
            //     Secure = false,
            //     HttpOnly = true,
            //     IsEssential = true
            // };
            // Response.Cookies.Append(CookieUserId, "123456", options);
            // Response.Cookies.Append(CookieUserName, "deepu@rrfcl.com", options);
            try
            {
                // Encrypt the Cookie Value for UserId
                string encryptedUserId = _myCookieService.Protect("1234567");
                
                // Store the Encrypted value in the Cookies Response Header
                Response.Cookies.Append(CookieUserId, encryptedUserId);
                // Encrypt the Cookie Value for UserName
                string encryptedUserName = _myCookieService.Protect("pranaya@dotnettutotials.net");
                
                // Store the Encrypted value in the Cookies Response Header
                Response.Cookies.Append(CookieUserName, encryptedUserName);
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log the error)
                // For simplicity, we'll just display the error message in ViewBag
                ViewBag.Error = $"Error encrypting cookies: {ex.Message}";
            }
            try
            {
                // Fetch and decrypt UserName from cookies if it exists
                string? encryptedUserNameValue = Request.Cookies[CookieUserName];
                if (encryptedUserNameValue != null)
                {
                    ViewBag.UserName = _myCookieService.Unprotect(encryptedUserNameValue);
                }
                // Fetch and decrypt UserId from cookies if it exists
                string? encryptedUserIdValue = Request.Cookies[CookieUserId];
                if (encryptedUserIdValue != null)
                {
                    ViewBag.UserId = Convert.ToInt32(_myCookieService.Unprotect(encryptedUserIdValue));
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log the error)
                // For simplicity, we'll just display the error message in ViewBag
                ViewBag.Error = $"Error decrypting cookies: {ex.Message}";
            }
            return View();
        }
        public string About()
        {
            try
            {
                string? UserName = null;
                // Fetch the Encrypted Cookie for UserName from the Request Header
                string? encryptedUserNameValue = Request.Cookies[CookieUserName];
                if (encryptedUserNameValue != null)
                {
                    // Decrypt the Encrypted Value
                    UserName = _myCookieService.Unprotect(encryptedUserNameValue);
                }
                int? UserId = null;
                // Fetch the Encrypted Cookie for UserId from the Request Header
                string? encryptedUserIdValue = Request.Cookies[CookieUserId];
                if (encryptedUserIdValue != null)
                {
                    // Decrypt the Encrypted Value
                    UserId = Convert.ToInt32(_myCookieService.Unprotect(encryptedUserIdValue));
                }
                string Message = $"UserName: {UserName}, UserId: {UserId}";
                return Message; // Return the message with user information
            }
            catch (Exception ex)
            {
                return $"Error Occurred: {ex.Message}"; // Return the error message
            }
            // string? UserName = Request.Cookies.ContainsKey("CookieUserName") ? Request.Cookies[CookieUserName] : null;
            // int? UserId = null;
            // if (Request.Cookies.ContainsKey(CookieUserId))
            // {
            //     bool isValidInt = int.TryParse(Request.Cookies[CookieUserId], out int parseUserId);
            //     if (isValidInt)
            //     {
            //         UserId = parseUserId;
            //     }
            // }
            // string Message = $"Username : {UserName}, UserId : {UserId}";
            // return Message;
        }
        public IActionResult Privacy()
        {
            try
            {
                // Fetch the Encrypted Cookie for UserName from the Request Header
                string? encryptedUserNameValue = Request.Cookies[CookieUserName];
                if (encryptedUserNameValue != null)
                {
                    // Store the Decrypted Value in the ViewBag to display in the UI
                    ViewBag.UserName = _myCookieService.Unprotect(encryptedUserNameValue);
                }
                // Fetch the Encrypted Cookie for UserId from the Request Header
                string? encryptedUserIdValue = Request.Cookies[CookieUserId];
                if (encryptedUserIdValue != null)
                {
                    // Store the Decrypted Value in the ViewBag to display in the UI
                    ViewBag.UserId = Convert.ToInt32(_myCookieService.Unprotect(encryptedUserIdValue));
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log the error)
                // For simplicity, we'll just display the error message in ViewBag
                ViewBag.Error = $"Error decrypting cookies: {ex.Message}";
            }
            return View();
        }
        public string DeleteCookie()
        {
             // Delete the Cookie From the Response Header, i.e., from the Browser.
            Response.Cookies.Delete(CookieUserId);
            Response.Cookies.Delete(CookieUserName);
            return "Cookies are Deleted"; // Return the confirmation message
            // CookieOptions options = new CookieOptions()
            // {
            //     Domain = "localhost",
            //     Path = "/",
            // };
            // Response.Cookies.Delete(CookieUserId, options);
            // Response.Cookies.Delete(CookieUserName, options);
            // return "Cookies are Deleted";
        }
    }
}
