using CoreActionResult.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;

namespace CoreActionResult.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private List<Role> GetAvailableRoles()
        {
            return new List<Role>
            {
                new Role{RoleId = 1,RoleName="Admin"},
                new Role{RoleId = 2,RoleName="Editor"},
                new Role{RoleId=3,RoleName="Viewer"}
            };
        }
        public IActionResult AssignRoles(int userId =1)
        {
            var model = new UserRoleViewModel
            {
                UserId = userId,
                Username = "Deepu",
                AvailableRoles = GetAvailableRoles()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult AssignRoles(UserRoleViewModel model)
        {
            model.AvailableRoles = GetAvailableRoles();
            if(model.SelectedRoleIds!=null)
            {
                var assignedRoles = model.AvailableRoles.Where
                    (role => model.SelectedRoleIds.Contains(role.RoleId)).ToList();
                ViewBag.Message = $"Roles assigned to {model.Username}: {string.Join(", ", assignedRoles.Select(r => r.RoleName))}";
            }
            else
            {
                ViewBag.Message = "No roles selected.";
            }
            return View(model);
        }
    }
}
