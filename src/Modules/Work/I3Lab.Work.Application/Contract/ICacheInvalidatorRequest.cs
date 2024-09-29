using MediatR;

namespace I3Lab.Treatments.Application.Contract
{
    public interface ICacheInvalidatorRequest 
    {
        string CacheKey => string.Empty;
    }
}
