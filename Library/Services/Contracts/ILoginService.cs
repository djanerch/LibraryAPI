using Library.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Api.Services.Contracts
{
    public interface ILoginService
    {
        string GenerateJSONWebToken(UserModel userInfo);
        UserModel AuthenticateUser(UserLogin login);
    }
}
