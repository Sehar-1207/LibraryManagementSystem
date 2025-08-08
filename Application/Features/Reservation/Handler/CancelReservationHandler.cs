using Application.Contracts.Interfaces;
using Application.Features.Reservation.Command;
using Application.Services;
using MediatR;

public class CancelReservationHandler : IRequestHandler<CancelReservationCommand, ServiceResponse<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CancelReservationHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ServiceResponse<int>> Handle(CancelReservationCommand request, CancellationToken cancellationToken)
    {
        var reservation = await _unitOfWork.Reserv.GetByIdAsync(request.ReservationId, cancellationToken);
        if (reservation == null)
        {
            return new ServiceResponse<int>
            {
                Data = 0,
                Success = false,
                Message = "Reservation cancellation failed: Reservation not found"
            };
        }

        await _unitOfWork.Reserv.DeleteAsync(reservation, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new ServiceResponse<int>
        {
            Data = reservation.Id,
            Success = true,
            Message = "Reservation canceled successfully"
        };
    }
}
