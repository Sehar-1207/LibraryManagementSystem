using Application.Dtos;
using Application.Services;
using MediatR;

namespace Application.Features.Members.Commands
{
    public class CreateMemberCommand : IRequest<ServiceResponse<int>>
    {
        public MemberDto MemberDto { get; set; }
    }
}


