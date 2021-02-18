using Eliboo.Api.Contracts.Requests;
using Eliboo.Api.Contracts.Responses;
using Eliboo.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequest request)
        {
            if (request.Password == request.Confirm)
            {
                await _identityManager.RegisterAsync(request.Username, request.Email, request.Password);
            }
            return Ok();
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] UserAuthenticationRequest request)
        {
            var token = await _identityManager.AuthenticateAsync(request.Email, request.Password);
            var response = new AuthSuccessResponse { Token = token };
            return token != null ? Ok(response) : Unauthorized();
        }
    }
}
