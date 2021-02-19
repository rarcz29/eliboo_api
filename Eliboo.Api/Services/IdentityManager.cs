using Eliboo.Data.DataProvider;
using Eliboo.Data.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Eliboo.Api.Services
{
    public class IdentityManager : IIdentityManager
    {
        private readonly string _key;
        private readonly IUnitOfWork _unitOfWork;

        public IdentityManager(IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            _key = configuration.GetValue<string>("JwtSettings:Secret");
            _unitOfWork = unitOfWork;
        }

        // TODO: password hashing
        public async Task<string> AuthenticateAsync(string email, string password)
        {
            var user = await _unitOfWork.Users.GetByEmailAsync(email);

            if (user != null && email == user.Email && password == user.Password)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.ASCII.GetBytes(_key);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.Nickname),
                        new Claim(ClaimTypes.Email, user.Email)
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(30),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(tokenKey),
                        SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }

            return null;
        }

        public async Task<bool> RegisterAsync(string username, string email, string password, int libraryId)
        {
            var user = new User
            {
                LibraryId = libraryId,
                Nickname = username,
                Email = email,
                Password = password,
                CreatedAt = DateTime.Now
            };
            _unitOfWork.Users.Add(user);
            return await _unitOfWork.CommitAsync() == 1;
        }

        public async Task<bool> RegisterAsync(string username, string email, string password)
        {
            // TODO: autogenerete access token
            var library = new Library { AccessToken = "aasdfaasdffdsafasdf" };
            _unitOfWork.Libraries.Add(library);
            await _unitOfWork.CommitAsync();
            return await RegisterAsync(username, email, password, library.Id);
        }
    }
}
