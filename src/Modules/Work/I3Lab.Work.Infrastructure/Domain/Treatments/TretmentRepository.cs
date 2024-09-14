using I3Lab.Works.Domain.Treatments;
using I3Lab.Works.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace I3Lab.Works.Infrastructure.Domain.Treatments
{
    public class TretmentRepository : ITretmentRepository
    {
        private readonly WorkContext _context;

        public TretmentRepository(WorkContext context)
        {
            _context = context;
        }

        public async Task<bool> IsNameUniqueAsync(string name)
        {
            var treatment = await _context.Treatments.AnyAsync(x => x.Titel.Value == name/*Titel.Create(name)*/);
            if (treatment == true)
                return false;

            return true;
        }

        public async Task<Treatment> GetByIdAsync(TreatmentId id, CancellationToken cancellationToken)
        {
            var treatment = await _context.Treatments
                .Include(t => t.TreatmentStages)
                .Include(t => t.TreatmentMembers)
                    .ThenInclude(tm => tm.Member)
                .FirstOrDefaultAsync(t => t.Id == id, cancellationToken);

            return treatment;
        }

        public async Task<IEnumerable<Treatment>> GetAllAsync()
        {
            return await _context.Treatments
                .Include(t => t.TreatmentStages)
                .ToListAsync();
        }

        public async Task AddAsync(Treatment treatment)
        {
            await _context.Treatments.AddAsync(treatment);
        }

        public async Task UpdateAsync(Treatment treatment)
        {
            _context.Treatments.Update(treatment);
        }

        public async Task DeleteAsync(TreatmentId id, CancellationToken cancellationToken)
        {
            var treatment = await GetByIdAsync(id, cancellationToken);
            if (treatment != null)
            {
                _context.Treatments.Remove(treatment);
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
