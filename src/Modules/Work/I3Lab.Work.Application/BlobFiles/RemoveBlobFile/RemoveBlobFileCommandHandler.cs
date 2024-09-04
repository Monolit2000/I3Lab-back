using FluentResults;
using MediatR;

namespace I3Lab.Works.Application.BlobFiles.RemoveBlobFile
{
    public class RemoveBlobFileCommandHandler : IRequestHandler<RemoveBlobFileCommand, Result>
    {
        public Task<Result> Handle(RemoveBlobFileCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
