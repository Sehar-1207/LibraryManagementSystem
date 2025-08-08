using Application.Services;
using MediatR;

namespace Application.Features.Categories.Command
{
    public class CreateCategoryCommand : IRequest<ServiceResponse<int>>
    {
        public string Name { get; set; } 
    }
}
