using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagementFile.API.Models;
using StudentManagementFile.API.Services;

namespace StudentManagementFile.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseSerivce;
        public CourseController(ICourseService courseService)
        {
            _courseSerivce = courseService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var courses  = _courseSerivce.GetAll();
            return Ok(ApiResponse<List<Course>>.Ok(courses, $"{courses.Count} coursed found"));
        }
        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            var course = _courseSerivce.GetById(id);
            if(course == null)
                return NotFound(ApiResponse<Course>.Fail($"Course with Id {id} not found"));
            return Ok(ApiResponse<Course>.Ok(course, "Success"));
        }
        [HttpPost]
        public IActionResult Create([FromBody] Course course)
        {
            if(!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return BadRequest(ApiResponse<Course>.Fail(string.Join(" | ", errors)));
            }
            var created = _courseSerivce.Add(course);
            return CreatedAtAction(nameof(GetById), new { id = created.Id},
            ApiResponse<Course>.Ok(created,"Course created successfully"));
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Course course)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<Course>.Fail("Invalid Data"));
            }
            var success = _courseSerivce.Update(course,id);
            if(!success) 
                return NotFound(ApiResponse<Course>.Fail($"Course with id {id} not found"));
            var updated = _courseSerivce.GetById(id);
            return Ok(ApiResponse<Course>.Ok(updated!, "Course updated successfully"));
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _courseSerivce.Delete(id);
            if(!success)
                return NotFound(ApiResponse<object>.Fail($"Course with id {id} not found"));
            return Ok(ApiResponse<object>.Ok(null!,$"Course wit id {id} deleted successfully"));
        }
    }
}