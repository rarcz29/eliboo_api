using Eliboo.Data.DataProvider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Eliboo.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpDelete()]
        public async Task<IActionResult> RemoveUser()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            _unitOfWork.Users.Remove(userId);
            var libraryId = await _unitOfWork.Users.GetLibraryIdAsync(userId);
            var numberOfUsers = await _unitOfWork.Libraries.GetNumberOfUsersAsync(libraryId);

            if (numberOfUsers < 2)
            {
                _unitOfWork.Libraries.Remove(libraryId);
            }

            var affected = await _unitOfWork.CommitAsync();
            return affected > 0 ? Ok() : StatusCode(500);
        }
    }
}
