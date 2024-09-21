using FluentResults;
using I3Lab.Treatments.Domain.BlobFiles;
using I3Lab.Treatments.Domain.TreatmentStages;
using MediatR;

namespace I3Lab.Treatments.Application.BlobFiles.GetBlobFilesByWorkId
{
    public class GetAllBlobFilesByWorkIdCommandHandler(
        IBlobFileRepository blobFileRepository) : IRequestHandler<GetAllBlobFilesByWorkIdCommand, Result<List<BlobFileDto>>>
    {
        public async Task<Result<List<BlobFileDto>>> Handle(GetAllBlobFilesByWorkIdCommand request, CancellationToken cancellationToken)
        {
            var files = await blobFileRepository.GetAllByTreatmentStageIdAsync(new TreatmentStageId(request.WorkId));

            if (files is null || !files.Any())
                return new List<BlobFileDto>();
            
            var sortedFiles = files
                .OrderBy(file => file.FileType.Value)
                .GroupBy(file => file.FileType.Value)
                .Select(group => new BlobFileDto
                {
                    FileType = group.Key,
                    Files = group.OrderBy(f => f.CreateDate).ToList()
                }).ToList();

            return sortedFiles;
        }
    }

    public class BlobFileDto
    {
        public string FileType { get; set; }
        public List<BlobFile> Files { get; set; }
    }
}

