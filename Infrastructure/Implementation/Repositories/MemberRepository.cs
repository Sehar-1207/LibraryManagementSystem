using Application.Contracts.Interfaces;
using Domain.Entities;
using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementation.Repositories
{
    public class MemberRepository : IMember
    {
        private readonly ApplicationDbContext _db;

        public MemberRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(Member member, CancellationToken cancellationToken)
        {
            await _db.Members.AddAsync(member, cancellationToken);
        }

        public Task UpdateAsync(Member member, CancellationToken cancellationToken)
        {
            _db.Members.Update(member);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Member member, CancellationToken cancellationToken)
        {
            _db.Members.Remove(member);
            return Task.CompletedTask;
        }

        public async Task<List<Member>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _db.Members.ToListAsync(cancellationToken);
        }

        public async Task<Member?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _db.Members.FirstOrDefaultAsync(m => m.Id == id, cancellationToken);
        }
    }
}
