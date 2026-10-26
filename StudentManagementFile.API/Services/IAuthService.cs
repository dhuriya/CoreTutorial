using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentManagementFile.API.Models;
using StudentManagementFile.API.Models.DTOs;

namespace StudentManagementFile.API.Services
{
    public interface IAuthService
    {
        AuthResponse? Register(RegisterRequest request);
        AuthResponse? Login(LoginRequest request);
    }
}