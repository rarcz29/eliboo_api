using Eliboo.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Eliboo.Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }
    }
}
