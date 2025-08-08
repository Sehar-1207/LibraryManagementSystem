using Application.Services;
using MediatR;

public class DeleteCategoryCommand : IRequest<ServiceResponse<int>>
{
    public int Id { get; set; }
    public DeleteCategoryCommand(int id)
    {
        Id = id;
    }
}
