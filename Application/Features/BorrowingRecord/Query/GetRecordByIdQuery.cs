using Application.Dtos.Books;
using Application.Services;
using MediatR;

public class GetRecordByIdQuery : IRequest<ServiceResponse<BorrowRecordDto>>
{
    public int Id { get; set; }

    public GetRecordByIdQuery(int id)
    {
        Id = id;
    }
}