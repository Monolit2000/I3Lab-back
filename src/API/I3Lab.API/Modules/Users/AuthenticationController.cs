using MediatR;
using I3Lab.API.Modules.Base;
using Microsoft.AspNetCore.Mvc;
using I3Lab.Users.Application.Login;
using I3Lab.Users.Application.Register;
using Asp.Versioning;

namespace I3Lab.API.Modules.Users
{
    [ApiController]
    [Route("api/v{apiVersion:apiVersion}/authentication")]
    [ApiVersion(1)]
    [ApiVersion(2)]
    public class AuthenticationController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<AuthenticationController> _logger;

        public AuthenticationController(
            IMediator mediator,
            IHttpContextAccessor httpContextAccessor,
            ILogger<AuthenticationController> logger)
        {
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        private HttpContext _httpContext => _httpContextAccessor.HttpContext;


        //[HttpPost("test")]
        //public async Task<IActionResult> Test( )
        //{

        //    var test = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.FullAddress;
        //    return Ok(test);
        //}

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserCommand registerUserCommand)
        {
            return HandleResult(await _mediator.Send(registerUserCommand));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginCommand loginCommand)
        {
            //_httpContext.Response.Cookies.Append("token", responce.FullAddress.Token);
            return HandleResult(await _mediator.Send(loginCommand));
        }

        //[HttpPost("refresh")]
        //public async Task<IActionResult> Refresh()
        //{
        //    _logger.LogInformation("Refresh called");

        //    var refreshToken = Request.Cookies["refrash-Token"];

        //    //if (!User)
        //    //{ 

        //    //}



        //    return Ok();
        //}

        //[Authorize]
        //[HttpDelete("revoke")]
        //public async Task<IActionResult> Revoke()
        //{
        //    _logger.LogInformation("Revoke called");

          

        //    return Ok();
        //}


    }
}
