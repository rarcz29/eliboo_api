using Eliboo.Data.DataProvider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eliboo.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/library")]
    public class LibraryRepository : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public LibraryRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IActionResult CreateNewLibrary()
        {
            var username = User.Identity.Name;
            return BadRequest(username);
        }
    }
}
