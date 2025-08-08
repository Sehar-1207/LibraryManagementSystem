using Application.Dtos.Books;
using Application.Services;
using MediatR;

namespace Application.Features.Book.Commands
{
    public class UpdateBookCommand : IRequest<ServiceResponse<int>>
    {
        public BookDto BookDto { get; set; }

        public UpdateBookCommand(BookDto bookDto)
        {
            BookDto = bookDto;
        }
    }
}




