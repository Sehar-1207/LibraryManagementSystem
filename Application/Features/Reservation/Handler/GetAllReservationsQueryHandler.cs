using Application.Contracts.Interfaces;
using Application.Dtos.Books;
using Application.Features.Reservation.Query;
using Application.Services;
using MediatR;

namespace Application.Features.Reservation.Handlers
{
    public class GetAllReservationsQueryHandler: IRequestHandler<GetAllReservationsQuery, ServiceResponse<List<ReservationDto>>>
    {
        private readonly IUnitOfWork _uow;

        public GetAllReservationsQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<ServiceResponse<List<ReservationDto>>> Handle(GetAllReservationsQuery request, CancellationToken cancellationToken)
        {
            var reservations = await _uow.Reserv.GetAllAsync(cancellationToken);

            var reservationDtos = reservations.Select(r => new ReservationDto
            {
                Id = r.Id,
                BookId = r.BookId,
                MemberId = r.MemberId,
                ReservationDate = r.ReservationDate,
                ExpiryDate = r.ExpiryDate,
                IsNotified = r.IsNotified,
                IsCompleted = r.IsCompleted
            }).ToList();

            return new ServiceResponse<List<ReservationDto>>
            {
                Data = reservationDtos,
                Message = "Reservations fetched successfully",
                Success = true
            };
        }
    }
}
