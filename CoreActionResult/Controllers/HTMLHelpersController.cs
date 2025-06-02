using CoreActionResult.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace CoreActionResult.Controllers
{
    public class HTMLHelpersController : Controller
    {
        public ActionResult Index()
        {
            //current settings
            SecuritySettingsViewModel setting = new SecuritySettingsViewModel()
            {
                EnableTwoFactorAuth = false
            };
            return View();
        }
        [HttpPost]
        public string UpdateSecuritySettings(SecuritySettingsViewModel settings)
        {
            if (settings.EnableTwoFactorAuth)
            {
                return "You Enable Two Factor Authentication";
            }
            else
            {
                return "You Disabled Two Factor Authentication";
            }
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                if(model.RememberMe)
                {
                    //set cookie or other logic for remebering the user
                }
                return RedirectToAction("Index","Home");
            }
            return View(model);
        }
        
        private List<City> GetAvailableCities()
        {
            return new List<City>
            {
                new City(){CityId = 1, CityName="London",IsSelected =false},
                new City(){CityId =2, CityName= "New York", IsSelected = false},
                new City(){CityId = 3, CityName="Sydney",IsSelected = true},
                new City(){CityId=4,CityName = "Mumai",IsSelected = false},
                new City(){CityId = 5, CityName = "Cambridge",IsSelected = false},
                new City(){CityId = 6, CityName = "Delhi",IsSelected = true},
                new City(){CityId = 7,CityName = "Hyderabad",IsSelected  = false}
            };
        }
        [HttpGet]
        public ActionResult GetCities()
        {
            CitiesViewModel citiesViewModel = new CitiesViewModel()
            {
                Cities = GetAvailableCities(),
                SelectedCityIds = GetAvailableCities().Where(city => city.IsSelected).Select(city => city.CityId).ToList()
            };
            return View(citiesViewModel);
        }
        [HttpPost]
        public string SubmittedCities(IEnumerable<int> SelectedCityIds)
        {
            if(SelectedCityIds == null)
            {
                return "No Cities Selected";
            }
            else
            {
                var CityNames = GetAvailableCities().Where(t => SelectedCityIds.Contains(t.CityId)).Select(item => item.CityName).ToList();
                StringBuilder sb = new StringBuilder();
                sb.Append("Your Selected City names - " + string.Join(", ", CityNames));
                return sb.ToString();
            }
        }
        public ActionResult CustomHTMLHelperExam()
        {
            Employee employee = new Employee()
            {
                Id = 10345,
                Name = "Deepu",
                Designation = "Software Developer",
                Department="IT",
                Photo = "/Images/userdeepu.jpg",
                AlternateText = "Deepu photo not avaiable"
            };
            return View(employee);
        }
        [HttpGet]
        public IActionResult Register()
        {
            var model = new UserRegistrationModel
            {
                Courses = new List<string>
                {
                    "ASP.NET Core","Azure","Micsroservices"
                },
                Skills = new List<string>
                {
                    "C#","SQL","JavaScript","Docker","Kubernets"
                },
                HiddenFiled = Guid.NewGuid()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Register(UserRegistrationModel model)
        {
            if(ModelState.IsValid)
            {
                return View("Success", model);
            }
            model.Courses = new List<string>
            {
                "ASP.NET Core","Azure","Micsroservices"
            };
            model.Skills = new List<string>
            {
                "C#","SQL","JavaScript","Docker","Kubernets"
            };
            return View(model);
        }
        private static readonly List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Description = "A powerful laptop.", Category = "Electronics", Price = 1200.00m, Quantity = 10 },
            new Product { Id = 2, Name = "Smartphone", Description = "A high-end smartphone.", Category = "Electronics", Price = 800.00m, Quantity = 20 },
            new Product { Id = 3, Name = "Desktop", Description = "A Performance Desktop", Category = "Electronics", Price = 1000.00m, Quantity = 15 }
        };
        public IActionResult List()
        {
            return View(_products);
        }
        public IActionResult Details(int id)
        {
            var product = _products.Find(p => p.Id == id);
            return View(product);
        }
    }
}
