using Application.Contracts.Interfaces;
using Application.Features.Categories.Command;
using Application.Services;
using Domain.Entities;
using MediatR;

namespace Application.Features.Category.Handlers
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, ServiceResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCategoryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResponse<int>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Domain.Entities.Category
            {
                Name = request.Name
            };

            await _unitOfWork.Category.AddAsync(category, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new ServiceResponse<int>
            {
                Data = category.Id,
                Success = true,
                Message = "Category created successfully"
            };
        }
    }
}
