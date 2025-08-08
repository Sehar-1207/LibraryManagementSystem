using Application.Services;
using MediatR;

namespace Application.Features.Reservation.Command
{
    public class CancelReservationCommand : IRequest<ServiceResponse<int>>
    {
        public int ReservationId { get; set; }
    }
}
