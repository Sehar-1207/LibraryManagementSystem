using Application.Dtos.Books;
using Application.Services;
using MediatR;

namespace Application.Features.Reservation.Query
{
    public class GetAllReservationsQuery : IRequest<ServiceResponse<List<ReservationDto>>>
    {
    }
}
