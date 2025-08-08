using Application.Contracts.Interfaces;
using Application.Features.BorrowingRecord.Command;
using Application.Services;
using MediatR;

namespace Application.Features.BorrowingRecord.Handler
{
    public class DeleteRecordHandler : IRequestHandler<DeleteRecordCommand, ServiceResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteRecordHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResponse<bool>> Handle(DeleteRecordCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Borrow.DeleteAsync(request.Id, cancellationToken);

            if (!result)
            {
                return new ServiceResponse<bool> { Success = false, Message = "Record not found" };
            }

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new ServiceResponse<bool>
            {
                Data = true,
                Message = "Borrowing record deleted successfully!"
            };
        }
    }
}
