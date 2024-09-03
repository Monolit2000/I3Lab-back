using FluentResults;
using I3Lab.BuildingBlocks.Application.BlobStorage;
using I3Lab.Works.Domain.BlobFiles;
using I3Lab.Works.Domain.Works;
using MediatR;
using Microsoft.EntityFrameworkCore.Storage.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Application.BlobFiles.AddBlobFile
{
    public class AddBlobFileCommandHandler(
        IWorkRepository workRepository,
        IBlobFileRepository blobFileRepository,
        IBlobService blobService) : IRequestHandler<AddBlobFileCommand, Result<BlobFileDto>>
    {
        public async Task<Result<BlobFileDto>> Handle(AddBlobFileCommand request, CancellationToken cancellationToken)
        {
            var work = await workRepository.GetByIdAsync(new WorkId(request.WorkId));

            var blobFileId = await blobService.UploadAsync(request.Stream, request.Type.Value);

            var newBlobFile = BlobFile.CreateBaseOnWork(
                work.Id,
                new BlobFileId(blobFileId),
                request.FileName,
                request.Type,
                BlobFileUrl.Create(blobFileId.ToString()));

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
