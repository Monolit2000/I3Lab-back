using FluentResults;
using I3Lab.BuildingBlocks.Application.BlobStorage;
using I3Lab.Treatments.Domain.BlobFiles;
using I3Lab.Treatments.Domain.TreatmentStages;
using MediatR;

namespace I3Lab.Treatments.Application.BlobFiles.AddBlobFile
{
    public class CreateBlobFileCommandHandler(
        ITreatmentStageRepository workRepository,
        IBlobFileRepository blobFileRepository,
        IBlobService blobService) : IRequestHandler<CreateBlobFileCommand, Result<BlobFileDto>>
    {
        public async Task<Result<BlobFileDto>> Handle(CreateBlobFileCommand request, CancellationToken cancellationToken)
        {
            var treatmentStage = await workRepository.GetByIdAsync(new TreatmentStageId(request.WorkId), cancellationToken);

            if (treatmentStage == null)
                return Result.Fail("TreatmentStage not found");

            var contentType = ContentType.Create(request.ContentType);

            var uploadFileResponce = await blobService.UploadAsync(request.Stream, request.ContentType);

            var newBlobFile = treatmentStage.CreateTreatmentStageFile(
                BlobFileUrl.Create(uploadFileResponce.Uri),
                contentType,
                BlobFileType.Image);

            await blobFileRepository.AddAsync(newBlobFile, cancellationToken);

            await blobFileRepository.SaveChangesAsync(cancellationToken);

            var blobFileDto = new BlobFileDto(
                newBlobFile.Id.Value,
                newBlobFile.Path.FileName,
                newBlobFile.FileType.Value,
                newBlobFile.CreateDate,
                newBlobFile.Accessibilitylevel.Value);

            return blobFileDto;
        }
    }
}
