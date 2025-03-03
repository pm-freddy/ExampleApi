using ExampleApi.Data.Models;
using ExampleApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExampleApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExampleController : ControllerBase
    {
        private readonly IExampleCrudService _exampleCrudService;

        public ExampleController(IExampleCrudService exampleCrudService)
        {
            _exampleCrudService = exampleCrudService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ExampleEntity exampleEntity)
        {
            if (exampleEntity == null)
            {
                return BadRequest("Invalid entity data.");
            }

            var createdEntity = await _exampleCrudService.CreateExampleEntityAsync(exampleEntity);
            return CreatedAtAction(nameof(GetById), new { id = createdEntity.Id }, createdEntity);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var entity = await Task.Run(() => _exampleCrudService.ReadExampleEntityAsync(id));
            if (entity == null)
            {
                return NotFound($"Entity with ID {id} not found.");
            }
            return Ok(entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ExampleEntity updatedEntity)
        {
            if (updatedEntity == null || id != updatedEntity.Id)
            {
                return BadRequest("Invalid entity data.");
            }

            var entity = await _exampleCrudService.UpdateExampleEntityAsync(updatedEntity);
            return Ok(entity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _exampleCrudService.DeleteExampleEntityAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }

}
