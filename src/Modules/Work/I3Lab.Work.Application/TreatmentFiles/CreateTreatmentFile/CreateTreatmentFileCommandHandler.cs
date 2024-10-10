using MediatR;
using FluentResults;
using I3Lab.Treatments.Domain.TreatmentFiles;
using I3Lab.Treatments.Domain.TreatmentStages;
using I3Lab.BuildingBlocks.Application.BlobStorage;
using I3Lab.Treatments.Application.Configuration.Errors;

namespace I3Lab.Treatments.Application.TreatmentFiles.CreateTreatmentFile
{
    public class CreateTreatmentFileCommandHandler(
        ITreatmentStageRepository workRepository,
        ITreatmentFileRepository blobFileRepository,
        IBlobService blobService) : IRequestHandler<CreateTreatmentFileCommand, Result<TreatmentFileDto>>
    {
        public async Task<Result<TreatmentFileDto>> Handle(CreateTreatmentFileCommand request, CancellationToken cancellationToken)
        {
            var treatmentStage = await workRepository.GetByIdAsync(new TreatmentStageId(request.WorkId), cancellationToken);

            if (treatmentStage == null)
                return Result.Fail(StatusCodeErrors.ResourceNotFound("TreatmentStage not found"));

            //Use TreatmentFile module
            var uploadFileResponce = await blobService.UploadAsync(request.Stream, request.ContentType);

            var newBlobFile = treatmentStage.CreateTreatmentStageFile(
                BlobFileUrl.Create(uploadFileResponce.Uri),
                ContentType.Create(request.ContentType),
                BlobFileType.Image);

            await blobFileRepository.AddAsync(newBlobFile, cancellationToken);

            await blobFileRepository.SaveChangesAsync(cancellationToken);

            var blobFileDto = new TreatmentFileDto(
                newBlobFile.Id.Value,
                newBlobFile.BlobFilePath.FileName,
                newBlobFile.FileType.Value,
                newBlobFile.CreateDate);

            return blobFileDto;
        }
    }
}
