using Application.Dtos.Books;
using Application.Services;
using MediatR;

namespace Application.Features.BorrowingRecord.Command
{
    public class UpdateRecordCommand : IRequest<ServiceResponse<int>>
    {
        public BorrowRecordDto BorrowingRecordDto { get; set; }

        public UpdateRecordCommand(BorrowRecordDto dto)
        {
            BorrowingRecordDto = dto;
        }
    }
}
