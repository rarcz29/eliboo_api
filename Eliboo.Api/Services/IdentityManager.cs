using Eliboo.Data.DataProvider;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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
        public string Authenticate(string email, string password)
        {
            var user = _unitOfWork.Users.GetUserByEmail(email);

            if (email == user.Email && password == user.Password)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.ASCII.GetBytes(_key);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
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

        public void Register(string username, string email, string password)
        {
            throw new System.NotImplementedException();
        }
    }
}
