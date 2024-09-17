using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Doctors.Domain.Doctors
{
    public interface IDoctorRepository
    {
        Task<Doctor> GetByIdAsync(DoctorId id);

        Task AddAsync(Doctor doctor);

        Task UpdateAsync(Doctor doctor);

        Task DeleteAsync(Doctor doctor);

        Task<List<Doctor>> GetAll();
                            
        //Task<IEnumerable<Doctor>> GetAllByStatusAsync(ConfirmationStatus status);
    }
}
