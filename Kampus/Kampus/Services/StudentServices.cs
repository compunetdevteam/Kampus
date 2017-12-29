using Kampus.Models;
using Plugin.RestClient;
using System.Threading.Tasks;

namespace Kampus.Services
{
    public class StudentServices
    {
        public async Task<SignUpModel> SearchStudentAsync(string search)
        {
            RestClient<Login> restClient = new RestClient<Login>("AccountApi/SignUp");
            var result = await restClient.SearchStudent(search);
            return result;
        }

        public async Task<string> RegisterStudentAsync(RegisterModel model)
        {
            RestClient<Login> restClient = new RestClient<Login>("AccountApi/RegisterStudent/");
            var result = await restClient.RegisterStudent(model);
            return result;
        }
    }
}
