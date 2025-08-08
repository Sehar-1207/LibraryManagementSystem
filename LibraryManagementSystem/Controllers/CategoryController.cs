using Application.Dtos.Books;
using Application.Features.Categories.Command;
using Application.Features.Categories.Query;
using Application.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
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

        // ✅ GET: api/categories
        [HttpGet]
        public async Task<ActionResult<List<CategoryDto>>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllCategoriesQuery(), cancellationToken);
            return Ok(result);
        }

        // ✅ GET: api/categories/{id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<CategoryDto>> GetById(int id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetCategoryByIdQuery(id), cancellationToken);
            if (result == null)
                return NotFound($"Category with ID {id} not found.");

            return Ok(result);
        }

        // ✅ POST: api/categories
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<int>>> Create([FromBody] CreateCategoryCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        // ✅ PUT: api/categories/{id}
        [HttpPut("{id:int}")]
        public async Task<ActionResult<ServiceResponse<int>>> Update(int id, [FromBody] UpdateCategoryCommand command, CancellationToken cancellationToken)
        {
            if (id != command.Id)
                return BadRequest("ID in URL does not match ID in request body.");

            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        // ✅ DELETE: api/categories/{id}
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ServiceResponse<int>>> Delete(int id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new DeleteCategoryCommand(id), cancellationToken);
            return Ok(result);
        }
    }
}
