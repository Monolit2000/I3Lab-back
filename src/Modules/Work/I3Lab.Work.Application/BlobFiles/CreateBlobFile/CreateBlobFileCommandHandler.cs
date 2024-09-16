using FluentResults;
using I3Lab.BuildingBlocks.Application.BlobStorage;
using I3Lab.Works.Domain.BlobFiles;
using I3Lab.Works.Domain.Works;
using MediatR;

namespace I3Lab.Works.Application.BlobFiles.AddBlobFile
{
    public class CreateBlobFileCommandHandler(
        IWorkRepository workRepository,
        IBlobFileRepository blobFileRepository,
        IBlobService blobService) : IRequestHandler<CreateBlobFileCommand, Result<BlobFileDto>>
    {
        public async Task<Result<BlobFileDto>> Handle(CreateBlobFileCommand request, CancellationToken cancellationToken)
        {
            var work = await workRepository.GetByIdAsync(new WorkId(request.WorkId));

            if (work == null)
                return Result.Fail("Work not found");

            var blobFileNameId = await blobService.UploadAsync(request.Stream, request.FileType);

            var newBlobFile = work.CreateWorkFile(
                blobFileNameId.FileId.ToString(),
                BlobFileType.Image);

            await blobFileRepository.AddAsync(newBlobFile);

            var blobFileDto = new BlobFileDto(
                newBlobFile.Id.Value,
                newBlobFile.FileName,
                newBlobFile.FileType.Value,
                newBlobFile.CreateDate,
                newBlobFile.Accessibilitylevel.Value);

            return blobFileDto;
        }
    }
}

 //var newBlobFile = BlobFile.CreateBaseOnWork(new WorkId(request.WorkId), blobFileNameId.ToString(), BlobFileType.Image, blobFileUrl);