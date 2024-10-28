using MediatR;
using I3Lab.API.Modules.Base;
using Microsoft.AspNetCore.Mvc;
using I3Lab.Clinics.Application.DoctorCreationProposals.CreateDoctorCreationProposal;
using I3Lab.Clinics.Application.DoctorCreationProposals.GetAllDoctorCreationProposal;
using I3Lab.Clinics.Application.DoctorCreationProposals.GetAllDoctorCreationProposalByStatus;
using I3Lab.Doctors.Application.DoctorCreationProposals.ConfirmDoctorCreationProposal;
using I3Lab.Clinics.Application.DoctorCreationProposals.RejectDoctorCreationProposal;

namespace I3Lab.API.Modules.Clinics.DoctorCreationProposals
{
    [Route("api/v{apiVersion:apiVersion}/clinics/doctors/doctorCreationProposals")]
    [ApiController]
    public class DoctorCreationProposalsController(
        IMediator mediator) : BaseController
    {
        [HttpPost("createDoctorCreationProposal")]
        public async Task<IActionResult> CreateDoctorCreationProposal(CreateDoctorCreationProposalCommand createDoctorCreationProposalCommand)
            => HandleResult(await mediator.Send(createDoctorCreationProposalCommand)); 
        

        [HttpPost("confirmDoctorCreationProposal")]
        public async Task<IActionResult> ConfirmDoctorCreationProposal(ConfirmDoctorCreationProposalCommand confirmDoctorCreationProposalCommand)
            => HandleResult(await mediator.Send(confirmDoctorCreationProposalCommand));   
        

        [HttpPost("rejectDoctorCreationProposal")]
        public async Task<IActionResult> RejectDoctorCreationProposal(RejectDoctorCreationProposalCommand confirmDoctorCreationProposalCommand)
            => HandleResult(await mediator.Send(confirmDoctorCreationProposalCommand));


        [HttpGet("getAllDoctorCreationProposals")]
        public async Task<IActionResult> GetAllDoctorCreationProposals()
            => HandleResult(await mediator.Send(new GetAllDoctorCreationProposalQuery()));


        [HttpGet("getAllDoctorCreationProposalByStatus")]
        public async Task<IActionResult> GetAllDoctorCreationProposalByStatus(GetAllDoctorCreationProposalByStatusQuery getAllDoctorCreationProposalByStatusQuery)
            => HandleResult(await mediator.Send(getAllDoctorCreationProposalByStatusQuery));
    }
}
