using Application.Contracts.Interfaces;
using Application.Services;
using MediatR;

namespace Application.Features.Category.Handlers
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, ServiceResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCategoryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResponse<int>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.Category.DeleteAsync(request.Id, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new ServiceResponse<int>
            {
                Data = request.Id,
                Success = true,
                Message = "Category deleted successfully"
            };
        }
    }
}
