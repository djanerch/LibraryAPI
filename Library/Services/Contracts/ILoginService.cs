using Library.Api.Models;

namespace Library.Api.Services.Contracts
{
    public interface ILoginService
    {
        string GenerateJSONWebToken(UserModel userInfo);
        UserModel AuthenticateUser(UserLogin login);
    }
}
