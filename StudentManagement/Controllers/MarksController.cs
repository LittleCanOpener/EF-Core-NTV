using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;
using System.Threading.Tasks;
using StudentManagement.Examples;
using StudentManagement.Models;
using StudentManagement.Repositories;

namespace StudentManagement.Controllers
{
    [Route("api/marks")]
    [ApiController]
    public class MarksController : ControllerBase
    {
        private readonly IMarkRepository _repository;

        public MarksController(IMarkRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var marks = await _repository.GetAllAsync();
            return Ok(marks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var mark = await _repository.GetByIdAsync(id);
            if (mark == null) return NotFound();
            return Ok(mark);
        }

        [HttpPost]
        [SwaggerRequestExample(typeof(Mark), typeof(MarkExample))]
        public async Task<IActionResult> Add([FromBody] Mark mark)
        {
            await _repository.AddAsync(mark);
            return CreatedAtAction(nameof(GetById), new { id = mark.MarkId }, mark);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Mark mark)
        {
            if (id != mark.MarkId) return BadRequest();
            await _repository.UpdateAsync(mark);
            return Ok(mark);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}