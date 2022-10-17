using Library.Api.Services.Contracts;
using System.Text;

namespace Library.Api.Services
{
    public class HomeService : IHomeService
    {
        public string GetLinks()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Books: " + "https://localhost:5001/api/books");
            sb.AppendLine("Profiles: " + "https://localhost:5001/api/allprofiles");
            sb.AppendLine("Register: " + "https://localhost:5001/api/register");
            sb.Append("Login: " + "https://localhost:5001/api/login");

            return sb.ToString();
        }
    }
}
