using Domain.Entities;

namespace Application.Contracts.Interfaces
{
    public interface IBorrow
    {
        Task<List<BorrowingRecords>> GetAllAsync(CancellationToken cancellationToken);
        Task<BorrowingRecords?> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<BorrowingRecords> AddAsync(BorrowingRecords record, CancellationToken cancellationToken);
        Task<BorrowingRecords> UpdateAsync(BorrowingRecords record, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
    }
}

