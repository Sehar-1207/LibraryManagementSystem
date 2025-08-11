using Application.Contracts.Interfaces;
using Application.Features.Reservation.Command;
using Application.Services;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

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
            // Validate book exists
            var book = await _unitOfWork.Books.GetByIdAsync(request.BookId, cancellationToken);
            if (book == null)
            {
                return new ServiceResponse<int>(0, false, "Book not found");
            }

            // Validate availability
            if (book.AvailableCopies <= 0)
            {
                return new ServiceResponse<int>(0, false, "Book not available");
            }

            // Create reservation entity
            var reservation = new Domain.Entities.Reservation
            {
                BookId = request.BookId,
                MemberId = request.MemberId,
                ReservationDate = DateTime.UtcNow,
                ExpiryDate = request.ExpirationDate.AddDays(7),
                IsNotified = request.IsNotified, // Default to
                IsCompleted = request.IsCompleted                                 // 
                // Default expiry
            };

            await _unitOfWork.Reserv.AddAsync(reservation, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new ServiceResponse<int>(reservation.Id, true, "Reservation added successfully");
        }
    }
}
