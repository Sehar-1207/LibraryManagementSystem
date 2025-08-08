using Application.Contracts.Interfaces;
using Application.Features.Reservation.Command;
using Application.Services;
using MediatR;

namespace Application.Features.Reservation.Handler
{
    public class CompleteReservationHandler : IRequestHandler<CompleteReservationCommand, ServiceResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompleteReservationHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResponse<int>> Handle(CompleteReservationCommand request, CancellationToken cancellationToken)
        {
            var reservation = await _unitOfWork.Reserv.GetByIdAsync(request.ReservationId, cancellationToken);

            if (reservation == null)
            {
                return new ServiceResponse<int>
                {
                    Data = 0,
                    Success = false,
                    Message = "Reservation completion failed: not found"
                };
            }

            reservation.IsCompleted = true;

            await _unitOfWork.Reserv.UpdateAsync(reservation, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new ServiceResponse<int>
            {
                Data = reservation.Id,
                Success = true,
                Message = "Reservation completed successfully"
            };
        }
    }
}
