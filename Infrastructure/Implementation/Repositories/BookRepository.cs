using Application.Contracts.Interfaces;
using Domain.Entities;
using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Implementation.Repositories
{
    public class BookRepository : IBook
    {
        private readonly ApplicationDbContext _db;

        public BookRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<Book>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _db.Books.ToListAsync(cancellationToken);
        }

        public async Task<Book?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _db.Books.FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task AddAsync(Book book, CancellationToken cancellationToken)
        {
            await _db.Books.AddAsync(book, cancellationToken);
        }

        public async Task UpdateAsync(Book book, CancellationToken cancellationToken)
        {
            _db.Books.Update(book);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var book = await _db.Books.FindAsync(new object[] { id }, cancellationToken);
            if (book != null)
                _db.Books.Remove(book);
        }
    }
}

