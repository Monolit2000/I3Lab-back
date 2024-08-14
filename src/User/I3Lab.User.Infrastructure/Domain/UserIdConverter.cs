using I3Lab.Users.Domain.Users;


using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

public class UserIdConverter : ValueConverter<UserId, Guid>
{
    public UserIdConverter() : base(
        userId => userId.Value, 
        guid => new UserId(guid)) 
    { }
}