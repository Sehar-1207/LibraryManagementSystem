using Application.Services;
using MediatR;

namespace Application.Features.Reservation.Query
{
    public class GetNextReservationQuery : IRequest<ServiceResponse<Domain.Entities.Reservation>>
    {
        public int BookId { get; set; }
    }
}
