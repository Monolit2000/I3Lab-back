using MediatR;
using I3Lab.API.Modules.Base;
using Microsoft.AspNetCore.Mvc;
using I3Lab.Treatments.Application.TreatmentFiles.CreateTreatmentFile;
using I3Lab.Treatments.Application.TreatmentFiles.GetTreatmentFile;
using Microsoft.AspNetCore.Http;
using I3Lab.BuildingBlocks.Application.BlobStorage;
using I3Lab.Treatments.Application.TreatmentFiles.GetBlobFilesByWorkId;

namespace I3Lab.API.Modules.Treatments.Files
{
    public class FilesController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<FilesController> _logger;
        private readonly IBlobService _blobService;

        public FilesController(
            IMediator mediator,
            IHttpContextAccessor httpContextAccessor,
            ILogger<FilesController> logger,
            IBlobService blobService)
        {
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
            _blobService = blobService;
        }

        [HttpPost("uploadWorkFile")]
        public async Task<IActionResult> UploadWorkFile(IFormFile formFile, UploadWorkFileRequest uploadWorkFileRequest)
        {
            using Stream stream = formFile.OpenReadStream();    

            var file = stream;

            var createBlobFileCommand = new CreateTreatmentFileCommand(
                uploadWorkFileRequest.WorkId, 
                uploadWorkFileRequest.FileName);

            createBlobFileCommand.Stream = stream;

            createBlobFileCommand.ContentType = formFile.ContentType;

            return HandleResult(await _mediator.Send(createBlobFileCommand));
        }

        [HttpGet("downloadWorkFile")]
        public async Task<IResult> DownloadWorkFile(GetTreatmentFileStreamQuerie getBlobFileStreamQuerie)
        {
            var fileResponce = await _mediator.Send(getBlobFileStreamQuerie);

            if (fileResponce.IsFailed)
                return Results.Empty;

            return Results.File(fileResponce.Value.Stream, fileResponce.Value.ContentType);
        }


        [HttpGet("downloadWithDeatelsWorkFile")]
        public async Task<IActionResult> DownloadWithDeatelsWorkFile(GetTreatmentFileStreamQuerie getBlobFileStreamQuerie)
        {
            var filrResponce = await _mediator.Send(getBlobFileStreamQuerie);

            if (filrResponce.IsFailed)
                return HandleResult(filrResponce);

            return Ok(Results.File(filrResponce.Value.Stream));
        }


        [HttpGet("getAllBlobFilesByWorkId")]
        public async Task<IActionResult> GetAllBlobFilesByWorkId(GetAllBlobFilesByTreatmentStageIdCommand getAllBlobFilesByWorkIdCommand)
        {
            return HandleResult(await _mediator.Send(getAllBlobFilesByWorkIdCommand));
        }

    }
}

