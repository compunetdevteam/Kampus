using Kampus.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Plugin.RestClient
{
    /// <summary>
    /// RestClient implements methods for calling CRUD operations
    /// using HTTP.
    /// </summary>
    public class RestClient<T>
    {
        private const string DefaultUrl = "https://ebsuportal.azurewebsites.net/";
        private string WebServiceUrl;

        public RestClient(string urlExtension)
        {
            WebServiceUrl = DefaultUrl + urlExtension;
        }

        public async Task<List<T>> GetAsync()
        {
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(WebServiceUrl);

            var taskModels = JsonConvert.DeserializeObject<List<T>>(json);

            return taskModels;
        }

        public async Task<bool> PostAsync(T t)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(t);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PostAsync(WebServiceUrl, httpContent);

            return result.IsSuccessStatusCode;
        }

        public async Task<bool> PutAsync(int id, T t)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(t);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PutAsync(WebServiceUrl + id, httpContent);

            return result.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id, T t)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.DeleteAsync(WebServiceUrl + id);

            return response.IsSuccessStatusCode;
        }
        public async Task<List<T>> GetByKeyWordAsync(string keyWord)
        {
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(WebServiceUrl + "Search/" + keyWord);

            var taskModels = JsonConvert.DeserializeObject<List<T>>(json);

            return taskModels;
        }
        public async Task<StudentApi> GetLogin(LoginModel login)
        {
            var httpClient = new HttpClient();
            //var json = JsonConvert.SerializeObject(login);
            //HttpContent httpContent = new StringContent(json);
            var keyValuePair = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("Email", login.Email),
                new KeyValuePair<string, string>("Password", login.Password),

            };
            var taskModels = new StudentApi();

            var request = new HttpRequestMessage(HttpMethod.Post, WebServiceUrl);

            request.Content = new FormUrlEncodedContent(keyValuePair);

            //var result = await httpClient.PostAsync(WebServiceUrl, httpContent);
            try
            {
                var result = await httpClient.SendAsync(request);
                //result = await httpClient.PostAsync(WebServiceUrl,);
                var content = await result.Content.ReadAsStringAsync();
                taskModels = JsonConvert.DeserializeObject<StudentApi>(content);
            }
            catch (Exception e)
            {
                taskModels.Message = e.Message;
            }

            return taskModels;


        }


        public async Task<SignUpModel> SearchStudent(string search)
        {
            var httpClient = new HttpClient();
            var taskModels = new SignUpModel();
            var newUrl = WebServiceUrl + "?id=" + search;
            var json = JsonConvert.SerializeObject(search);

            HttpContent httpContent = new StringContent(json);

            try
            {

                var request = new HttpRequestMessage(HttpMethod.Post, newUrl);

                var result = await httpClient.PostAsync(newUrl, httpContent);
                var content = await result.Content.ReadAsStringAsync();

                taskModels = JsonConvert.DeserializeObject<SignUpModel>(content);

            }
            catch (Exception e)
            {
                taskModels.Message = e.Message;
            }

            return taskModels;

        }

        public async Task<string> RegisterStudent(RegisterModel model)
        {
            var httpClient = new HttpClient();

            var keyValuePair = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("StudentId", model.StudentId),
                new KeyValuePair<string, string>("FirstName", model.FirstName),
                new KeyValuePair<string, string>("LastName", model.LastName),
                new KeyValuePair<string, string>("Department", model.Department),
                new KeyValuePair<string, string>("Email", model.Email),
                new KeyValuePair<string, string>("Password", model.Password),
                new KeyValuePair<string, string>("ConfirmPassword", model.ConfirmPassword),
            };
            var taskModels = string.Empty;

            var request = new HttpRequestMessage(HttpMethod.Post, WebServiceUrl);

            request.Content = new FormUrlEncodedContent(keyValuePair);

            try
            {
                var result = await httpClient.SendAsync(request);
                //result = await httpClient.PostAsync(WebServiceUrl,);
                var content = await result.Content.ReadAsStringAsync();
                try
                {
                    var responseModel = JsonConvert.DeserializeObject<ResponseModel>(content);
                    taskModels = responseModel.Message;

                }
                catch (Exception e)
                {
                    taskModels = content;
                }

            }
            catch (Exception e)
            {
                taskModels = e.Message;
            }

            return taskModels;
        }
    }
}
