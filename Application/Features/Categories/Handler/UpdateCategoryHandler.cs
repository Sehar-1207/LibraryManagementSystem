using Application.Contracts.Interfaces;
using Application.Services;
using Domain.Entities;
using MediatR;

namespace Application.Features.Category.Handlers
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, ServiceResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCategoryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResponse<int>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Domain.Entities.Category
            {
                Id = request.Id,
                Name = request.Name
            };

            await _unitOfWork.Category.UpdateAsync(category, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new ServiceResponse<int>
            {
                Data = category.Id,
                Success = true,
                Message = "Category updated successfully"
            };
        }
    }
}
