using Application.Services;
using MediatR;

namespace Application.Features.Reservation.Command
{
    public class DeleteReservationCommand : IRequest<ServiceResponse<int>>
    {
        public int Id { get; set; }
    }
}


