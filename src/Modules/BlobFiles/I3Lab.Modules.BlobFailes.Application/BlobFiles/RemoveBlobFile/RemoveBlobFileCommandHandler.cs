using FluentResults;
using I3Lab.Modules.BlobFailes.Domain.BlobFiles;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Modules.BlobFailes.Application.BlobFiles.RemoveBlobFile
{
    public class RemoveBlobFileCommandHandler(
        IBlobFileRepository blobFileRepository) : IRequestHandler<RemoveBlobFileCommand, Result>
    {
        public async Task<Result> Handle(RemoveBlobFileCommand request, CancellationToken cancellationToken)
        {
            await blobFileRepository.DeleteAsync(new BlobFileId(request.BlobFileId));

            await blobFileRepository.SaveChangesAsync();

            return Result.Ok();
        }
    }
}
