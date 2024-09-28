using I3Lab.Treatments.Domain.Treatments;
using I3Lab.Treatments.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using I3Lab.Treatments.Domain.Members;


namespace I3Lab.Treatments.Infrastructure.Domain.Treatments
{
    public class TretmentRepository : ITreatmentRepository
    {
        private readonly TreatmentContext _context;

        public TretmentRepository(TreatmentContext context)
        {
            _context = context;
        }

        public async Task<bool> IsNameUniqueAsync(string name, CancellationToken cancellationToken = default)
        {
            var treatment = await _context.Treatments.AnyAsync(x => x.Titel.Value == name/*TreatmentTitel.Create(name)*/);
            if (treatment == true)
                return false;

            return true;
        }

        public async Task<Treatment> GetByIdAsync(TreatmentId id, CancellationToken cancellationToken = default)
        {
            var treatment = await _context.Treatments
                .AsSplitQuery() 
                .Include(t => t.TreatmentMembers)
                    .ThenInclude(tm => tm.Member)
                .FirstOrDefaultAsync(t => t.Id == id, cancellationToken);

            return treatment;
        }

        public async Task<List<Treatment>> GetAllByPatientAsync(MemberId patientId, CancellationToken cancellationToken = default)
        {
            var treatments = await _context.Treatments
                .AsSplitQuery() 
                .Include(t => t.Patient)
                .Include(t => t.TreatmentMembers)
                    .ThenInclude(tm => tm.Member)
                .Where(t => t.Patient.Id == patientId)
                .ToListAsync(cancellationToken);

            return treatments;
        }

        public async Task<IEnumerable<Treatment>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Treatments
                 .Include(t => t.Patient)
                 .Include(t => t.Creator)
                 .ToListAsync();
        }

        public async Task<Treatment> GetByTokenAsync(string token)
        {
            return await _context.Treatments
                .FirstOrDefaultAsync(ti => ti.InvitationToken.Token == token && ti.InvitationToken.ExpiryDate > DateTime.UtcNow);
        }

        public async Task AddAsync(Treatment treatment, CancellationToken cancellationToken = default)
        {
            await _context.Treatments.AddAsync(treatment);
        }

        public async Task UpdateAsync(Treatment treatment, CancellationToken cancellationToken = default)
        {
             _context.Treatments.Update(treatment);
        }

        public async Task DeleteAsync(TreatmentId id, CancellationToken cancellationToken = default)
        {
            var treatment = await GetByIdAsync(id, cancellationToken);
            if (treatment != null)
            {
                _context.Treatments.Remove(treatment);
            }
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync();
        }
    }
}
