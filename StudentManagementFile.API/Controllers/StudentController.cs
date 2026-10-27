using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagementFile.API.Models;
using StudentManagementFile.API.Models.DTOs;
using StudentManagementFile.API.Services;

namespace StudentManagementFile.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<PagedResult<Student>>), 200)]
        public IActionResult GetAll([FromQuery] StudentQueryParameters query)
        {
            var result = _studentService.GetFiltered(query);

            var message = result.TotalCount == 0
                ? "No students found matching the criteria"
                : $"{result.Items.Count} students found out of {result.TotalCount} total";

            return Ok(ApiResponse<PagedResult<Student>>.Ok(result, message));
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = _studentService.GetById(id);
            if(student == null)
                return NotFound(ApiResponse<Student>.Fail($"Student with Id {id} not found"));
            return Ok(ApiResponse<Student>.Ok(student,"Successfully getting"));
        }
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<Student>), 201)]
        [ProducesResponseType(typeof(ApiResponse<Student>), 400)]
        public IActionResult Create([FromBody] Student student)
        {
            if (!ModelState.IsValid)
                return BadRequest(ApiResponse<Student>.Fail("Invalid data"));

            var created = _studentService.Add(student);
            var response = ApiResponse<Student>.Ok(created, "Student created successfully");
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, response);
        }
        [Authorize(Roles ="Admin")]
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApiResponse<Student>), 200)]
        [ProducesResponseType(typeof(ApiResponse<Student>), 404)]
        [ProducesResponseType(typeof(ApiResponse<Student>), 400)]
        public IActionResult Update(int id, [FromBody] Student student)
        {
            if (!ModelState.IsValid)
                return BadRequest(ApiResponse<Student>.Fail("Invalid data"));

            var success = _studentService.Update(id, student);
            if (!success)
                return NotFound(ApiResponse<Student>.Fail($"Student with Id {id} not found"));

            var updated = _studentService.GetById(id);
            return Ok(ApiResponse<Student>.Ok(updated!, "Student updated successfully"));
        }
        [Authorize(Roles ="Admin")]
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApiResponse<object>), 200)]
        [ProducesResponseType(typeof(ApiResponse<object>), 404)]
        public IActionResult Delete(int id)
        {
            var success = _studentService.Delete(id);
            if (!success)
                return NotFound(ApiResponse<object>.Fail($"Student with Id {id} not found for deletion"));

            return Ok(ApiResponse<object>.Ok(null!, $"Student with Id {id} deleted successfully"));
        }
        [HttpGet("details")]
        [ProducesResponseType(typeof(ApiResponse<List<StudentWithCourseDTO>>), 200)]
        public IActionResult GetAllWtihDetails()
        {
            var result = _studentService.GetAllWtihCourseDetails();
            return Ok(ApiResponse<List<StudentWithCourseDTO>>.Ok(result, $"{result.Count} students with course details found"));
        }
    }
}