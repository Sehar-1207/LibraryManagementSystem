using Application.Contracts.Interfaces;
using Application.Features.Book.Commands;
using Application.Services;
using MediatR;

namespace Application.Features.Book.Handlers
{
    public class AddBookHandler : IRequestHandler<AddBookCommand, ServiceResponse<int>>
    {
        private readonly IUnitOfWork _uow;

        public AddBookHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<ServiceResponse<int>> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Domain.Entities.Book
            {
                Title = request.BookDto.Title,
                Author = request.BookDto.Author,
                Genre = request.BookDto.Genre,
                ISBN = request.BookDto.ISBN,
                TotalCopies = request.BookDto.TotalCopies,
                AvailableCopies = request.BookDto.AvailableCopies,
                CategoryId = request.BookDto.CategoryId,
                CategoryName = request.BookDto.CategoryName
            };

            await _uow.Books.AddAsync(book, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);

            return new ServiceResponse<int>
            {
                Data = book.Id,
                Message = "Book added successfully!"
            };
        }
    }
}
