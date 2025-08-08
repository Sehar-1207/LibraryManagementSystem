using Application.Dtos.Books;
using MediatR;

namespace Application.Features.Book.Queries
{
    public class GetBookByIdQuery : IRequest<BookDto?>
    {
        public int Id { get; set; }

        public GetBookByIdQuery(int id)
        {
            Id = id;
        }
    }
}






