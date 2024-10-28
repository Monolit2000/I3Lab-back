using MediatR;
using FluentResults;
using I3Lab.Treatments.Domain.TreatmentFiles;
using I3Lab.Treatments.Domain.TreatmentStages;
using I3Lab.Treatments.Application.Configuration.Errors;
using I3Lab.Modules.BlobFailes.Api;

namespace I3Lab.Treatments.Application.TreatmentFiles.CreateTreatmentFile
{
    public class CreateTreatmentFileCommandHandler(
        IBlobFilesApi blobFailesApi, 
        ITreatmentStageRepository workRepository,
        ITreatmentFileRepository blobFileRepository) : IRequestHandler<CreateTreatmentFileCommand, Result<TreatmentFileDto>>
    {
        public async Task<Result<TreatmentFileDto>> Handle(CreateTreatmentFileCommand request, CancellationToken cancellationToken)
        {
            var treatmentStage = await workRepository.GetByIdAsync(new TreatmentStageId(request.WorkId), cancellationToken);

            if (treatmentStage == null)
                return Result.Fail(StatusCodeErrors.ResourceNotFound("TreatmentStage not found"));

            //Use TreatmentFile module
            var uploadFileResponce = await blobFailesApi.UploadAsync(request.FileName, request.Stream, request.ContentType);

            if (uploadFileResponce.IsFailed)
                return Result.Fail(uploadFileResponce.Errors);

            var newBlobFile = treatmentStage.CreateTreatmentStageFile(
                BlobFileUrl.Create(uploadFileResponce.Value.Uri),
                ContentType.Create(request.ContentType),
                BlobFileType.Image);

            await blobFileRepository.AddAsync(newBlobFile, cancellationToken);

            await blobFileRepository.SaveChangesAsync(cancellationToken);

            var blobFileDto = new TreatmentFileDto(
                newBlobFile.Id.Value,
                "test",
                "sdffdg",
                newBlobFile.CreateDate);

            return blobFileDto;
        }
    }
}
