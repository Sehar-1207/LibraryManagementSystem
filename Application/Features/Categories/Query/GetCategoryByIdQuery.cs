using Application.Dtos.Books;
using MediatR;

public class GetCategoryByIdQuery : IRequest<CategoryDto?>
{
    public int Id { get; set; }
    public GetCategoryByIdQuery(int id)
    {
        Id = id;
    }
}