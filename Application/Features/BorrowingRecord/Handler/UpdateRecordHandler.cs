using Application.Contracts.Interfaces;
using Application.Features.BorrowingRecord.Command;
using Application.Services;
using MediatR;

namespace Application.Features.BorrowingRecord.Handler
{
    public class UpdateRecordHandler : IRequestHandler<UpdateRecordCommand, ServiceResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateRecordHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResponse<int>> Handle(UpdateRecordCommand request, CancellationToken cancellationToken)
        {
            var record = await _unitOfWork.Borrow.GetByIdAsync(request.BorrowingRecordDto.Id, cancellationToken);

            if (record == null)
            {
                return new ServiceResponse<int> { Success = false, Message = "Record not found" };
            }

            record.BookId = request.BorrowingRecordDto.BookId;
            record.MemberId = request.BorrowingRecordDto.MemberId;
            record.BorrowDate = request.BorrowingRecordDto.BorrowDate;
            record.ReturnDate = request.BorrowingRecordDto.ReturnDate;

            await _unitOfWork.Borrow.UpdateAsync(record, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new ServiceResponse<int>
            {
                Data = record.Id,
                Message = "Borrowing record updated successfully!"
            };
        }
    }
}
