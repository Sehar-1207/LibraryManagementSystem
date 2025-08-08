using Application.Contracts.Interfaces;
using Application.Features.Reservation.Query;
using Application.Services;
using Domain.Entities;
using MediatR;

namespace Application.Features.Reservation.Handler
{
    public class GetReservationsByBookHandler : IRequestHandler<GetReservationByBookQuery, ServiceResponse<IEnumerable<Domain.Entities.Reservation>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetReservationsByBookHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResponse<IEnumerable<Domain.Entities.Reservation>>> Handle(GetReservationByBookQuery request, CancellationToken cancellationToken)
        {
            var reservations = await _unitOfWork.Reserv.GetReservationsByBookAsync(request.BookId, cancellationToken);

            return new ServiceResponse<IEnumerable<Domain.Entities.Reservation>>
            {
                Data = reservations,
                Success = true,
                Message = "Reservations fetched successfully"
            };
        }
    }
}
