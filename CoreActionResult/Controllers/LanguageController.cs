using CoreActionResult.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreActionResult.Controllers
{
    public class LanguageController : Controller
    {
        public IActionResult SelectLanguages()
        {
            var model = new ProgrammingLanguagesViewModel
            {
                LanguageOptions = new List<LanguageOption>
                {
                    new LanguageOption {IsSelected = false, LanguageName="C#"},
                    new LanguageOption {IsSelected = false, LanguageName="ASP.NET Core"},
                    new LanguageOption {IsSelected = false, LanguageName="Python"},
                    new LanguageOption {IsSelected = false, LanguageName="Java"},
                    new LanguageOption {IsSelected = false, LanguageName="Ruby"},
                    new LanguageOption {IsSelected = false, LanguageName="C++"}
                }
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult SubmitLanguages(ProgrammingLanguagesViewModel model)
        {
            var selectedLanguages = model.LanguageOptions.Where(option => option.IsSelected)
                .Select(option => option.LanguageName).ToList();
            ViewBag.SelectedLanguages = selectedLanguages;
            return View("SelectedLanguages", selectedLanguages);
        }
    }
}
