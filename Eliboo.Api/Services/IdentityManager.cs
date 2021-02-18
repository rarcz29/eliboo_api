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

        // TODO: database connection
        // TODO: password hashing
        public async Task<string> AuthenticateAsync(string email, string password)
        {
            var user = await _unitOfWork.Users.GetUserByEmailAsync(email);

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

        public async Task RegisterAsync(string username, string email, string password)
        {
            // TODO: library id
            var user = new User
            {
                LibraryId = 1,
                Nickname = username,
                Email = email,
                Password = password,
                CreatedAt = DateTime.Now
            };
            _unitOfWork.Users.Add(user);
            await _unitOfWork.CommitAsync();
        }
    }
}
