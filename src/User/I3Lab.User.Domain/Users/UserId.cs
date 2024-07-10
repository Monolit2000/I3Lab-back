using I3Lab.BuildingBlocks.Domain;

namespace I3Lab.Users.Domain.Users
{
    public class UserId : TypedIdValueBase
    {
        public UserId(Guid value) 
            : base(value)
        {
        }
    }
}