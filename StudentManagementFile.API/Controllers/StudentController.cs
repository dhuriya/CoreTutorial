using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentManagementFile.API.Models;
using StudentManagementFile.API.Services;

namespace StudentManagementFile.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_studentService.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = _studentService.GetById(id);
            if(student == null)
                return NotFound("Student is not found!");
            return Ok(student);
        }
        [HttpPost("Create")]
        public IActionResult Create([FromBody] Student student)
        {
            if(student == null) return BadRequest();
            var created = _studentService.Add(student);
            return CreatedAtAction(nameof(GetById), new {id = created.Id},created);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]Student student)
        {
            if(student == null) return BadRequest();
            var success = _studentService.Update(id,student);
            if(!success) return NotFound("Student is not found!");
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _studentService.Delete(id);
            if(!success) return NotFound("Student id not found!. for Deleting!.");
            return NoContent();
        }

    }
}