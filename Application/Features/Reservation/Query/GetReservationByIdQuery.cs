using Application.Dtos.Books;
using Application.Services;
using MediatR;

namespace Application.Features.Reservation.Query
{
    public class GetReservationByIdQuery : IRequest<ServiceResponse<ReservationDto>>
    {
        public int Id { get; set; }
    }
}
