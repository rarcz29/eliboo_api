using Eliboo.Api.Contracts.Requests;
using Eliboo.Api.Contracts.Responses;
using Eliboo.Data.DataProvider;
using Eliboo.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        public async Task<IActionResult> GetAllBooks()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var libraryId = await _unitOfWork.Users.GetLibraryIdAsync(userId);
            var books = await _unitOfWork.Books.GetAllFromLibraryAsync(libraryId);
            var booksResponse = new List<BookResponse>();

            // TODO: Bookshelf description
            foreach (var book in books)
            {
                booksResponse.Add(new BookResponse
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                    Genre = book.Genre,
                    Bookshelf = "you have to change this"
                });
            }

            return Ok(new BooksListResponse { Books = booksResponse });
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveBook(int id)
        {
            _unitOfWork.Books.Remove(id);
            var affected = await _unitOfWork.CommitAsync();
            return affected < 1 ? BadRequest() : Ok();
        }
    }
}
