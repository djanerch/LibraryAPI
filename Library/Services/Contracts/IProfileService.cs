using Library.Api.Models;

namespace Library.Api.Services.Contracts
{
    public interface IProfileService
    {
        PersonalProfileInfo GetProfileInfo(UserModel user);
    }
}
