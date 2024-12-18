﻿//using Microsoft.AspNetCore.Mvc;
//using MediatR;
//using I3Lab.API.Modules.Base;
//using I3Lab.Doctors.Application.DoctorCreationProposals.CreateDoctorCreationProposal;
//using I3Lab.Doctors.Application.DoctorCreationProposals.GetAllDoctorCreationProposalByStatus;
//using I3Lab.Doctors.Application.DoctorCreationProposals.GetAllDoctorCreationProposal;

//namespace I3Lab.API.Modules.Doctors.DoctorCreationProposals
//{

//    [Route("api/v{apiVersion:apiVersion}/doctors/doctorCreationProposals")]
//    [ApiController]
//    public class DoctorCreationProposalsController : BaseController
//    {
//        private readonly IMediator _mediator;
//        private readonly IHttpContextAccessor _httpContextAccessor;
//        private readonly ILogger<DoctorCreationProposalsController> _logger;

//        public DoctorCreationProposalsController(
//            IMediator mediator,
//            IHttpContextAccessor httpContextAccessor,
//            ILogger<DoctorCreationProposalsController> logger)
//        {
//            _mediator = mediator;
//            _httpContextAccessor = httpContextAccessor;
//            _logger = logger;
//        }


//        [HttpPost("createDoctorCreationProposal")]
//        public async Task<IActionResult> CreateDoctorCreationProposal(CreateDoctorCreationProposalCommand createDoctorCreationProposalCommand)
//            => HandleResult(await _mediator.Send(createDoctorCreationProposalCommand));


//        [HttpGet("getAllDoctorCreationProposals")]
//        public async Task<IActionResult> GetAllDoctorCreationProposals()
//            => HandleResult(await _mediator.Send(new GetAllDoctorCreationProposalQuery()));


//        [HttpGet("getAllDoctorCreationProposalByStatus")]
//        public async Task<IActionResult> GetAllDoctorCreationProposalByStatus(GetAllDoctorCreationProposalByStatusQuery getAllDoctorCreationProposalByStatusQuery)
//            => HandleResult(await _mediator.Send(getAllDoctorCreationProposalByStatusQuery));
//    }
//}
