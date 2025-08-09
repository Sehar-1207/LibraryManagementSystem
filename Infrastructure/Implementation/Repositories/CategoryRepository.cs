using Application.Contracts.Interfaces;
using Domain.Entities;
using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementation.Repositories
{
    public class CategoryRepository : ICategory
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<Category>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _db.Categories
                            .Include(c => c.Books) // Include related books
                            .ToListAsync(cancellationToken);
        }

        public async Task<Category?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _db.Categories
                            .Include(c => c.Books) // Include related books
                            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
        }

        public async Task AddAsync(Category category, CancellationToken cancellationToken)
        {
            await _db.Categories.AddAsync(category, cancellationToken);
        }

        public Task UpdateAsync(Category category, CancellationToken cancellationToken)
        {
            // Update is synchronous, no await needed here
            _db.Categories.Update(category);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var category = await _db.Categories
                                    .Include(c => c.Books)
                                    .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
            if (category != null)
            {
                _db.Categories.Remove(category);
            }
        }
    }
}
