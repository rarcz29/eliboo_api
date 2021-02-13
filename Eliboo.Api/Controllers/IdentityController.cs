using Eliboo.Api.Contracts.Requests;
using Eliboo.Api.Contracts.Responses;
using Eliboo.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Eliboo.Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityManager _identityManager;

        public IdentityController(IIdentityManager identityManager)
        {
            _identityManager = identityManager;
        }

        // TODO: Return a different status if not registered
        [HttpPost("register")]
        public IActionResult Register([FromBody] UserRegistrationRequest request)
        {
            _identityManager.Register(request.Username, request.Email, request.Password);
            return Ok();
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserAuthenticationRequest request)
        {
            var token = _identityManager.Authenticate(request.Email, request.Password);
            var response = new AuthSuccessResponse { Token = token };
            return token == null ? Ok(response) : Unauthorized();
        }
    }
}
