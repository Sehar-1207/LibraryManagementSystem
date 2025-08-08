using Application.Contracts.Interfaces;
using Application.Features.Members.Commands;
using Application.Services;
using MediatR;

namespace Application.Features.Members.Handlers
{
    public class UpdateMemberHandler : IRequestHandler<UpdateMemberCommand, ServiceResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateMemberHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResponse<int>> Handle(UpdateMemberCommand request, CancellationToken cancellationToken)
        {
            var member = await _unitOfWork.Member.GetByIdAsync(request.MemberDto.Id, cancellationToken);
            if (member == null)
            {
                return new ServiceResponse<int>
                {
                    Data = 0,
                    Message = "Member not found",
                    Success = false
                };
            }

            member.FullName = request.MemberDto.FullName;
            member.Email = request.MemberDto.Email;
            member.JoinDate = request.MemberDto.JoinDate;

            await _unitOfWork.Member.UpdateAsync(member, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new ServiceResponse<int>
            {
                Data = member.Id,
                Message = "Member updated successfully",
                Success = true
            };
        }
    }
}
