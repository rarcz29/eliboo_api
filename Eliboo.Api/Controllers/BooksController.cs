using Eliboo.Api.Contracts.Requests;
using Eliboo.Data.DataProvider;
using Eliboo.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Eliboo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public BooksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook([FromBody] BookDataRequest request)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var bookshelfId = await _unitOfWork.Bookshelves.GetIdAsync(request.Bookshelf, userId);

            var book = new Book
            {
                Title = request.Title,
                Author = request.Author,
                Genre = request.Genre,
                BookshelfId = bookshelfId
            };

            _unitOfWork.Books.Add(book);
            var affected = await _unitOfWork.CommitAsync();
            return affected < 1 ? StatusCode(500) : Ok();
        }
    }
}
