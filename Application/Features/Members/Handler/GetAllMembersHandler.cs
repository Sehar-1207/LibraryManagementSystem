using Application.Contracts.Interfaces;
using Application.Dtos;
using Application.Features.Members.Query;
using Application.Services;
using MediatR;

public class GetAllMembersHandler : IRequestHandler<GetAllMembersQuery, ServiceResponse<List<MemberDto>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllMembersHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ServiceResponse<List<MemberDto>>> Handle(GetAllMembersQuery request, CancellationToken cancellationToken)
    {
        var members = await _unitOfWork.Member.GetAllAsync(cancellationToken);

        var memberDtos = members.Select(m => new MemberDto
        {
            Id = m.Id,
            FullName = m.FullName,
            Email = m.Email,
            JoinDate = m.JoinDate
        }).ToList();

        return new ServiceResponse<List<MemberDto>>
        {
            Data = memberDtos,
            Message = "Success",
            Success = true
        };
    }
}
