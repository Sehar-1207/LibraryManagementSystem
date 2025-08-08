using Application.Contracts.Interfaces;
using Application.Dtos;
using Application.Features.Members.Queries;
using Application.Services;
using MediatR;

public class GetMemberByIdHandler : IRequestHandler<GetMemberByIdQuery, ServiceResponse<MemberDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetMemberByIdHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ServiceResponse<MemberDto>> Handle(GetMemberByIdQuery request, CancellationToken cancellationToken)
    {
        var member = await _unitOfWork.Member.GetByIdAsync(request.Id, cancellationToken);

        if (member == null)
        {
            return new ServiceResponse<MemberDto>
            {
                Data = null,
                Message = "Member not found",
                Success = false
            };
        }

        var dto = new MemberDto
        {
            Id = member.Id,
            FullName = member.FullName,
            Email = member.Email,
            JoinDate = member.JoinDate
        };

        return new ServiceResponse<MemberDto>
        {
            Data = dto,
            Message = "Member fetched successfully",
            Success = true
        };
    }

}
