using Application.Contracts.Interfaces;
using Domain.Entities;
using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementation.Repositories
{
    public class ReservationRepository : GenericRepository<Reservation>, IReservation
    {
        private readonly ApplicationDbContext _context;

        public ReservationRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Reservation>> GetReservationsByBookAsync(int bookId, CancellationToken cancellationToken)
        {
            return await _context.Reservations
                .Where(r => r.BookId == bookId && !r.IsCompleted)
                .OrderBy(r => r.ReservationDate)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Reservation>> GetReservationsByMemberAsync(int memberId, CancellationToken cancellationToken)
        {
            return await _context.Reservations
                .Where(r => r.MemberId == memberId)
                .ToListAsync(cancellationToken);
        }

        public async Task<Reservation> GetNextReservationAsync(int bookId, CancellationToken cancellationToken)
        {
            return await _context.Reservations
                .Where(r => r.BookId == bookId && !r.IsCompleted)
                .OrderBy(r => r.ReservationDate)
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
