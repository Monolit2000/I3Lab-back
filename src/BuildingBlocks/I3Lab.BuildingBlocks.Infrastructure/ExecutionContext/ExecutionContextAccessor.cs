using I3Lab.BuildingBlocks.Application;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.BuildingBlocks.Infrastructure.ExecutionContext
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
                //    .Value != null)
                //{
                //    return Guid.Parse(_httpContextAccessor.HttpContext.User.Claims.Single(
                //        x => x.Type == "sub").Value);
                //}

                throw new ApplicationException("User context is not available");
            }
        }

        public bool IsAvailable => _httpContextAccessor.HttpContext != null;
    }
}
