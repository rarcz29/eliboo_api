using Eliboo.Data.DataProvider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Eliboo.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/library")]
    public class LibraryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public LibraryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IActionResult CreateNewLibrary()
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return BadRequest(username);
        }
    }
}
