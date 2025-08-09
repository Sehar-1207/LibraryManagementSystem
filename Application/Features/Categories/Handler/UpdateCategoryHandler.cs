using Application.Contracts.Interfaces;
using Application.Services;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

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
            // Optionally: fetch existing entity first to validate existence or update selectively
            // var existingCategory = await _unitOfWork.Category.GetByIdAsync(request.Id, cancellationToken);
            // if (existingCategory == null) { return new ServiceResponse<int> { Success = false, Message = "Category not found." }; }
            // existingCategory.Name = request.Name;
            // await _unitOfWork.Category.UpdateAsync(existingCategory, cancellationToken);

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
