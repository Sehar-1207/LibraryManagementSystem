using Application.Services;
using MediatR;
namespace Application.Features.Reservation.Query
{
    public class GetReservationByBookQuery : IRequest<ServiceResponse<IEnumerable<Domain.Entities.Reservation>>>
    {
        public int BookId { get; set; }
    }
  
}
