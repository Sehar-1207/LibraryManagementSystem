using Application.Contracts.Interfaces;
using Application.Features.Members.Commands;
using Application.Services;
using MediatR;

namespace Application.Features.Members.Handlers
{
    public class DeleteMemberHandler : IRequestHandler<DeleteMemberCommand, ServiceResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteMemberHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResponse<int>> Handle(DeleteMemberCommand request, CancellationToken cancellationToken)
        {
            var member = await _unitOfWork.Member.GetByIdAsync(request.Id, cancellationToken);
            if (member == null)
            {
                return new ServiceResponse<int>
                {
                    Data = 0,
                    Message = "Member not found",
                    Success = false
                };
            }

            await _unitOfWork.Member.DeleteAsync(member, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new ServiceResponse<int>
            {
                Data = request.Id,
                Message = "Member deleted successfully",
                Success = true
            };
        }
    }
}
