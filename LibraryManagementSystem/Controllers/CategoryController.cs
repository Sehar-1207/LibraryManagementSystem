using Application.Dtos.Books;
using Application.Features.Categories.Command;
using Application.Features.Categories.Query;
using Application.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/category
        [HttpGet]
        public async Task<ActionResult<List<CategoryDto>>> GetAll(CancellationToken cancellationToken)
        {
            var categories = await _mediator.Send(new GetAllCategoriesQuery(), cancellationToken);
            return Ok(categories);
        }

        // GET: api/category/{id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<CategoryDto>> GetById(int id, CancellationToken cancellationToken)
        {
            var category = await _mediator.Send(new GetCategoryByIdQuery(id), cancellationToken);
            if (category == null)
                return NotFound($"Category with ID {id} not found.");

            return Ok(category);
        }

        // POST: api/category
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<int>>> Create([FromBody] CreateCategoryCommand command, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(command, cancellationToken);
            if (!response.Success)
                return BadRequest(response.Message);

            // Return 201 Created with route to new resource
            return CreatedAtAction(nameof(GetById), new { id = response.Data }, response);
        }

        // PUT: api/category/{id}
        [HttpPut("{id:int}")]
        public async Task<ActionResult<ServiceResponse<int>>> Update(int id, [FromBody] UpdateCategoryCommand command, CancellationToken cancellationToken)
        {
            if (id != command.Id)
                return BadRequest("ID in URL does not match ID in request body.");

            var response = await _mediator.Send(command, cancellationToken);
            if (!response.Success)
                return BadRequest(response.Message);

            return Ok(response);
        }

        // DELETE: api/category/{id}
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ServiceResponse<int>>> Delete(int id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new DeleteCategoryCommand(id), cancellationToken);
            if (!response.Success)
                return BadRequest(response.Message);

            return Ok(response);
        }
    }
}
