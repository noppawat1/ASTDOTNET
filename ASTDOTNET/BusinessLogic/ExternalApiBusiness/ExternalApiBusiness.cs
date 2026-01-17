using ASTDOTNET.Models.Response;
using System.Text.Json;

namespace ASTDOTNET.BusinessLogic.ExternalApiBusiness
{
    public class ExternalApiBusiness : IExternalApiBusiness
    {
        private readonly HttpClient _httpClient;
        private const string Url = "https://jsonplaceholder.typicode.com/todos/1";

        public ExternalApiBusiness(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ExternalApiResponse> GetTodoAsync()
        {
            var response = await _httpClient.GetAsync(Url);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var todo = JsonSerializer.Deserialize<TodoDto>(json);

            return new ExternalApiResponse
            {
                url = Url,
                method = "GET",
                response = todo
            };
        }
    }
}
