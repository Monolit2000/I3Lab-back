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
        IBlobService blobService) : IRequestHandler<CreateBlobFileBlobFileCommand, Result<BlobFileDto>>
    {
        public async Task<Result<BlobFileDto>> Handle(CreateBlobFileBlobFileCommand request, CancellationToken cancellationToken)
        {
            var work = await workRepository.GetByIdAsync(new WorkId(request.WorkId));

            if (work == null)
                return Result.Fail("dsf");

            var blobFileNameId = await blobService.UploadAsync(request.Stream, request.Type.Value);

            var blobFileUrl = BlobFileUrl.Create(blobFileNameId.ToString());

            var newBlobFile = work.CreateBlobFile(
                blobFileNameId.ToString(),
                request.Type, 
                blobFileUrl);

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
