using System.Text.Json;
using StudentManagementFile.API.Models;

namespace StudentManagementFile.API.Services
{
    public class CourseService : ICourseService
    {
        private readonly string _filPath;
        private readonly object _lock = new();
        public CourseService(IConfiguration config)
        {
            var relativePath = "Data/course.json";
            _filPath = Path.Combine(Directory.GetCurrentDirectory(),relativePath);

            var dir = Path.GetDirectoryName(_filPath);
            if(!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            if(!File.Exists(_filPath))
                File.WriteAllText(_filPath, JsonSerializer.Serialize(new List<Course>()));
        }
        public List<Course> GetAll()
        {
            lock(_lock)
            {
                var json = File.ReadAllText(_filPath);
                return JsonSerializer.Deserialize<List<Course>>(json) ?? new List<Course>();
            }
        }
        public Course Add(Course course)
        {
            lock(_lock)
            {
                var courses = GetAll();
                course.Id = courses.Any() ? courses.Max(c => c.Id) + 1 : 1;
                courses.Add(course);
                SaveToFile(courses);
                return course;
            }
        }
        public Course? GetById(int id)
        {
            return GetAll().FirstOrDefault(c => c.Id == id);
        }
        public bool Update(Course updatedCourse, int id)
        {
            lock(_lock)
            {
                var courses = GetAll();
                var existing = courses.FirstOrDefault(c => c.Id == id);
                if(existing == null)
                    return false;
                existing.CourseName = updatedCourse.CourseName;
                existing.CourseCode = updatedCourse.CourseCode;
                existing.DurationInSemesters = updatedCourse.DurationInSemesters;
                existing.Fee = updatedCourse.Fee;
                SaveToFile(courses);
                return true;
            }
        }
        public bool Delete(int id)
        {
            lock(_lock)
            {
                var courses = GetAll();
                var course = courses.FirstOrDefault(c => c.Id == id);
                if(course == null)
                    return false;
                courses.Remove(course);
                SaveToFile(courses);
                return true;
            }
        }
        private void SaveToFile(List<Course> courses)
        {
            var json = JsonSerializer.Serialize(courses, new JsonSerializerOptions{ WriteIndented = true});
            File.WriteAllText(_filPath, json);
        }
    }
}