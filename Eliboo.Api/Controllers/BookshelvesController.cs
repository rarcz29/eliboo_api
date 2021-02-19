using Eliboo.Api.Contracts.Requests;
using Eliboo.Api.Contracts.Responses;
using Eliboo.Data.DataProvider;
using Eliboo.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Eliboo.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/bookshelves")]
    public class BookshelvesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookshelvesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewBookshelf([FromBody] NewBookshelfRequest request)
        {
            var user = await GetUser();
            var bookshelf = new Bookshelf { Description = request.Description, LibraryId = user.LibraryId };
            _unitOfWork.Bookshelves.Add(bookshelf);
            var affected = await _unitOfWork.CommitAsync();
            return affected == 1
                ? Ok()
                : StatusCode(StatusCodes.Status500InternalServerError,
                             new FailResponse { Message = "Server didn't add this bookshelf to the database" });
        }

        public async Task<IActionResult> RemoveBookshelf([FromBody] NewBookshelfRequest request)
        {
            var user = await GetUser();
            //_unitOfWork.Bookshelves.Remove(_unitOfWork.Bookshelves.FindAsync);
            //_unitOfWork.Bookshelves.Add(bookshelf);
            //var affected = await _unitOfWork.CommitAsync();
            return BadRequest();
        }

        private async Task<User> GetUser()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            return await _unitOfWork.Users.GetAsync(userId);
        }
    }
}
