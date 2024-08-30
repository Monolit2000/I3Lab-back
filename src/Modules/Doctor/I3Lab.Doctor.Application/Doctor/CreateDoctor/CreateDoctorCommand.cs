using FluentResults;
using MediatR;
using I3Lab.Doctors.Domain.DoctorCreationProposals;

namespace I3Lab.Doctors.Application.Doctor.CreateDoctor
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
