
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http;


namespace CafeKasse.MAUI.Services
{
    public class BaseApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BaseApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        protected JsonSerializerOptions serializerOptions = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
        protected HttpClient HttpClient => _httpClientFactory.CreateClient(Constants.AppConstants.HttpClientName);

        protected TData Deserialize<TData>(string jsonData) => JsonSerializer.Deserialize<TData>(jsonData, serializerOptions);

        protected async Task<TData> HandleApiResponseAsync<TData>(HttpResponseMessage response, TData defaultResponse)
        {
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                if (content is not null)
                    return Deserialize<TData>(content);
                return defaultResponse;
            }
            return defaultResponse;
        }
    }
}
