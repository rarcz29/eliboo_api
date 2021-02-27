using Eliboo.Application.Contracts.Requests;
using Eliboo.Application.Contracts.Responses;
using Eliboo.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Eliboo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthService _authService;

        public AuthController(IUnitOfWork unitOfWork, IAuthService authService)
        {
            _unitOfWork = unitOfWork;
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequest request)
        {
            if (request.Password == request.Confirm)
            {
                var registered = false;

                if (request.IsNewLibraryCheckboxChecked)
                {
                    registered = await _authService.RegisterAsync(request.Username, request.Email, request.Password);
                }
                else
                {
                    var libraryId = await _unitOfWork.Libraries.GetId(request.LibraryCode);
                    registered = await _authService.RegisterAsync(request.Username, request.Email, request.Password, libraryId);
                }

                return registered ? Ok() : BadRequest();

            }
            return StatusCode(406);
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] UserAuthenticationRequest request)
        {
            var token = await _authService.AuthenticateAsync(request.Email, request.Password);
            var response = new AuthSuccessResponse { Token = token };
            return token != null ? Ok(response) : Unauthorized();
        }
    }
}
