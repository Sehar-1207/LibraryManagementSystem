using Application.Contracts.Interfaces;
using Application.Dtos.Books;
using Application.Features.Categories.Query;
using AutoMapper;
using MediatR;

namespace Application.Features.Category.Handlers
{
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, List<CategoryDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCategoriesHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<CategoryDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            // Fetch domain entities
            var categories = await _unitOfWork.Category.GetAllAsync(cancellationToken);

            // Map to DTOs using AutoMapper
            return _mapper.Map<List<CategoryDto>>(categories);
        }
    }
}
