using Application.Contracts.Interfaces;
using Application.Dtos.Books;
using Application.Features.Book.Queries;
using MediatR;

public class GetAllBooksHandler : IRequestHandler<GetAllBooksQuery, List<BookDto>>
{
    private readonly IUnitOfWork _uow;

    public GetAllBooksHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<List<BookDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        var books = await _uow.Books.GetAllAsync(cancellationToken);

        var bookDtos = books.Select(b => new BookDto
        {
            Id = b.Id,
            Title = b.Title,
            Author = b.Author,
            Genre = b.Genre,
            ISBN = b.ISBN,
            TotalCopies = b.TotalCopies,
            AvailableCopies = b.AvailableCopies,
            CategoryId = b.CategoryId,
            CategoryName = b.Category?.Name // ✅ This is the key
        }).ToList();

        return bookDtos; // ✅ Added return
    }
}
