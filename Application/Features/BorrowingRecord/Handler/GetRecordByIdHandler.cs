using Application.Contracts.Interfaces;
using Application.Dtos.Books;
using Application.Services;
using MediatR;

namespace Application.Features.BorrowingRecord.Handler
{
    public class GetRecordByIdHandler : IRequestHandler<GetRecordByIdQuery, ServiceResponse<BorrowRecordDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetRecordByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResponse<BorrowRecordDto>> Handle(GetRecordByIdQuery request, CancellationToken cancellationToken)
        {
            var record = await _unitOfWork.Borrow.GetByIdAsync(request.Id, cancellationToken);

            if (record == null)
            {
                return new ServiceResponse<BorrowRecordDto> { Success = false, Message = "Record not found" };
            }

            var dto = new BorrowRecordDto
            {
                Id = record.Id,
                BookId = record.BookId,
                MemberId = record.MemberId,
                BorrowDate = record.BorrowDate,
                ReturnDate = record.ReturnDate
            };

            return new ServiceResponse<BorrowRecordDto>
            {
                Data = dto,
                Message = "Borrowing record retrieved successfully!"
            };
        }
    }
}
