using MediatR;
using FluentResults;
using I3Lab.Clinics.Domain.Doctors;
using I3Lab.Clinics.Domain.DoctorCreationProposals;

namespace I3Lab.Clinics.Application.Doctors.CreateDoctor
{
    public class CreateDoctorCommandHandler(
        IDoctorRepository doctorRepository,
        IDoctorCreationProposalRepository doctorCreationProposalRepository) : IRequestHandler<CreateDoctorCommand, Result<DoctorDto>>
    {
        public async Task<Result<DoctorDto>> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
        {
            var propose = await doctorCreationProposalRepository.GetByIdAsync(request.DoctorCreationProposalId);
            if (propose is null)
                return Result.Fail(DoctorApplicationErrors.DoctorCreationProposalNotFound);

            var doctor = propose.CreateDoctor();

            await doctorRepository.AddAsync(doctor);
            await doctorRepository.SaveChangesAsync();

            return new DoctorDto();
        }
    }
}
