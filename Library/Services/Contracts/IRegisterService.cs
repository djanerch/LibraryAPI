using Library.Api.Models;

namespace Library.Api.Services.Contracts
{
    public interface IRegisterService
    {
        string Register(RegisterModel registerModel);
    }
}
