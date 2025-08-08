using Application.Services;
using MediatR;

public class CompleteReservationCommand : IRequest<ServiceResponse<int>>
{
    public int ReservationId { get; set; }
}