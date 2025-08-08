using Application.Services;
using MediatR;

namespace Application.Features.BorrowingRecord.Command
{
    public class DeleteRecordCommand : IRequest<ServiceResponse<bool>>
    {
        public int Id { get; set; }

        public DeleteRecordCommand(int id)
        {
            Id = id;
        }
    }
}
