using I3Lab.BuildingBlocks.Application;
using I3Lab.Works.Domain.Members;
using I3Lab.Works.Domain.Works;

namespace I3Lab.Works.Infrastructure.Domain.Members
{
    public class MemberContext : IMemberContext
    {
        private readonly IExecutionContextAccessor _executionContextAccessor;

        public MemberContext(IExecutionContextAccessor executionContextAccessor)
        {
            _executionContextAccessor = executionContextAccessor;
        }

        public MemberId MemberId => new MemberId(_executionContextAccessor.UserId);
    }
}
