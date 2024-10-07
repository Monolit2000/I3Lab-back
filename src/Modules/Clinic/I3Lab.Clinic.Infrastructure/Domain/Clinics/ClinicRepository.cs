using I3Lab.Clinics.Domain.Clinics;
using I3Lab.Clinics.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace I3Lab.Clinics.Infrastructure.Domain.Clinics
{
    public class ClinicRepository : IClinicRepository
    {
        private readonly ClinicContext _context;

        public ClinicRepository(ClinicContext context)
        {
            _context = context;
        }

        public async Task<Clinic?> GetByIdAsync(ClinicId clinicId)
        {
            return await _context.Clinics
                .Include(c => c.ClinicDoctors) 
                .FirstOrDefaultAsync(c => c.Id == clinicId);
        }

        public async Task<List<Clinic>> GetAllAsync()
        {
            return await _context.Clinics
                .Include(c => c.ClinicDoctors)
                .ToListAsync();
        }

        public async Task AddAsync(Clinic clinic)
        {
            await _context.Clinics.AddAsync(clinic);
        }

        public async Task DeleteAsync(Clinic clinic)
        {
            _context.Clinics.Remove(clinic);
        }

        public async Task<bool> ExistByName(ClinicName clinicName)
        {
            return await _context.Clinics.AnyAsync(c => c.ClinicName.Value == clinicName.Value);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
            => await _context.SaveChangesAsync();
    }
}
