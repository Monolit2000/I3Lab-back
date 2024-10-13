using MediatR;
using I3Lab.API.Modules.Base;
using Microsoft.AspNetCore.Mvc;
using I3Lab.Treatments.Application.TreatmentFiles.GetTreatmentFile;
using I3Lab.Treatments.Application.TreatmentFiles.CreateTreatmentFile;
using I3Lab.Treatments.Application.TreatmentFiles.GetBlobFilesByWorkId;

namespace I3Lab.API.Modules.Treatments.TreatmentFiles
{
    [Route("api/v{apiVersion:apiVersion}/treatmentFiles")]
    [ApiController]
    public class TreatmentFilesController(
        IMediator mediator) : BaseController
    {

        [HttpPost("uploadWorkFile")]
        public async Task<IActionResult> UploadTreatmentFile(UploadWorkFileRequest uploadWorkFileRequest)
        {
            using Stream stream = uploadWorkFileRequest.formFile.OpenReadStream();    

            var file = stream;

            return HandleResult(await mediator.Send(new CreateTreatmentFileCommand 
            { 
                WorkId = uploadWorkFileRequest.TreatmentId,
                FileName = uploadWorkFileRequest.FileName, 
                Stream = stream,
                ContentType = uploadWorkFileRequest.formFile.ContentType
            }));                                                                                                                                             
        }

        [HttpGet("downloadWorkFile")]
        public async Task<IResult> DownloadTreatmentFile(GetTreatmentFileStreamQuerie getBlobFileStreamQuerie)
        {
            var fileResponce = await mediator.Send(getBlobFileStreamQuerie);

            if (fileResponce.IsFailed)
                return Results.Empty;

            return Results.File(fileResponce.Value.Stream, fileResponce.Value.ContentType);
        }


        [HttpGet("downloadWithDeatelsWorkFile")]
        public async Task<IActionResult> DownloadWithDeatelsTreatmentFile(GetTreatmentFileStreamQuerie getBlobFileStreamQuerie)
        {
            var filrResponce = await mediator.Send(getBlobFileStreamQuerie);

            if (filrResponce.IsFailed)
                return HandleResult(filrResponce);

            return Ok(Results.File(filrResponce.Value.Stream));
        }


        [HttpGet("getAllBlobFilesByWorkId")]
        public async Task<IActionResult> GetAllTreatmentFilesByTreatmentId(GetAllBlobFilesByTreatmentStageIdCommand getAllBlobFilesByWorkIdCommand) 
            => HandleResult(await mediator.Send(getAllBlobFilesByWorkIdCommand));

    }
}

