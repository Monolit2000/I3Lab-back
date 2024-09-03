using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Domain.Members
{
    public interface IMemberRepository
    {
        public  Task<Member> GetMemberByIdAsync(MemberId id);

        public Task<Member> GetByEmailAsync(string email);

        public Task<bool> IsEmailTakenAsync(string email);

        public  Task AddAsync(Member member);

        public  Task UpdateAsync(Member member);

        public  Task DeleteAsync(MemberId id);


        public Task SaveChangesAsync();

    }
}
