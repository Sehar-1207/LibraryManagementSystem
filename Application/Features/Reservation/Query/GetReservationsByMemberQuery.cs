using Application.Services;
using MediatR;

namespace Application.Features.Reservation.Query
{
    public class GetReservationsByMemberQuery : IRequest<ServiceResponse<IEnumerable<Domain.Entities.Reservation>>>
    {
        public int MemberId { get; set; }
    }
}
