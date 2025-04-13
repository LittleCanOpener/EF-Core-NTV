using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;
using System.Threading.Tasks;
using StudentManagement.Examples;
using StudentManagement.Models;
using StudentManagement.Repositories;

namespace StudentManagement.Controllers
{
    [Route("api/groups")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupRepository _repository;

        public GroupsController(IGroupRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var groups = await _repository.GetAllAsync();
            return Ok(groups);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var group = await _repository.GetByIdAsync(id);
            if (group == null) return NotFound();
            return Ok(group);
        }

        [HttpPost]
        [SwaggerRequestExample(typeof(Group), typeof(GroupExample))]
        public async Task<IActionResult> Add([FromBody] Group group)
        {
            await _repository.AddAsync(group);
            return CreatedAtAction(nameof(GetById), new { id = group.GroupId }, group);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Group group)
        {
            if (id != group.GroupId) return BadRequest();
            await _repository.UpdateAsync(group);
            return Ok(group);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}