using I3Lab.BuildingBlocks.Domain;

namespace I3Lab.User.Domain.User
{
    public class UserId : TypedIdValueBase
    {
        public UserId(Guid value) 
            : base(value)
        {
        }
    }
}