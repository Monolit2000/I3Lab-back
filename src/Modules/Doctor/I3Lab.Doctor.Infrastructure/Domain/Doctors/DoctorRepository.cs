using I3Lab.Doctors.Domain.Doctors;
using I3Lab.Doctors.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace I3Lab.Doctors.Infrastructure.Domain.Doctors
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly DoctorContext _context;

        public DoctorRepository(DoctorContext context)
        {
            _context = context;
        }

        public async Task<Doctor?> GetByIdAsync(DoctorId id)
        {
            return await _context.Doctors
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task AddAsync(Doctor doctor)
        {
            await _context.Doctors.AddAsync(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Doctor doctor)
        {
            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
        }

        public Task<List<Doctor>> GetAll()
        {
            throw new NotImplementedException();
        }

        //public async Task<IEnumerable<Doctors>> GetAllByStatusAsync(ConfirmationStatus status)
        //{
        //    return await _context.Doctors
        //        .Where(d => d.ConfirmationStatus == status)
        //        .ToListAsync();
        //}
    }
}
