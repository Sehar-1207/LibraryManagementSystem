using Application.Dtos;
using Application.Services;
using MediatR;

namespace Application.Features.Members.Query
{
    public class GetAllMembersQuery : IRequest<ServiceResponse<List<MemberDto>>>
    {
    }
}


