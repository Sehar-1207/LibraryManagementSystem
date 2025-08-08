using Application.Contracts.Interfaces;
using Application.Features.Book.Commands;
using Application.Services;
using MediatR;

namespace Application.Features.Book.Handlers
{
    public class DeleteBookHandler : IRequestHandler<DeleteBookCommand, ServiceResponse<bool>>
    {
        private readonly IUnitOfWork _uow;

        public DeleteBookHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<ServiceResponse<bool>> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            await _uow.Books.DeleteAsync(request.Id, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);

            return new ServiceResponse<bool> { Data = true, Message = "Book deleted successfully" };
        }
    }
}
