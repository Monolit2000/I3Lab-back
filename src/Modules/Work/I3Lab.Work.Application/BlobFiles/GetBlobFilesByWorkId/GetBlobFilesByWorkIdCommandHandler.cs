using FluentResults;
using I3Lab.Works.Domain.BlobFiles;
using I3Lab.Works.Domain.Works;
using MediatR;

namespace I3Lab.Works.Application.BlobFiles.GetBlobFilesByWorkId
{
    public class GetBlobFilesByWorkIdCommandHandler(
        IBlobFileRepository blobFileRepository) : IRequestHandler<GetBlobFilesByWorkIdCommand, Result<List<BlobFileDto>>>
    {
        public async Task<Result<List<BlobFileDto>>> Handle(GetBlobFilesByWorkIdCommand request, CancellationToken cancellationToken)
        {
            var files = await blobFileRepository.GetAllWorkIdAsync(new WorkId(request.WorkId));

            if (files is null || !files.Any())
                return new List<BlobFileDto>();
            
            var sortedFiles = files
                .OrderBy(file => file.FileType.Value)
                .GroupBy(file => file.FileType.Value)
                .Select(group => new BlobFileDto
                {
                    FileType = group.Key,
                    Files = group.OrderBy(f => f.CreateDate).ToList()
                }).ToList();

            return sortedFiles;
        }
    }

    public class BlobFileDto
    {
        public string FileType { get; set; }
        public List<BlobFile> Files { get; set; }
    }
}

