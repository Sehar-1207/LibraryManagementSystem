using Application.Contracts.Interfaces;
using Application.Dtos.Books;
using Application.Features.BorrowingRecord.Query;
using Application.Services;
using MediatR;

namespace Application.Features.BorrowingRecord.Handler
{
    public class GetAllRecordsHandler : IRequestHandler<GetAllRecordsQuery, ServiceResponse<List<BorrowRecordDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllRecordsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResponse<List<BorrowRecordDto>>> Handle(GetAllRecordsQuery request, CancellationToken cancellationToken)
        {
            var records = await _unitOfWork.Borrow.GetAllAsync(cancellationToken);

            var recordDtos = records.Select(r => new BorrowRecordDto
            {
                Id = r.Id,
                BookId = r.BookId,
                MemberId = r.MemberId,
                BorrowDate = r.BorrowDate,
                ReturnDate = r.ReturnDate
            }).ToList();

            return new ServiceResponse<List<BorrowRecordDto>>
            {
                Data = recordDtos,
                Message = "Borrowing records retrieved successfully!"
            };
        }
    }
}
