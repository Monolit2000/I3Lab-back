using FluentResults;
using I3Lab.Works.Domain.Members;
using I3Lab.Works.Domain.Treatments;
using MediatR;

namespace I3Lab.Works.Application.Treatments.CreateTreatmentStage
{
    public class CreateTreatmentStageCommandHandler(
        ITretmentRepository tretmentRepository,
        IMemberRepository memberRepository) : IRequestHandler<CreateTreatmentStageCommand, Result<TreatmentStageDto>>
    {
        public Task<Result<TreatmentStageDto>> Handle(CreateTreatmentStageCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
 