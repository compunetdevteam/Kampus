using Kampus.Models;
using Plugin.RestClient;
using System.Threading.Tasks;

namespace Kampus.Services
{
    public class LoginServices
    {
        public async Task<StudentApi> LoginAsync(LoginModel login)
        {
            RestClient<Login> restClient = new RestClient<Login>("AccountApi/Login/");
            var result = await restClient.GetLogin(login);
            return result;
        }
    }
}
