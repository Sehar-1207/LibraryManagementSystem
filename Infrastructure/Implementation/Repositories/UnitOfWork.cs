using Application.Contracts.Interfaces;
using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementation.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public IBook Books { get; }
        public ICategory Category { get; }
        public IMember Member { get; }
        public IBorrow Borrow { get; }
        public IReservation Reserv { get; }
        public UnitOfWork(ApplicationDbContext db, IBook books, ICategory category, IMember member, IBorrow borrow, IReservation reservation)
        {
            _db = db;
            Books = books;
            Category = category;
            Member = member;
            Borrow = borrow;
            Reserv = reservation;
        }
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _db.SaveChangesAsync(cancellationToken);
        }
        public void Dispose()
        {
            _db.Dispose();
        }
    }
}

