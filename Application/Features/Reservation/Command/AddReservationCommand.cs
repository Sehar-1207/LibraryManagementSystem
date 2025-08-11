using Application.Dtos.Books;
using Application.Services;
using MediatR;

namespace Application.Features.Reservation.Command
{
    public class AddReservationCommand : IRequest<ServiceResponse<int>>
    {
        public int BookId { get; set; }
        public int MemberId { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}

