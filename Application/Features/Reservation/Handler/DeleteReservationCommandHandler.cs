using Application.Contracts.Interfaces;
using Application.Features.Reservation.Command;
using Application.Services;
using MediatR;

namespace Application.Features.Reservation.Handlers
{
    public class DeleteReservationCommandHandler : IRequestHandler<DeleteReservationCommand, ServiceResponse<int>>
    {
        private readonly IUnitOfWork _uow;

        public DeleteReservationCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<ServiceResponse<int>> Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
        {
            var reservation = await _uow.Reserv.GetByIdAsync(request.Id);

            if (reservation == null)
                return new ServiceResponse<int>(0, false, "Reservation not found");

            await _uow.Reserv.DeleteAsync(reservation, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);

            return new ServiceResponse<int>(reservation.Id, true, "Reservation deleted successfully");
        }
    }
}
