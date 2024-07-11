using FluentResults;
using I3Lab.BuildingBlocks.Application.BlobStorage;
using I3Lab.Works.Domain.BlobFiles;
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
        IBlobFileRepository blobFileRepository,
        IBlobService blobService) : IRequestHandler<AddBlobFileCommand, Result<BlobFileDto>>
    {
        public async Task<Result<BlobFileDto>> Handle(AddBlobFileCommand request, CancellationToken cancellationToken)
        {
            var newBlobFile = BlobFile.CreateNew(
                request.FileName, 
                request.Type);

            await blobService.UploadAsync(request.Stream, request.Type.Value);

            await blobFileRepository.AddAsync(newBlobFile);

            return new BlobFileDto(
                newBlobFile.Id.Value,
                newBlobFile.FileName,
                newBlobFile.Type.Value,
                newBlobFile.CreateDate,
                newBlobFile.Accessibilitylevel.Value);
        }
    }
}
