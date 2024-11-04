//using FluentResults;
//using I3Lab.Treatments.Domain.Members;
//using I3Lab.Treatments.Domain.Treatments;
//using MediatR;

//namespace I3Lab.Treatments.Application.Treatments.CreateTreatmentStage
//{
//    public class CreateTreatmentStageCommandHandler(
//        IMemberRepository memberRepository,
//        ITreatmentRepository tretmentRepository) : IRequestHandler<CreateTreatmentStageCommand, Result<TreatmentStageDto>>
//    {
//        public async Task<Result<TreatmentStageDto>> Handle(CreateTreatmentStageCommand request, CancellationToken cancellationToken)
//        {

//            var creator = await memberRepository.GetAsync(new SenderId(request.CreatorId));
//            if (creator == null)
//                return;

//            var treatment = Treatment.Create();

//            throw new NotImplementedException();
//        }
//    }
//}
  