using AutoMapper;
using Eliboo.Api.Contracts.Responses;
using Eliboo.Application.Contracts.Requests;
using Eliboo.Application.Services;
using Eliboo.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Eliboo.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BooksController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var libraryId = await _unitOfWork.Users.GetLibraryIdAsync(userId);
            var books = await _unitOfWork.Books.GetAllFromLibraryAsync(libraryId);
            var booksResponse = _mapper.Map<IEnumerable<BookResponse>>(books);
            return Ok(booksResponse);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook([FromBody] BookRequest request)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var bookshelfId = await _unitOfWork.Bookshelves.GetIdAsync(request.Bookshelf, userId);
            var book = _mapper.Map<Book>(request);
            book.BookshelfId = bookshelfId;
            _unitOfWork.Books.Add(book);
            var affected = await _unitOfWork.CommitAsync();
            return affected < 1 ? BadRequest() : Created($"api/books/{book.Id}", null);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveBook(int id)
        {
            _unitOfWork.Books.Remove(id);
            var affected = await _unitOfWork.CommitAsync();
            return affected < 1 ? BadRequest() : Ok();
        }

        [HttpDelete()]
        public async Task<IActionResult> RemoveBooks([FromBody] IEnumerable<IdRequest> request)
        {
            var booksToRemove = _mapper.Map<List<Book>>(request);
            _unitOfWork.Books.RemoveRange(booksToRemove);
            var affected = await _unitOfWork.CommitAsync();
            return affected < 1 ? BadRequest() : Ok();
        }

        [HttpGet("find")]
        public async Task<IActionResult> FindBooks([FromQuery] BookRequest request)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var libraryId = await _unitOfWork.Users.GetLibraryIdAsync(userId);
            var pattern = _mapper.Map<Book>(request);
            var books = await _unitOfWork.Books.FindBooksAsync(pattern, libraryId);
            var response = _mapper.Map<IEnumerable<BookResponse>>(books);
            return Ok(response);
        }

        [HttpGet("current")]
        public async Task<IActionResult> GetCurrentBook()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var readingNow = await _unitOfWork.Books.GetReadingNow(userId);
            var response = _mapper.Map<BookResponse>(readingNow);
            return Ok(response);
        }

        [HttpPatch("current/{id}")]
        public async Task<IActionResult> AddReadingNow([FromRoute] int id)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            await _unitOfWork.Books.AddToReaingNow(userId, id);
            await _unitOfWork.CommitAsync();
            return Ok();
        }
    }
}
