﻿using Domain.Entities;

namespace Application.Contracts.Interfaces
{
    public interface IBook
    {
        Task<List<Book>> GetAllAsync(CancellationToken cancellationToken);
        Task<Book?> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task AddAsync(Book book, CancellationToken cancellationToken);
        Task UpdateAsync(Book book, CancellationToken cancellationToken);
        Task DeleteAsync(int id, CancellationToken cancellationToken);
    }

}

