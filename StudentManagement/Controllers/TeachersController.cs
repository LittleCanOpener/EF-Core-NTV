using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;
using System.Threading.Tasks;
using StudentManagement.Examples;
using StudentManagement.Models;
using StudentManagement.Repositories;

namespace StudentManagement.Controllers
{
    [Route("api/teachers")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherRepository _repository;

        public TeachersController(ITeacherRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var teachers = await _repository.GetAllAsync();
            return Ok(teachers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var teacher = await _repository.GetByIdAsync(id);
            if (teacher == null) return NotFound();
            return Ok(teacher);
        }

        [HttpPost]
        [SwaggerRequestExample(typeof(Teacher), typeof(TeacherExample))]
        public async Task<IActionResult> Add([FromBody] Teacher teacher)
        {
            await _repository.AddAsync(teacher);
            return CreatedAtAction(nameof(GetById), new { id = teacher.TeacherId }, teacher);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Teacher teacher)
        {
            if (id != teacher.TeacherId) return BadRequest();
            await _repository.UpdateAsync(teacher);
            return Ok(teacher);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}