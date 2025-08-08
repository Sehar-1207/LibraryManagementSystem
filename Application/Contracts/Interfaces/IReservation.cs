using Domain.Entities;

namespace Application.Contracts.Interfaces
{
    public interface IReservation : IGenericRepository<Reservation>
    {
        Task<IEnumerable<Reservation>> GetReservationsByBookAsync(int bookId, CancellationToken cancellationToken);
        Task<IEnumerable<Reservation>> GetReservationsByMemberAsync(int memberId, CancellationToken cancellationToken);
        Task<Reservation> GetNextReservationAsync(int bookId, CancellationToken cancellationToken);
    }
}
