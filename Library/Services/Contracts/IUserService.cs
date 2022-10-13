using Library.Api.Models;
using Microsoft.AspNetCore.Http;

namespace Library.Api.Services.Contracts
{
    public interface IUserService
    {
        UserModel GetCurrentUser(HttpContext httpContext);
    }
}
