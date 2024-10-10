using FluentResults;
using I3Lab.BuildingBlocks.Application.BlobStorage;
using I3Lab.Treatments.Domain.TreatmentFiles;
using MediatR;

namespace I3Lab.Treatments.Application.TreatmentFiles.GetTreatmentFile
{
    public class GetTreatmentFileStreamQuerieHandler(
        ITreatmentFileRepository blobFileRepository,
        IBlobService blobService) : IRequestHandler<GetTreatmentFileStreamQuerie, Result<TreatmentFileDto>>
    {
        public async Task<Result<TreatmentFileDto>> Handle(GetTreatmentFileStreamQuerie request, CancellationToken cancellationToken)
        {
            var blobFile = await blobFileRepository.GetByIdAsync(new TreatmentFileId(request.TreatmentFileId));

            if (blobFile is null)
                return Result.Fail("File not found");

            var fileResponce = await blobService.DownloadAsync(new Guid(blobFile.BlobFilePath.FileName));

            return new TreatmentFileDto(fileResponce.Stream, fileResponce.ContentType);
        }
    }
}
