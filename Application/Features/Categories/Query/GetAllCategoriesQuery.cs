using Application.Dtos.Books;
using MediatR;

namespace Application.Features.Categories.Query
{
    public class GetAllCategoriesQuery : IRequest<List<CategoryDto>> { }
}
