using FluentResults;
using I3Lab.Treatments.Domain.TreatmentStages;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Application.Works.AddTreatmentStageFile
{
    public class AddTreatmentStageFileCommandHandler : IRequestHandler<AddTreatmentStageFileCommand, Result<TreatmentStageFileDto>>
    {
        private ITreatmentStageRepository _workRepository;

        public AddTreatmentStageFileCommandHandler(ITreatmentStageRepository workRepository)
        {
            _workRepository = workRepository;
        }

        public async Task<Result<TreatmentStageFileDto>> Handle(AddTreatmentStageFileCommand request, CancellationToken cancellationToken)
        {
            var work = await _workRepository.GetByIdAsync(new TreatmentStageId(request.WorkId));

            if (work == null)
                return Result.Fail("TreatmentStage not found");

            //var newWork = await TreatmentStage.CreateNewWork();
            throw new NotImplementedException();
        }
    }
}
