using Application.Dtos.Books;
using Application.Services;
using Domain.Entities;

namespace Application.Contracts.Interfaces
{
    public interface ICategory
    {
        Task<List<Category>> GetAllAsync(CancellationToken cancellationToken);
        Task<Category?> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task AddAsync(Category category, CancellationToken cancellationToken);
        Task UpdateAsync(Category category, CancellationToken cancellationToken);
        Task DeleteAsync(int id, CancellationToken cancellationToken);
    }


}
