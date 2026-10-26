using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using StudentManagementFile.API.Models;

namespace StudentManagementFile.API.Services
{
    public class UserService : IUserService
    {
        private readonly string _filePath;
        private readonly object _lock = new();
        public UserService(IConfiguration config)
        {
            // Users ke liye alag file use karenge
            var relativePath = "Data/users.json"; 
            _filePath = Path.Combine(Directory.GetCurrentDirectory(), relativePath);
            
            var dir = Path.GetDirectoryName(_filePath);
            if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                Directory.CreateDirectory(dir);
                
            if (!File.Exists(_filePath))
                File.WriteAllText(_filePath, JsonSerializer.Serialize(new List<User>()));
        }
        public User Add(User user)
        {
            lock (_lock)
            {
                var users = GetAll();
                user.Id = users.Any() ? users.Max(u => u.Id) + 1 : 1;
                users.Add(user);
                SaveToFile(users);
                return user;
            }
        }

        public User? GetByUsername(string username)
        {
            lock (_lock)
            {
                var users = GetAll();
                return users.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
            }
        }

        public bool UserExists(string username, string email)
        {
            lock (_lock)
            {
                var users = GetAll();
                return users.Any(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase) || 
                                      u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
            }
        }
        private List<User> GetAll()
        {
            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
        }

        private void SaveToFile(List<User> users)
        {
            var json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }
    }
}