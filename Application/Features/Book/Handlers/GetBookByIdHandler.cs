using Application.Contracts.Interfaces;
using Application.Dtos.Books;
using Application.Features.Book.Queries;
using MediatR;

namespace Application.Features.Book.Handlers
{
    public class GetBookByIdHandler : IRequestHandler<GetBookByIdQuery, BookDto?>
    {
        private readonly IUnitOfWork _uow;

        public GetBookByIdHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<BookDto?> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _uow.Books.GetByIdAsync(request.Id, cancellationToken);
            if (book == null) return null;

            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Genre = book.Genre,
                ISBN = book.ISBN,
                TotalCopies = book.TotalCopies,
                AvailableCopies = book.AvailableCopies
            };
        }
    }
}
