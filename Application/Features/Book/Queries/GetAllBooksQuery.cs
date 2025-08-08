using Application.Dtos.Books;
using MediatR;

namespace Application.Features.Book.Queries
{
    public class GetAllBooksQuery : IRequest<List<BookDto>> { }

}
