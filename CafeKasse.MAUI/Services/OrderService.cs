using CafeKasse.MAUI.Models;
using System.Text;
using System.Diagnostics;
using System.Text.Json;
using CafeKasse.MAUI.Models.Enums;

namespace CafeKasse.MAUI.Services
{
    public partial class OrderService : BaseApiService // ObservableObject
    {
        private IEnumerable<Order>? _orders;

        public OrderService(IHttpClientFactory httpClientFactory) : base(httpClientFactory) { }

        public async ValueTask<IEnumerable<Order>> GetAllOrders()
        {

            var response = await HttpClient.GetAsync("/api/Orders");
            var orders = await HandleApiResponseAsync(response, Enumerable.Empty<Order>());
            if (orders == null)
                return Enumerable.Empty<Order>();
            _orders = orders;

            return _orders;
        }

        public async ValueTask<Order> GetOrderByTableNumber(int tableNumber)
        {
            var response = await HttpClient.GetAsync($"/api/Orders/Table/{tableNumber}");
            return await HandleApiResponseAsync<Order>(response, null);

        }


        public async ValueTask<Order> GetOrderbyId(int id) =>
            (await GetAllOrders()).FirstOrDefault(o => o.Id == id);

        public async ValueTask<Order> SaveOrderAsync(Order order)
        {

            string json = JsonSerializer.Serialize(order, serializerOptions);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;

            response = await HttpClient.PostAsync("/api/Orders", content);

            return await HandleApiResponseAsync<Order>(response, null);
        }

        public async Task UpdateOrderAsync(Order order, int id)
        {
            string json = JsonSerializer.Serialize<Order>(order, serializerOptions);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            await HttpClient.PutAsync($"/api/Orders/{id}", content);

        }
        public async Task DeleteOrderAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await HttpClient.DeleteAsync($"/api/Orders/{id}");
                if (response.IsSuccessStatusCode)
                    Debug.WriteLine(@"\tOrderItem successfully deleted.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }
    }
}
