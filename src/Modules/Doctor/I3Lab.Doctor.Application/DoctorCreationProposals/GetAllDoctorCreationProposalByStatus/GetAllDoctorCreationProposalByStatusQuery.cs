using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Doctors.Application.DoctorCreationProposals.GetAllDoctorCreationProposalByStatus
{
    public class GetAllDoctorCreationProposalByStatusQuery : IRequest<Result<List<DoctorCreationProposalDto>>>
    {
        public string Status { get; set; }
    }
}
