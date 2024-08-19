using I3Lab.Users.Domain.Users;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace I3Lab.Users.Infrastructure.Domain
{
    public class UserIdStringConverter : ValueConverter<UserId, string>
    {
        public UserIdStringConverter() : base(
            userId => userId.Value.ToString(), 
            str => new UserId(Guid.Parse(str))) 
        { 
        }
    }
}
