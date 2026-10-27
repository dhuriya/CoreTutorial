using System.Text.Json;
using StudentManagementFile.API.Models;
using StudentManagementFile.API.Models.DTOs;

namespace StudentManagementFile.API.Services
{
    public class StudentService : IStudentService
    {
        private readonly ICourseService _courseService;
        private readonly string _filePath;
        private readonly object _lock = new(); // Thread safety ke liye

        // ─────────────────────────────────────────────────────────
        // Constructor 1: Production ke liye (DI se IConfiguration aata hai)
        // ─────────────────────────────────────────────────────────
        public StudentService(IConfiguration config, ICourseService courseService)
        {
            _courseService = courseService;
            var relativePath = config["StudentFileSettings:FilePath"] ?? "students.json";
            _filePath = Path.Combine(Directory.GetCurrentDirectory(), relativePath);
            InitializeFile();
        }

        // ─────────────────────────────────────────────────────────
        // Constructor 2: Testing ke liye (direct file path)
        // ─────────────────────────────────────────────────────────
        public StudentService(string fileName)
        {
            _filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);
            _courseService = null!; // Test-only constructor
            InitializeFile();
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
                existing.CourseId = updatedStudent.CourseId;

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
       public PagedResult<Student> GetFiltered(StudentQueryParameters query)
        {
            var students = GetAll().AsQueryable();

            // 1. Search filter (name ya email mein)
            if (!string.IsNullOrWhiteSpace(query.Search))
            {
                var search = query.Search.Trim().ToLower();
                students = students.Where(s =>
                    s.Name.ToLower().Contains(search) ||
                    s.Email.ToLower().Contains(search));
            }

            // 2. Course filter (Ab CourseId integer se match hoga)
            if (query.CourseId.HasValue)
            {
                students = students.Where(s => s.CourseId == query.CourseId.Value);
            }

            // 3. Age range filter
            if (query.MinAge.HasValue)
                students = students.Where(s => s.Age >= query.MinAge.Value);

            if (query.MaxAge.HasValue)
                students = students.Where(s => s.Age <= query.MaxAge.Value);

            // 4. Sorting
            students = (query.SortBy?.ToLower(), query.SortOrder?.ToLower()) switch
            {
                ("name", "desc") => students.OrderByDescending(s => s.Name),
                ("name", _)      => students.OrderBy(s => s.Name),
                ("email", "desc") => students.OrderByDescending(s => s.Email),
                ("email", _)     => students.OrderBy(s => s.Email),
                ("age", "desc")  => students.OrderByDescending(s => s.Age),
                ("age", _)       => students.OrderBy(s => s.Age),
                ("courseid", "desc") => students.OrderByDescending(s => s.CourseId), // 👈 Updated
                ("courseid", _)  => students.OrderBy(s => s.CourseId),               // 👈 Updated
                ("id", "desc")   => students.OrderByDescending(s => s.Id),
                _                => students.OrderBy(s => s.Id)  // default
            };

            // 5. Total count (pagination se pehle)
            var totalCount = students.Count();

            // 6. Pagination
            var skip = (long)(query.Page - 1) * query.PageSize;
            var items = skip >= totalCount
                ? new List<Student>()
                : students.Skip((int)skip).Take(query.PageSize).ToList();

            return new PagedResult<Student>
            {
                Items = items,
                TotalCount = totalCount,
                Page = query.Page,
                PageSize = query.PageSize
            };
        }

        // ─────────────────────────────────────────────────────────
        // Common initialization logic (duplicate code avoid karne ke liye)
        // ─────────────────────────────────────────────────────────
        private void InitializeFile()
        {
            var dir = Path.GetDirectoryName(_filePath);
            if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            if (!File.Exists(_filePath))
                File.WriteAllText(_filePath, JsonSerializer.Serialize(new List<Student>()));
        }

        public List<StudentWithCourseDTO> GetAllWtihCourseDetails()
        {
            var students = GetAll();
            var courses = _courseService.GetAll();
            //LINQ join (Student + Course)
            var result = from s in students
                         join c in courses on s.CourseId equals c.Id into studentCourse
                         from c in studentCourse.DefaultIfEmpty()
                         select new StudentWithCourseDTO{
                            Id = s.Id,
                            Name = s.Name,
                            Email = s.Email,
                            Age = s.Age,
                            CourseId = s.CourseId,
                            CourseName = c?.CourseName ?? "Unknown Course",
                            CourseCode = c?.CourseCode ?? "N/A"
                         };
            return result.ToList();
        }
    }
}