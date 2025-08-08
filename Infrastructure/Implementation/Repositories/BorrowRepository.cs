using Application.Contracts.Interfaces;
using Domain.Entities;
using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementation.Repositories
{
    public class BorrowRepository : IBorrow
    {
        private readonly ApplicationDbContext _context;

        public BorrowRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<BorrowingRecords> AddAsync(BorrowingRecords record, CancellationToken cancellationToken)
        {
            await _context.BorrowRecords.AddAsync(record, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return record;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var record = await _context.BorrowRecords.FindAsync(new object[] { id }, cancellationToken);
            if (record == null)
                return false;

            _context.BorrowRecords.Remove(record);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<List<BorrowingRecords>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.BorrowRecords
                .Include(br => br.Book)   // include Book navigation
                .Include(br => br.Member) // include Member navigation
                .ToListAsync(cancellationToken);
        }

        public async Task<BorrowingRecords?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.BorrowRecords
                .Include(br => br.Book)
                .Include(br => br.Member)
                .FirstOrDefaultAsync(br => br.Id == id, cancellationToken);
        }

        public async Task<BorrowingRecords> UpdateAsync(BorrowingRecords record, CancellationToken cancellationToken)
        {
            _context.BorrowRecords.Update(record);
            await _context.SaveChangesAsync(cancellationToken);
            return record;
        }
    }
}
