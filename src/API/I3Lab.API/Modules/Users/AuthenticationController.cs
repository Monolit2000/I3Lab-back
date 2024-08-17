using I3Lab.Users.Application.Login;
using I3Lab.Users.Application.Register;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity.Core.Objects;
using System.IdentityModel.Tokens.Jwt;

namespace I3Lab.API.Modules.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
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

        [Authorize]
        [HttpPost("Test")]
        public async Task<IActionResult> Test( )
        {
            return Ok("Test");
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterUserCommand registerUserCommand)
        {
            var responce = await _mediator.Send(registerUserCommand);

            return Ok(responce);
        
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginCommand loginCommand)
        {

            var responce = await _mediator.Send(loginCommand);

            _httpContext.Response.Cookies.Append("token", responce.Value.Token);

            return Ok(responce);

        }

        [HttpPost("Refresh")]
        public async Task<IActionResult> Refresh()
        {
            _logger.LogInformation("Refresh called");

            var refreshToken = Request.Cookies["refrash-Token"];

            //if (!User)
            //{ 

            //}



            return Ok();
        }

        [Authorize]
        [HttpDelete("Revoke")]
        public async Task<IActionResult> Revoke()
        {
            _logger.LogInformation("Revoke called");

          

            return Ok();
        }


    }
}
