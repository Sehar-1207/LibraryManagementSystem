using Application.Services;
using MediatR;

public class UpdateCategoryCommand : IRequest<ServiceResponse<int>>
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
