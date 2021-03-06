using Eliboo.Application.Contracts.Responses;
using Eliboo.Application.Services;
using Eliboo.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
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
            string libToken = Guid.NewGuid().ToString();
            var library = new Library { AccessToken = libToken };
            _unitOfWork.Libraries.Add(library);
            var affectedRows = await _unitOfWork.CommitAsync();
            return affectedRows < 1
                ? BadRequest()
                : Ok(new AuthSuccessResponse { Token = libToken });
        }
    }
}
