using MediatR;
using I3Lab.API.Modules.Base;
using Microsoft.AspNetCore.Mvc;
using I3Lab.Modules.BlobFailes.Application.BlobFiles.CreateBlobFile;
using I3Lab.Modules.BlobFailes.Application.BlobFiles.GetBlobFileById;

namespace I3Lab.API.Modules.BlobFiles
{
    [Route("api/v{apiVersion:apiVersion}/blobFiles")]
    [ApiController]
    public class BlobFilesController(
        IMediator mediator) : BaseController
    {

        //[HttpPost("createBlobFile")]
        //public async Task<IActionResult> CreateBlobFile(CreateBlobFileCommand createBlobFileCommand)
        // => HandleResult(await mediator.Send(createBlobFileCommand));


        //[HttpGet("getBlobFileById")]
        //public async Task<IActionResult> GetBlobFileById([FromQuery] GetBlobFileByIdQuery getBlobFileByIdQuery)
        //   => HandleResult(await mediator.Send(getBlobFileByIdQuery));
    }
}
