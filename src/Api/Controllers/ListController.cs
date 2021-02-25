using AutoMapper;
using Eliboo.Api.Contracts.Responses;
using Eliboo.Application.Contracts.Requests;
using Eliboo.Application.Services;
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
    public class ListController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ListController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var books = await _unitOfWork.MyList.GetAllBooksFromListAsync(userId);
            var response = _mapper.Map<IEnumerable<BookResponse>>(books);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddBooksToList([FromBody] IEnumerable<IdRequest> request)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var bookIds = new List<int>();

            foreach (var idRequest in request)
            {
                bookIds.Add(idRequest.Id);
            }

            await _unitOfWork.MyList.AddBooksToTheListAsync(userId, bookIds);
            await _unitOfWork.CommitAsync();

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveBooksFromList([FromBody] IEnumerable<IdRequest> request)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var bookIds = new List<int>();

            foreach (var idRequest in request)
            {
                bookIds.Add(idRequest.Id);
            }

            await _unitOfWork.MyList.RemoveBooksFromListAsync(userId, bookIds);
            await _unitOfWork.CommitAsync();

            return Ok();
        }
    }
}
