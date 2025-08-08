using Application.Dtos.Books;
using Application.Services;
using MediatR;

namespace Application.Features.Book.Commands
{
    public class AddBookCommand : IRequest<ServiceResponse<int>>
    {
        public BookDto BookDto { get; set; }

        public AddBookCommand(BookDto bookDto)
        {
            BookDto = bookDto;
        }
    }
}




