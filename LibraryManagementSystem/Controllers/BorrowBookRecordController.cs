using Application.Dtos.Books;
using Application.Features.BorrowingRecord.Command;
using Application.Features.BorrowingRecord.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowBookRecordController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BorrowBookRecordController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST: api/BorrowingRecord
        [HttpPost]
        public async Task<IActionResult> AddRecord([FromBody] BorrowRecordDto dto, CancellationToken cancellationToken)
        {
            var command = new AddRecordCommand(dto);
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        // PUT: api/BorrowingRecord
        [HttpPut]
        public async Task<IActionResult> UpdateRecord([FromBody] BorrowRecordDto dto, CancellationToken cancellationToken)
        {
            var command = new UpdateRecordCommand(dto);
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        // DELETE: api/BorrowingRecord/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecord(int id, CancellationToken cancellationToken)
        {
            var command = new DeleteRecordCommand(id);
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        // GET: api/BorrowingRecord
        [HttpGet]
        public async Task<IActionResult> GetAllRecords(CancellationToken cancellationToken)
        {
            var query = new GetAllRecordsQuery();
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        // GET: api/BorrowingRecord/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecordById(int id, CancellationToken cancellationToken)
        {
            var query = new GetRecordByIdQuery(id);
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }
    }
}
