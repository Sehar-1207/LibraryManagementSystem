using Application.Contracts.Interfaces;
using Application.Features.Reservation.Command;
using Application.Services;
using MediatR;

namespace Application.Features.Reservation.Handler
{
    public class AddReservationHandler : IRequestHandler<AddReservationCommand, ServiceResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddReservationHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResponse<int>> Handle(AddReservationCommand request, CancellationToken cancellationToken)
        {
            var book = await _unitOfWork.Books.GetByIdAsync(request.ReservationDto.BookId, cancellationToken);
            if (book == null)
            {
                return new ServiceResponse<int>
                {
                    Data = 0,
                    Success = false,
                    Message = "Book not found"
                };
            }

            if (book.AvailableCopies <= 0)
            {
                return new ServiceResponse<int>
                {
                    Data = 0,
                    Success = false,
                    Message = "Book not available"
                };
            }

            var reservation = new Domain.Entities.Reservation
            {
                BookId = request.ReservationDto.BookId,
                MemberId = request.ReservationDto.MemberId,
                ReservationDate = DateTime.UtcNow
            };

            await _unitOfWork.Reserv.AddAsync(reservation, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new ServiceResponse<int>
            {
                Data = reservation.Id,
                Success = true,
                Message = "Reservation added successfully"
            };
        }
    }
}
