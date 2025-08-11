using Application.Contracts.Interfaces;
using Application.Features.Reservation.Command;
using Application.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Reservation.Handlers
{
    public class UpdateReservationCommandHandler : IRequestHandler<UpdateReservationCommand, ServiceResponse<int>>
    {
        private readonly IUnitOfWork _uow;

        public UpdateReservationCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<ServiceResponse<int>> Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
        {
            var reservation = await _uow.Reserv.GetByIdAsync(request.Id, cancellationToken);

            if (reservation == null)
            {
                return new ServiceResponse<int>(0, false, "Reservation not found");
            }

            reservation.BookId = request.BookId;
            reservation.MemberId = request.MemberId;
            reservation.ReservationDate = request.ReservedDate; // or request.ReservationDate if renamed
            reservation.ExpiryDate = request.DueDate; // or request.ExpiryDate if renamed

            await _uow.Reserv.UpdateAsync(reservation, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);

            return new ServiceResponse<int>(reservation.Id, true, "Reservation updated successfully");
        }
    }
}
