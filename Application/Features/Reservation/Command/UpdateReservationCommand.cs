using Application.Services;
using MediatR;

namespace Application.Features.Reservation.Command
{
    public class UpdateReservationCommand : IRequest<ServiceResponse<int>>
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int MemberId { get; set; }
        public DateTime ReservedDate { get; set; }
        public DateTime? DueDate { get; set; }
    }
}

