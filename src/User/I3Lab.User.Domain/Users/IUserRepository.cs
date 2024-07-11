using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Users.Domain.Users
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(UserId id);
        Task<IEnumerable<User>> GetAllAsync();
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(User user);
        Task<User> GetByEmailAsync(string email); // New method



    }
}
