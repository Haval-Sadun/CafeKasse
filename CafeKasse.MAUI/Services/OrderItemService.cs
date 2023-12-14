using CafeKasse.MAUI.Models;
using CafeKasse.MAUI.Models.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CafeKasse.MAUI.Services
{
    public class OrderItemService : BaseApiService
    {
        private readonly OrderService _orderService;
        private IEnumerable<OrderItem> _orderItems;
        public OrderItemService(OrderService orderService, IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _orderService = orderService;
        }

        // we Get the Cart items for the selected order 
        public async ValueTask<IEnumerable<OrderItem>> GetOrderItems()
        {

            var response = await HttpClient.GetAsync("/api/OrderItems");
            var orderItems = await HandleApiResponseAsync<IEnumerable<OrderItem>>(response, null);
            if (orderItems == null)
                return Enumerable.Empty<OrderItem>();
            _orderItems = orderItems;

            return _orderItems;
        }
        public async ValueTask<IEnumerable<OrderItem>> GetOrderItemsByOrder(int id)
        {
            var response = await HttpClient.GetAsync($"/api/OrderItems/Order/{id}");
            var orderItems = await HandleApiResponseAsync<IEnumerable<OrderItem>>(response, null);
            if (orderItems == null)
                return Enumerable.Empty<OrderItem>();
            _orderItems = orderItems;
            return _orderItems;
        }


        public async ValueTask<OrderItem> SaveOrderItemAsync(OrderItem orderItem)
        {
            string json = JsonSerializer.Serialize(orderItem, serializerOptions);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;

            response = await HttpClient.PostAsync("/api/OrderItems", content);

            return await HandleApiResponseAsync<OrderItem>(response, null);

        }
        public async Task UpdateOrderItemAsync(OrderItem orderItem, Guid id)
        {
            string json = JsonSerializer.Serialize(orderItem, serializerOptions);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            await HttpClient.PutAsync($"/api/OrderItems/{id}", content);

        }
        public async Task DeleteOrderItemAsync(Guid id)
        {
            try
            {
                HttpResponseMessage response = await HttpClient.DeleteAsync($"/api/OrderItems/{id}");
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
