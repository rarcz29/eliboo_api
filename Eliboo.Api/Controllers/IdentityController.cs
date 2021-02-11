using Eliboo.Api.Contracts.Requests;
using Eliboo.Api.Contracts.Responses;
using Eliboo.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eliboo.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/auth")]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityManager _identityManager;

        public IdentityController(IIdentityManager identityManager)
        {
            _identityManager = identityManager;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserAuthenticationRequest request)
        {
            var token = _identityManager.Authenticate(request.Email, request.Password);
            var response = new AuthSuccessResponse { Token = token };
            return token == null ? Ok(response) : Unauthorized();
        }
    }
}
