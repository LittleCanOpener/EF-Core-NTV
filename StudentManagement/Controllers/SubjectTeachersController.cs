using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;
using System.Threading.Tasks;
using StudentManagement.Examples;
using StudentManagement.Models;
using StudentManagement.Repositories;

namespace StudentManagement.Controllers
{
    [Route("api/subjectteachers")]
    [ApiController]
    public class SubjectTeachersController : ControllerBase
    {
        private readonly ISubjectTeacherRepository _repository;

        public SubjectTeachersController(ISubjectTeacherRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var subjectTeachers = await _repository.GetAllAsync();
            return Ok(subjectTeachers);
        }

        [HttpGet("{subjectId}/{teacherId}")]
        public async Task<IActionResult> GetById(int subjectId, int teacherId)
        {
            var subjectTeacher = await _repository.GetByIdAsync(subjectId, teacherId);
            if (subjectTeacher == null) return NotFound();
            return Ok(subjectTeacher);
        }

        [HttpPost]
        [SwaggerRequestExample(typeof(SubjectTeacher), typeof(SubjectTeacherExample))]
        public async Task<IActionResult> Add([FromBody] SubjectTeacher subjectTeacher)
        {
            await _repository.AddAsync(subjectTeacher);
            return CreatedAtAction(nameof(GetById), new { subjectId = subjectTeacher.SubjectId, teacherId = subjectTeacher.TeacherId }, subjectTeacher);
        }

        [HttpDelete("{subjectId}/{teacherId}")]
        public async Task<IActionResult> Delete(int subjectId, int teacherId)
        {
            await _repository.DeleteAsync(subjectId, teacherId);
            return NoContent();
        }
    }
}