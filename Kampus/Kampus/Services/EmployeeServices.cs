using Kampus.Models;
using Plugin.RestClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kampus.Services
{
    public class EmployeeServices
    {
        public async Task<List<Login>> GetEmployeesAsync()
        {
            RestClient<Login> restClient = new RestClient<Login>("LoginModel/Get/");
            var LoginModel = await restClient.GetAsync();
            return LoginModel;
        }
        public async Task PostEmployeeAsync(Login Login)
        {
            RestClient<Login> restClient = new RestClient<Login>("LoginModel/Post/");
            var LoginModel = await restClient.PostAsync(Login);
        }
        public async Task PutEmployeeAsync(int id, Login Login)
        {
            RestClient<Login> restClient = new RestClient<Login>("LoginModel/Put/");
            var LoginModel = await restClient.PutAsync(id, Login);
        }
        public async Task DeleteEmployeeAsync(int id, Login Login)
        {
            RestClient<Login> restClient = new RestClient<Login>("LoginModel/Delete/");
            var LoginModel = await restClient.DeleteAsync(id, Login);
        }

        public async Task<List<Login>> GetEmployeesByKeyWordAsync(string keyWord)
        {
            RestClient<Login> restClient = new RestClient<Login>("LoginModel/Search/");
            var LoginModel = await restClient.GetByKeyWordAsync(keyWord);
            return LoginModel;
        }


    }
}
