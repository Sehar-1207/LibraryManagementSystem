using Application.Services;
using MediatR;

namespace Application.Features.Members.Commands
{
    public class DeleteMemberCommand : IRequest<ServiceResponse<int>>
    {
        public int Id { get; set; }
    }
}

