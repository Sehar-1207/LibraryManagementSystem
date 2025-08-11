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

        // POST: api/reservation/add
        [HttpPost("add")]
        public async Task<ActionResult<ServiceResponse<int>>> AddReservation([FromBody] AddReservationCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // DELETE: api/reservation/cancel/{id}
        [HttpDelete("cancel/{id}")]
        public async Task<ActionResult<ServiceResponse<int>>> CancelReservation(int id)
        {
            var command = new CancelReservationCommand { ReservationId = id };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT: api/reservation/complete/{id}
        [HttpPut("complete/{id}")]
        public async Task<ActionResult<ServiceResponse<int>>> CompleteReservation(int id)
        {
            var command = new CompleteReservationCommand { ReservationId = id };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // GET: api/reservation/all
        [HttpGet("all")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<Reservation>>>> GetAllReservations()
        {
            var query = new GetAllReservationsQuery();
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        // GET: api/reservation/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Reservation>>> GetReservationById(int id)
        {
            var query = new GetReservationByIdQuery { Id = id };
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        // GET: api/reservation/by-book/{bookId}
        [HttpGet("by-book/{bookId}")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<Reservation>>>> GetByBook(int bookId)
        {
            var query = new GetReservationByBookQuery { BookId = bookId };
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        // GET: api/reservation/by-member/{memberId}
        [HttpGet("by-member/{memberId}")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<Reservation>>>> GetByMember(int memberId)
        {
            var query = new GetReservationsByMemberQuery { MemberId = memberId };
            var response = await _mediator.Send(query);
            return Ok(response);
        }

    }
}
