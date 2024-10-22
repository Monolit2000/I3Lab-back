using I3Lab.Clinics.Domain.Clinics;
using I3Lab.Clinics.Domain.Doctors;
using I3Lab.Clinics.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace I3Lab.Clinics.Infrastructure.Domain.Clinics
{
    public class ClinicRepository(ClinicContext context) : IClinicRepository
    {

        public async Task<Clinic?> GetByIdAsync(ClinicId clinicId)
        {
            return await context.Clinics
                .Include(c => c.Doctors) 
                .FirstOrDefaultAsync(c => c.Id == clinicId);
        }

        public async Task<List<Clinic>> GetAllAsync()
        {
            return await context.Clinics
                .Include(c => c.Doctors)
                .ToListAsync();
        }

        public async Task<List<Clinic>> GetAllClnicsByDoctorId(DoctorId id)
        {
            return await context.Clinics
                .Where(c => c.Doctors.Any(d => d.DoctorId == id))
                .Include(c => c.Doctors)
                .ToListAsync();
        }

        public async Task<List<Clinic>> GetAllClnicsByDoctorIdV2(DoctorId id)
        {
            var doctor = await context.Doctors.FirstOrDefaultAsync(d => d.Id == id);

            return await context.Clinics
                .Where(c => doctor.Clinics.Any(d => d.DoctorId == id))
                .ToListAsync();


            //return await context.Clinics
            // .Where(c => context.Doctors.FirstOrDefault(d => d.Id == id).Clinics.Select(c => c.DoctorId).Contains(id))
            // .ToListAsync();

            //return await context.Clinics
            //    .Where(x => doctor.Clinics.Select(d => d.ClinicId).Contains(x.Id)).ToListAsync();
        }


        public async Task AddAsync(Clinic clinic)
        {
            await context.Clinics.AddAsync(clinic);
        }

        public async Task DeleteAsync(Clinic clinic)
        {
            context.Clinics.Remove(clinic);
        }

        public async Task<bool> ExistByName(ClinicName clinicName)
        {
            return await context.Clinics.AnyAsync(c => c.ClinicName.Value == clinicName.Value);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
            => await context.SaveChangesAsync();
    }
}
