using Library.Api.Models;
using Library.Api.Services.Contracts;
using Library.Data;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security.Claims;

namespace Library.Api.Services
{
    public class UserService : IUserService
    {
        private LibraryDbContext context;

        public UserService(LibraryDbContext context)
        {
            this.context = context;
        }
        public UserModel GetCurrentUser(HttpContext httpContext)
        {
            var identity = httpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userClaims = identity.Claims;

                return new UserModel
                {
                    Username = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value,
                    EmailAddress = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value,
                    Role = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value
                };
            }
            return null;
        }
        public string AddPointsToUser(UserWithNameAndPoints user)
        {
            var dbUser = context.Users.FirstOrDefault(x => x.Name == user.Username);

            if (dbUser == null)
            {
                return $"User with name: {user.Username} is not found.";
            }

            dbUser.Points += user.Points;

            context.SaveChanges();

            return $"Successfully added {user.Points} points to user with name {user.Username}";
        }
    }
}
