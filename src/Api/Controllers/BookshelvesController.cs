using AutoMapper;
using Eliboo.Application.Contracts.Requests;
using Eliboo.Application.Contracts.Responses;
using Eliboo.Application.Services;
using Eliboo.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Eliboo.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BookshelvesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BookshelvesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var bookshelves = await _unitOfWork.Bookshelves.GetAll(userId);
            return Ok(bookshelves);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewBookshelf([FromBody] NewBookshelfRequest request)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var user = await _unitOfWork.Users.GetAsync(userId);
            var bookshelf = new Bookshelf { Description = request.Description, LibraryId = user.LibraryId };
            _unitOfWork.Bookshelves.Add(bookshelf);
            var affected = await _unitOfWork.CommitAsync();
            return affected < 1 ? BadRequest() : Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveBookshelves([FromBody] IEnumerable<IdRequest> request)
        {
            var bookshelves = _mapper.Map<IEnumerable<Bookshelf>>(request);
            _unitOfWork.Bookshelves.RemoveRange(bookshelves);
            var affected = await _unitOfWork.CommitAsync();
            return affected < 1 ? BadRequest() : Ok();
        }
    }
}
