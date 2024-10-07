using I3Lab.BuildingBlocks.Application;
using System.Security.Claims;

namespace I3Lab.API.Configuration.ExecutionContext
{
    public class ExecutionContextAccessor : IExecutionContextAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ExecutionContextAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid UserId
        {
            get
            {
                if (_httpContextAccessor
                    .HttpContext?
                    .User?
                    .Claims?
                    .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?
                    .Value != null)
                {
                    return Guid.Parse(_httpContextAccessor.HttpContext.User.Claims.Single(
                        x => x.Type == ClaimTypes.NameIdentifier).Value);
                }



                //if (_httpContextAccessor
                //    .HttpContext?
                //    .User?
                //    .Claims?
                //    .SingleOrDefault(x => x.Type == "sub")?
                //    .FullAddress != null)
                //{
                //    return Guid.Parse(_httpContextAccessor.HttpContext.User.Claims.Single(
                //        x => x.Type == "sub").FullAddress);
                //}

                throw new ApplicationException("User context is not available");
            }
        }

        public bool IsAvailable => _httpContextAccessor.HttpContext != null;
    }
}
