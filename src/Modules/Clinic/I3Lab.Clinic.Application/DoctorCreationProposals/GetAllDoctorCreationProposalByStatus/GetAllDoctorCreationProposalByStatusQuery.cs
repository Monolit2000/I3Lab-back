﻿using FluentResults;
using MediatR;

namespace I3Lab.Doctors.Application.DoctorCreationProposals.GetAllDoctorCreationProposalByStatus
{
    public class GetAllDoctorCreationProposalByStatusQuery : IRequest<Result<List<DoctorCreationProposalDto>>>
    {
        public string Status { get; set; }
    }
}