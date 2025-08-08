using Application.Dtos;
using Application.Features.Members.Commands;
using Application.Features.Members.Queries;
using Application.Features.Members.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MemberController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // ✅ Get all members
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllMembersQuery(), cancellationToken);
            return Ok(result);
        }

        // ✅ Get member by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetMemberByIdQuery(id), cancellationToken);
            return Ok(result);
        }


        // ✅ Add new member
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MemberDto memberDto, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new CreateMemberCommand { MemberDto = memberDto }, cancellationToken);
            return Ok(result);
        }

        // ✅ Update member
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] MemberDto memberDto, CancellationToken cancellationToken)
        {
            memberDto.Id = id; // Assign route ID to DTO manually
            var result = await _mediator.Send(new UpdateMemberCommand { MemberDto = memberDto }, cancellationToken);
            return Ok(result);
        }

        // ✅ Delete member
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new DeleteMemberCommand { Id = id }, cancellationToken);
            return Ok(result);
        }
    }
}
