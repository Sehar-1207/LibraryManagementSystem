using Domain.Entities;

namespace Application.Contracts.Interfaces
{
    public interface IMember
    {
        Task AddAsync(Member member, CancellationToken cancellationToken);
        Task UpdateAsync(Member member, CancellationToken cancellationToken);
        Task DeleteAsync(Member member, CancellationToken cancellationToken);
        Task<List<Member>> GetAllAsync(CancellationToken cancellationToken);
        Task<Member?> GetByIdAsync(int id, CancellationToken cancellationToken);
    }
}

