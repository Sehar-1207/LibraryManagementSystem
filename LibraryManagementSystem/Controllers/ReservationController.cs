using Application.Features.Reservation.Command;
using Application.Features.Reservation.Query;
using Application.Services;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReservationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // ✅ Add a reservation
        [HttpPost("add")]
        public async Task<ActionResult<ServiceResponse<int>>> AddReservation([FromBody] AddReservationCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // ✅ Update (Edit) reservation
        [HttpPut("edit/{id}")]
        public async Task<ActionResult<ServiceResponse<int>>> EditReservation(int id, [FromBody] UpdateReservationCommand command)
        {
            if (id != command.Id)
                return BadRequest("Reservation ID mismatch.");

            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // ✅ Delete reservation
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<ServiceResponse<int>>> DeleteReservation(int id)
        {
            var command = new DeleteReservationCommand { Id = id };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // ✅ Cancel a reservation
        [HttpDelete("cancel/{id}")]
        public async Task<ActionResult<ServiceResponse<int>>> CancelReservation(int id)
        {
            var command = new CancelReservationCommand { ReservationId = id };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // ✅ Complete a reservation
        [HttpPut("complete/{id}")]
        public async Task<ActionResult<ServiceResponse<int>>> CompleteReservation(int id)
        {
            var command = new CompleteReservationCommand { ReservationId = id };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // ✅ Get all reservations
        [HttpGet("all")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<Reservation>>>> GetAllReservations()
        {
            var query = new GetAllReservationsQuery();
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        // ✅ Get reservation by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Reservation>>> GetReservationById(int id)
        {
            var query = new GetReservationByIdQuery { Id = id };
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        // ✅ Get reservations by book
        [HttpGet("by-book/{bookId}")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<Reservation>>>> GetByBook(int bookId)
        {
            var query = new GetReservationByBookQuery { BookId = bookId };
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        // ✅ Get reservations by member
        [HttpGet("by-member/{memberId}")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<Reservation>>>> GetByMember(int memberId)
        {
            var query = new GetReservationsByMemberQuery { MemberId = memberId };
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        // ✅ (Optional) Get next reservation for a book
        [HttpGet("next/{bookId}")]
        public async Task<ActionResult<ServiceResponse<Reservation>>> GetNextReservation(int bookId)
        {
            var query = new GetNextReservationQuery { BookId = bookId };
            var response = await _mediator.Send(query);
            return Ok(response);
        }
    }
}
