using MediatR;
using FluentResults;
using I3Lab.Treatments.Domain.TreatmentFiles;
using I3Lab.Treatments.Domain.TreatmentStages;

namespace I3Lab.Treatments.Application.TreatmentFiles.GetTreatmentFilesByTreatmentStageId
{
    public class GetAllTreatmentFilesByTreatmentStageIdCommandHandler(
        ITreatmentFileRepository blobFileRepository) : IRequestHandler<GetAllTreatmentFilesByTreatmentStageIdCommand, Result<List<TreatmentFileDto>>>
    {
        public async Task<Result<List<TreatmentFileDto>>> Handle(GetAllTreatmentFilesByTreatmentStageIdCommand request, CancellationToken cancellationToken)
        {
            var files = await blobFileRepository.GetAllByTreatmentStageIdAsync(new TreatmentStageId(request.WorkId));

            if (files is null || !files.Any())
                return new List<TreatmentFileDto>();
            
            var sortedFiles = files
                .OrderBy(file => file.FileType.Value)
                .GroupBy(file => file.FileType.Value)
                .Select(group => new TreatmentFileDto
                {
                    FileType = group.Key,
                    Files = group.OrderBy(f => f.CreateDate).ToList()
                }).ToList();

            return sortedFiles;
        }
    }
}

