﻿using FluentResults;
using I3Lab.Clinics.Domain.Doctors;
using MediatR;

namespace I3Lab.Clinics.Application.Doctors.GetDoctorById
{
    public class GetDoctorByIdQueryHandler(
        IDoctorRepository doctorRepository) : IRequestHandler<GetDoctorByIdQuery, Result<DoctorDto>>
    {
        public async Task<Result<DoctorDto>> Handle(GetDoctorByIdQuery request, CancellationToken cancellationToken)
        {
            var doctor = await doctorRepository.GetByIdAsync(new DoctorId(request.DoctorId));

            if (doctor == null)
                return Result.Fail("Doctor not exist");

            return new DoctorDto(doctor);
        }
    }
}