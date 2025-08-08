using Application.Services;
using MediatR;

namespace Application.Features.Book.Commands
{
    public class DeleteBookCommand : IRequest<ServiceResponse<bool>>
    {
        public int Id { get; set; }

        public DeleteBookCommand(int id)
        {
            Id = id;
        }
    }
}


