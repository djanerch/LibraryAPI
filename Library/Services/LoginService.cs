using Library.Api.Models;
using Library.Api.Services.Contracts;
using Library.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Library.Api.Services
{
    public class LoginService : ILoginService
    {
        private IConfiguration config;
        private LibraryDbContext context;

        public LoginService(IConfiguration config, LibraryDbContext context)
        {
            this.config = config;
            this.context = context;
        }
        public UserModel AuthenticateUser(UserLogin login)
        {
            var user = context.Users.FirstOrDefault(x => x.Name == login.Username);
            if (user != null)
            {
                if (CheckUserPassword(user.Password, login.Password))
                {
                    return new UserModel { Username = user.Name, EmailAddress = user.Email, Password = user.Password, Role = user.Role };
                }
            }
            return null;
        }

        private bool CheckUserPassword(string userPassword, string loginPassword)
        {
            var encodedPassword = Hash.sha256(loginPassword);

            if (userPassword == encodedPassword)
            {
                return true;
            }

            return false;
        }

        public string GenerateJSONWebToken(UserModel userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userInfo.Username),
                new Claim(ClaimTypes.Email, userInfo.EmailAddress),
                new Claim(ClaimTypes.Role, userInfo.Role)
            };

            var token = new JwtSecurityToken(config["Jwt:Issuer"],
              config["Jwt:Audience"],
              claims,
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}