using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Domain.Members
{
    public interface IMemberRepository
    {
        public  Task<Member> GetByIdAsync(MemberId id);

        public  Task AddAsync(Member member);

        public  Task UpdateAsync(Member member);

        public  Task DeleteAsync(MemberId id);

    }
}
