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

namespace I3Lab.Works.Application.BlobFiles.GetBlobFile
{
    public class GetBlobFileStreamQuerieHandler(
        IBlobFileRepository blobFileRepository,
        IBlobService blobService) : IRequestHandler<GetBlobFileStreamQuerie, Result<BlobFileDto>>
    {
        public async Task<Result<BlobFileDto>> Handle(GetBlobFileStreamQuerie request, CancellationToken cancellationToken)
        {
            var blobFile = await blobFileRepository.GetByIdAsync(new BlobFile(request.BlobFileId));

            var fileResponce = await blobService.DownloadAsync(blobFile.Id.Value);

            return new BlobFileDto(fileResponce.Stream);

        }
    }
}
