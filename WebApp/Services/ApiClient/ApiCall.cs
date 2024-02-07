using System.Text.Json;
using WebApp.Models;

namespace WebApp.Services.ApiClient
{
    public interface IApiCall
    {
        Task<T> Call<T>(string url, HttpRequestMessage httpRequestMessage);
    }
    public class ApiCall : IApiCall
    {
        public async Task<T> Call<T>(string url, HttpRequestMessage httpRequestMessage)
        {
            using (var client = new HttpClient())
            {                
                var response = await client.SendAsync(httpRequestMessage);
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(json);
            }
        }
    }
}
