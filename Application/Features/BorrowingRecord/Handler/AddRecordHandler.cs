using Application.Contracts.Interfaces;
using Application.Features.BorrowingRecord.Command;
using Application.Services;
using MediatR;
using Domain.Entities;

namespace Application.Features.BorrowingRecord.Handler
{
    public class AddRecordHandler : IRequestHandler<AddRecordCommand, ServiceResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddRecordHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResponse<int>> Handle(AddRecordCommand request, CancellationToken cancellationToken)
        {
            var record = new BorrowingRecords  // ✅ Entity name matches Domain
            {
                BookId = request.BorrowRecordDto.BookId,    // ✅ DTO name as you specified
                MemberId = request.BorrowRecordDto.MemberId,
                BorrowDate = request.BorrowRecordDto.BorrowDate,
                ReturnDate = request.BorrowRecordDto.ReturnDate
            };

            await _unitOfWork.Borrow.AddAsync(record, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new ServiceResponse<int>
            {
                Data = record.Id,
                Message = "Borrowing record added successfully!"
            };
        }
    }
}
