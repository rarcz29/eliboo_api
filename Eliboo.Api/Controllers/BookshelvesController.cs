using Eliboo.Api.Contracts.Requests;
using Eliboo.Data.DataProvider;
using Eliboo.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Eliboo.Api.Controllers
{
    [ApiController]
    [Route("api/bookshelves")]
    public class BookshelvesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookshelvesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //[HttpPost]
        //public async Task<IActionResult> CreateNewBookshelf([FromBody] NewBookshelfRequest request)
        //{
        //    var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
        //    var user = await _unitOfWork.Users.GetAsync(userId);
        //    var bookshelf = new Bookshelf { Description = request.Description, LibraryId = user.LibraryId };
        //    return BadRequest();
        //}
    }
}
