using FluentResults;
using MediatR;

namespace I3Lab.Clinics.Application.Clnics.CreateClnic
{
    public class CreateClnicCommandHandler : IRequestHandler<CreateClnicCommand, Result<ClnicDto>>
    {
        public Task<Result<ClnicDto>> Handle(CreateClnicCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
