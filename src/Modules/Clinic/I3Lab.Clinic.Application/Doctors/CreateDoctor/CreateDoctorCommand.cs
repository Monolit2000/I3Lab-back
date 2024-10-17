using MediatR;
using FluentResults;
using I3Lab.Clinics.Domain.DoctorCreationProposals;

namespace I3Lab.Clinics.Application.Doctors.CreateDoctor
{
    public class CreateDoctorCommand : IRequest<Result<DoctorDto>>
    {
        public DoctorCreationProposalId DoctorCreationProposalId { get; set; }

        public CreateDoctorCommand(DoctorCreationProposalId doctorCreationProposalId)
        {
            DoctorCreationProposalId = doctorCreationProposalId;
        }
    }
}
