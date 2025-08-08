using Application.Contracts.Interfaces;
using Application.Features.Members.Commands;
using Application.Services;
using Domain.Entities;
using MediatR;

namespace Application.Features.Members.Handler
{
    public class AddMemberHandler : IRequestHandler<CreateMemberCommand, ServiceResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddMemberHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResponse<int>> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
        {
            var member = new Member
            {
                FullName = request.MemberDto.FullName,
                Email = request.MemberDto.Email,
                JoinDate = request.MemberDto.JoinDate
            };

            await _unitOfWork.Member.AddAsync(member, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken); // capture result

            if (result <= 0)
            {
                return new ServiceResponse<int>
                {
                    Data = 0,
                    Message = "Failed to add member",
                    Success = false
                };
            }

            return new ServiceResponse<int>
            {
                Data = member.Id,
                Message = "Member added !!!",
                Success = true
            };
        }

    }
}


