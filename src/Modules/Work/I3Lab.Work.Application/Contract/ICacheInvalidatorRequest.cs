
namespace I3Lab.Treatments.Application.Contract
{
    public interface ICacheInvalidatorRequest 
    {
        string CacheKey { get; }
    }
}
