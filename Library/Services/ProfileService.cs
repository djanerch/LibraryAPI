using Library.Api.Models;
using Library.Api.Services.Contracts;
using Library.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Api.Services
{
    public class ProfileService : IProfileService
    {
        private LibraryDbContext context;

        public ProfileService(LibraryDbContext context)
        {
            this.context = context;
        }

        public PersonalProfileInfo GetProfileInfo(UserModel user)
        {
            var dbUser = context
                .Users
                .FirstOrDefault(x => x.Name == user.Username && x.Email == user.EmailAddress);

            var profileInfo = new PersonalProfileInfo()
            {
                Username = dbUser.Name,
                Email = dbUser.Email,
                Role = dbUser.Role,
                Books = context.Books
                .Where(x => x.UserId == dbUser.Id)
                .Select(x => new BookWithHeader
                {
                    Header = x.Header
                })
                .ToList()
            };

            return profileInfo;
        }

        public JsonResult GetAllProfilesInfo(int page)
        {
            var result = new JsonResult();

            var collection = context.Users.Select(x => new AllProfileInfo()
            {
                Username = x.Name,
                Books = context.Books
                .Where(s => s.UserId == x.Id)
                .Select(x => new BookWithHeader
                {
                    Header = x.Header
                })
                .ToList()
            })
            .ToList();

            result.BuildProfiles(collection, page);

            return result;
        }
    }
}
