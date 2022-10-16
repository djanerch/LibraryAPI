using Library.Data;
using Library.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Library.Api.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void PrepareDatabase(this IApplicationBuilder app)
        {
            using var scopedService = app.ApplicationServices.CreateScope();
            var serviceProvider = scopedService.ServiceProvider;

            var data = scopedService.ServiceProvider.GetRequiredService<LibraryDbContext>();

            SeedAdministrator(data);
        }

        private static void SeedAdministrator(LibraryDbContext context)
        {
            if(context.Users.FirstOrDefault(x => x.Email == WebConstants.AdminEmail) == null)
            {
                var user = new User()
                {
                    Name = "Admin",
                    Email = WebConstants.AdminEmail,
                    Role = WebConstants.AdminRole,
                    Password = Hash.sha256("admin_password")
                };

                context.Users.Add(user);

                context.SaveChanges();
            }
        }
    }
}