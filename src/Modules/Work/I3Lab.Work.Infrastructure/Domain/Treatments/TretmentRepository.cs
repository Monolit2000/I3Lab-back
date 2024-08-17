using I3Lab.Works.Domain.Treatment;
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


        public async Task<Treatment> GetByIdAsync(TreatmentId id)
        {
            var treatment = await _context.Treatments
                .Include(t => t.TreatmentStages)
                .FirstOrDefaultAsync(t => t.Id == id);

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
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Treatment treatment)
        {
            _context.Treatments.Update(treatment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TreatmentId id)
        {
            var treatment = await GetByIdAsync(id);
            if (treatment != null)
            {
                _context.Treatments.Remove(treatment);
                await _context.SaveChangesAsync();
            }
        }
    }
}
