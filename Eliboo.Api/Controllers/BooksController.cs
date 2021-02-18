using Eliboo.Api.Contracts.Requests;
using Eliboo.Data.DataProvider;
using Microsoft.AspNetCore.Mvc;

namespace Eliboo.Api.Controllers
{
    [ApiController]
    [Route("api/books")]
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

        public IActionResult AddNewBook([FromBody] BookDataRequest request)
        {
            _unitOfWork.Books.Add
            return BadRequest();
        }
    }
}
