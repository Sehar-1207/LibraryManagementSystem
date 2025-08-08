using Application.Contracts.Interfaces;

namespace Application.Contracts.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBook Books { get; }
        ICategory Category { get; }
        IMember Member { get; }
        IBorrow Borrow { get; }
        IReservation Reserv { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }

}



