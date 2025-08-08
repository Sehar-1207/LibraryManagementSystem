using Application.Dtos;
using Application.Dtos.Books;
using Application.Services;
using MediatR;

namespace Application.Features.BorrowingRecord.Command
{
    public class AddRecordCommand : IRequest<ServiceResponse<int>>
    {
        public BorrowRecordDto BorrowRecordDto { get; set; }

        public AddRecordCommand(BorrowRecordDto dto)
        {
            BorrowRecordDto = dto;
        }
    }
}
