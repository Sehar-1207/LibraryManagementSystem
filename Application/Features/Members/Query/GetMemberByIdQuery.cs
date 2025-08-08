using Application.Dtos;
using Application.Services;
using MediatR;

namespace Application.Features.Members.Queries
{
    public class GetMemberByIdQuery : IRequest<ServiceResponse<MemberDto>>
    {
        public int Id { get; set; }

        public GetMemberByIdQuery(int id)
        {
            Id = id;
        }
    }
}
