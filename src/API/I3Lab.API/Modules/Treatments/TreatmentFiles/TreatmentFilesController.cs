using MediatR;
using I3Lab.API.Modules.Base;
using Microsoft.AspNetCore.Mvc;
using I3Lab.BuildingBlocks.Application.BlobStorage;
using I3Lab.Treatments.Application.TreatmentFiles.GetTreatmentFile;
using I3Lab.Treatments.Application.TreatmentFiles.CreateTreatmentFile;
using I3Lab.Treatments.Application.TreatmentFiles.GetBlobFilesByWorkId;

namespace I3Lab.API.Modules.Treatments.TreatmentFiles
{
    [Route("api/treatmentFiles")]
    [ApiController]
    public class TreatmentFilesController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<TreatmentFilesController> _logger;
        private readonly IBlobService _blobService;

        public TreatmentFilesController(
            IMediator mediator,
            IHttpContextAccessor httpContextAccessor,
            ILogger<TreatmentFilesController> logger,
            IBlobService blobService)
        {
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
            _blobService = blobService;
        }

        [HttpPost("uploadWorkFile")]
        public async Task<IActionResult> UploadTreatmentFile(IFormFile formFile, UploadWorkFileRequest uploadWorkFileRequest)
        {
            using Stream stream = formFile.OpenReadStream();    

            var file = stream;

            return HandleResult(await _mediator.Send(new CreateTreatmentFileCommand 
            { 
                WorkId = uploadWorkFileRequest.WorkId,
                FileName = uploadWorkFileRequest.FileName, 
                Stream = stream,
                ContentType = formFile.ContentType
            }));                                                                                                                                             
        }

        [HttpGet("downloadWorkFile")]
        public async Task<IResult> DownloadTreatmentFile(GetTreatmentFileStreamQuerie getBlobFileStreamQuerie)
        {
            var fileResponce = await _mediator.Send(getBlobFileStreamQuerie);

            if (fileResponce.IsFailed)
                return Results.Empty;

            return Results.File(fileResponce.Value.Stream, fileResponce.Value.ContentType);
        }


        [HttpGet("downloadWithDeatelsWorkFile")]
        public async Task<IActionResult> DownloadWithDeatelsTreatmentFile(GetTreatmentFileStreamQuerie getBlobFileStreamQuerie)
        {
            var filrResponce = await _mediator.Send(getBlobFileStreamQuerie);

            if (filrResponce.IsFailed)
                return HandleResult(filrResponce);

            return Ok(Results.File(filrResponce.Value.Stream));
        }


        [HttpGet("getAllBlobFilesByWorkId")]
        public async Task<IActionResult> GetAllTreatmentFilesByTreatmentId(GetAllBlobFilesByTreatmentStageIdCommand getAllBlobFilesByWorkIdCommand) 
            => HandleResult(await _mediator.Send(getAllBlobFilesByWorkIdCommand));

    }
}

