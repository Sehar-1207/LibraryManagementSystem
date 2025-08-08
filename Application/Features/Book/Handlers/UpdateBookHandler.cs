using Application.Contracts.Interfaces;
using Application.Features.Book.Commands;
using Application.Services;
using MediatR;

namespace Application.Features.Book.Handlers
{
    public class UpdateBookHandler : IRequestHandler<UpdateBookCommand, ServiceResponse<int>>
    {
        private readonly IUnitOfWork _uow;

        public UpdateBookHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<ServiceResponse<int>> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var existingBook = await _uow.Books.GetByIdAsync(request.BookDto.Id, cancellationToken);
            if (existingBook == null)
            {
                return new ServiceResponse<int>
                {
                    Success = false,
                    Message = "Book not found."
                };
            }

            existingBook.Title = request.BookDto.Title;
            existingBook.Author = request.BookDto.Author;
            existingBook.Genre = request.BookDto.Genre;
            existingBook.ISBN = request.BookDto.ISBN;
            existingBook.TotalCopies = request.BookDto.TotalCopies;
            existingBook.AvailableCopies = request.BookDto.AvailableCopies;
            existingBook.CategoryId = request.BookDto.CategoryId;

            await _uow.Books.UpdateAsync(existingBook, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);

            return new ServiceResponse<int>
            {
                Data = existingBook.Id,
                Message = "Book updated successfully!"
            };
        }
    }
}
