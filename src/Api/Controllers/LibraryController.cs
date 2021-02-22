using Eliboo.Api.Contracts.Responses;
using Eliboo.Application.Services;
using Eliboo.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Eliboo.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class LibraryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public LibraryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewLibrary()
        {
            // TODO: autogenerate token
            string libToken = "asdfasdfasd";
            var library = new Library { AccessToken = libToken };
            _unitOfWork.Libraries.Add(library);
            var affectedRows = await _unitOfWork.CommitAsync();
            return affectedRows == 1
                ? Ok(new AuthSuccessResponse { Token = libToken })
                : StatusCode(StatusCodes.Status500InternalServerError,
                             new FailResponse { Message = "Server cannot add new library to the database." });
        }

        //[HttpDelete]
        //public async Task<IActionResult> RemoveLibrary([FromBody] TokenRequest request)
        //{
        //    // TODO
        //    return BadRequest();
        //}
    }
}
