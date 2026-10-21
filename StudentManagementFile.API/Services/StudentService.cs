using System.Linq;
using System.Text.Json;
using StudentManagementFile.API.Models;

namespace StudentManagementFile.API.Services
{
    public class StudentService : IStudentService
    {
        private readonly string _filePath;
        private readonly object _lock = new(); // Thread safety ke liye

        public StudentService()
        {
            // File project ke root folder mein banegi
            _filePath = Path.Combine(Directory.GetCurrentDirectory(), "students.json");
            
            // Agar file exist nahi karti, toh empty list ke saath create karein
            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, JsonSerializer.Serialize(new List<Student>()));
            }
        }

        public List<Student> GetAll()
        {
            lock (_lock)
            {
                var json = File.ReadAllText(_filePath);
                return JsonSerializer.Deserialize<List<Student>>(json) ?? new List<Student>();
            }
        }

        public Student? GetById(int id)
        {
            return GetAll().FirstOrDefault(s => s.Id == id);
        }

        public Student Add(Student student)
        {
            lock (_lock)
            {
                var students = GetAll();
                // Auto-increment Id logic
                student.Id = students.Any() ? students.Max(s => s.Id) + 1 : 1;
                students.Add(student);
                SaveToFile(students);
                return student;
            }
        }

        public bool Update(int id, Student updatedStudent)
        {
            lock (_lock)
            {
                var students = GetAll();
                var existing = students.FirstOrDefault(s => s.Id == id);
                if (existing == null) return false;

                existing.Name = updatedStudent.Name;
                existing.Email = updatedStudent.Email;
                existing.Age = updatedStudent.Age;
                existing.Course = updatedStudent.Course;

                SaveToFile(students);
                return true;
            }
        }

        public bool Delete(int id)
        {
            lock (_lock)
            {
                var students = GetAll();
                var student = students.FirstOrDefault(s => s.Id == id);
                if (student == null) return false;

                students.Remove(student);
                SaveToFile(students);
                return true;
            }
        }

        private void SaveToFile(List<Student> students)
        {
            var json = JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }
    }
}