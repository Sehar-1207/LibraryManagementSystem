using Application.Contracts.Interfaces;
using Application.Dtos.Books;
using Application.Features.Reservation.Query;
using Application.Services;
using MediatR;

namespace Application.Features.Reservation.Handlers
{
    public class GetReservationByIdQueryHandler
        : IRequestHandler<GetReservationByIdQuery, ServiceResponse<ReservationDto>>
    {
        private readonly IUnitOfWork _uow;

        public GetReservationByIdQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<ServiceResponse<ReservationDto>> Handle(
            GetReservationByIdQuery request,
            CancellationToken cancellationToken)
        {
            var reservation = await _uow.Reserv.GetByIdAsync(request.Id);

            if (reservation == null)
                return new ServiceResponse<ReservationDto>(null, false, "Reservation not found");

            var dto = new ReservationDto
            {
                Id = reservation.Id,
                BookId = reservation.BookId,
                MemberId = reservation.MemberId,
                ReservationDate = reservation.ReservationDate,
                ExpiryDate = reservation.ExpiryDate,
                IsNotified = reservation.IsNotified,
                IsCompleted = reservation.IsCompleted
            };

            return new ServiceResponse<ReservationDto>(dto, true, "Success");
        }
    }
}
