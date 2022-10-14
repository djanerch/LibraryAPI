using Library.Api.Models;
using Library.Api.Services.Contracts;
using Library.Data;
using Library.Data.Models;
using System.Linq;

namespace Library.Api.Services
{
    public class RegisterService : IRegisterService
    {
        private LibraryDbContext context;

        public RegisterService(LibraryDbContext context)
        {
            this.context = context;
        }
        public string Register(RegisterModel registerModel)
        {
            if (context.Users.FirstOrDefault(x => x.Name == registerModel.Username) != null)
            {
                return "Invalid data!Try again...";
            }
            else if (context.Users.FirstOrDefault(x => x.Email == registerModel.Email) != null)
            {
                return "Invalid data!Try again...";
            }
            else if (registerModel.Password.Length <= 4)
            {
                return "Invalid data!Try again...";
            }

            var user = new User()
            {
                Name = registerModel.Username,
                Email = registerModel.Email,
                Password = Hash.sha256(registerModel.Password),
                Role = "Reader"
            };

            context.Users.Add(user);

            context.SaveChanges();

            return $"Hi {registerModel.Username}! You succesfully created account.";
        }
    }
}
