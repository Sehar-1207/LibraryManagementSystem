using Application.Contracts.Interfaces;
using Application.Features.Reservation.Query;
using Application.Services;
using MediatR;

namespace Application.Features.Reservation.Handler
{
    public class GetNextReservationHandler : IRequestHandler<GetNextReservationQuery, ServiceResponse<Domain.Entities.Reservation>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetNextReservationHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResponse<Domain.Entities.Reservation>> Handle(GetNextReservationQuery request, CancellationToken cancellationToken)
        {
            var reservation = await _unitOfWork.Reserv.GetNextReservationAsync(request.BookId, cancellationToken);

            return new ServiceResponse<Domain.Entities.Reservation>
            {
                Data = reservation,
                Success = reservation != null,
                Message = reservation != null ? "Next reservation retrieved successfully" : "No reservation found for this book"
            };
        }
    }
}
