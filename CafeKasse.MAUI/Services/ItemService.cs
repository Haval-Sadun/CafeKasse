using CafeKasse.MAUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeKasse.MAUI.Services
{
    public class ItemService : BaseApiService
    {
        private IEnumerable<Item> _items;
        public ItemService(IHttpClientFactory httpClientFactory) : base(httpClientFactory) { }
        public async ValueTask<IEnumerable<Item>> GetAllItems()
        {
            if (_items == null)
            {
                var response = await HttpClient.GetAsync("/api/Items");

                var items = await HandleApiResponseAsync<IEnumerable<Item>>(response, null);

                if (items == null)
                    return Enumerable.Empty<Item>();
                _items = items;
            }
            return _items;
        }
        public async ValueTask<IEnumerable<Item>> GetItemForCategory(int categoryId) =>
            (await GetAllItems())
            .Where(c => c.CategoryId == categoryId);


    }
}
