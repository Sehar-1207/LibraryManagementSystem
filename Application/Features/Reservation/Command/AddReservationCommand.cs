using Application.Dtos.Books;
using Application.Services;
using MediatR;

namespace Application.Features.Reservation.Command
{
    public class AddReservationCommand : IRequest<ServiceResponse<int>>
    {
        public ReservationDto ReservationDto { get; set; }
    }
}

