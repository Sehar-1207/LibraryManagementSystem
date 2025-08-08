using Application.Contracts.Interfaces;
using Application.Features.Reservation.Query;
using Application.Services;
using MediatR;

namespace Application.Features.Reservation.Handler
{
    public class GetReservationsByMemberHandler : IRequestHandler<GetReservationsByMemberQuery, ServiceResponse<IEnumerable<Domain.Entities.Reservation>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetReservationsByMemberHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResponse<IEnumerable<Domain.Entities.Reservation>>> Handle(GetReservationsByMemberQuery request, CancellationToken cancellationToken)
        {
            var reservations = await _unitOfWork.Reserv.GetReservationsByMemberAsync(request.MemberId, cancellationToken);

            return new ServiceResponse<IEnumerable<Domain.Entities.Reservation>>
            {
                Data = reservations,
                Success = true,
                Message = "Reservations fetched successfully"
            };
        }
    }
}
