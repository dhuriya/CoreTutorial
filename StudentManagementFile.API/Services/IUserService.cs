using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentManagementFile.API.Models;

namespace StudentManagementFile.API.Services
{
    public interface IUserService
    {
        User? GetByUsername(string username);
        User Add(User user);
        bool UserExists(string username, string email);
    }
}