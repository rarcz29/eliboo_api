using Eliboo.Api.Contracts.Requests;
using Eliboo.Api.Contracts.Responses;
using Eliboo.Api.Services;
using Eliboo.Data.DataProvider;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Eliboo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthService _identityManager;

        public AuthController(IUnitOfWork unitOfWork, IAuthService identityManager)
        {
            _unitOfWork = unitOfWork;
            _identityManager = identityManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequest request)
        {
            if (request.Password == request.Confirm)
            {
                var registered = false;

                if (request.IsNewLibraryCheckboxChecked)
                {
                    registered = await _identityManager.RegisterAsync(request.Username, request.Email, request.Password);
                }
                else
                {
                    var libraryId = await _unitOfWork.Libraries.GetId(request.LibraryCode);
                    registered = await _identityManager.RegisterAsync(request.Username, request.Email, request.Password, libraryId);
                }

                return registered ? Ok() : StatusCode(500);

            }
            return StatusCode(406);
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
