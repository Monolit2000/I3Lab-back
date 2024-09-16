using FluentResults;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace I3Lab.API.Modules.Base
{
    public abstract class BaseController : ControllerBase
    {
        private IMediator? _mediator;

        public BaseController()
        {
        }

        protected IMediator Mediator => _mediator ??=
            HttpContext.RequestServices.GetService<IMediator>()!;

        protected ActionResult HandleResult<T>(Result<T> result)
        {
            if (!result.IsSuccess)
            {
                return BadRequest(result.Reasons);
            }
            return Ok(result.Value);
        }

        protected ActionResult HandleResult(Result result)
        {
            if (!result.IsSuccess)
            {
                return BadRequest(result.Reasons);
            }
            return Ok(result);
        }

        protected ActionResult HandleResultWithReasonsAsStrArray<T>(Result<T> result)
        {
            if (!result.IsSuccess)
            {
                return BadRequest(result.Reasons.Select(r => r.Message));
            }

            return Ok(result.Value);
        }
    }
}
