using Application.Dtos.Books;
using Application.Services;
using MediatR;

namespace Application.Features.BorrowingRecord.Query
{
    public class GetAllRecordsQuery : IRequest<ServiceResponse<List<BorrowRecordDto>>>
    {
    }
}
