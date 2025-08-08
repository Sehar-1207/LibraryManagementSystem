using Application.Dtos;
using Application.Services;
using MediatR;

namespace Application.Features.Members.Commands
{
    public class UpdateMemberCommand : IRequest<ServiceResponse<int>>
    {
        public MemberDto MemberDto { get; set; }
    }
}
