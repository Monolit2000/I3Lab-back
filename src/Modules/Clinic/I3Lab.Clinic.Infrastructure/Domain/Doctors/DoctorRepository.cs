using I3Lab.Clinics.Domain.Doctors;
using Microsoft.EntityFrameworkCore;
using I3Lab.Clinics.Infrastructure.Persistence;
using I3Lab.Clinics.Domain.Clinics;

namespace I3Lab.Clinics.Infrastructure.Domain.Doctors
{
    public class DoctorRepository(ClinicContext context) : IDoctorRepository
    {
        public async Task<Doctor?> GetByIdAsync(DoctorId id)
        {
            return await context.Doctors
                .Include(d => d.Clinics)
                .FirstOrDefaultAsync(d => d.Id == id);
        }


        public async Task AddAsync(Doctor doctor)
        {
            await context.Doctors.AddAsync(doctor);
            //await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Doctor doctor)
        {
            context.Doctors.Update(doctor);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Doctor doctor)
        {
            context.Doctors.Remove(doctor);
            await context.SaveChangesAsync();
        }

        public async Task<List<Doctor>> GetAllAsync()
        {
            return await context.Doctors.ToListAsync();
        }
    }
}
