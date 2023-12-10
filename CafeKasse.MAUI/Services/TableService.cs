using CafeKasse.MAUI.Models;
using CafeKasse.MAUI.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CafeKasse.MAUI.Services
{
    public class TableService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private IEnumerable<Table>? _tables;
        public TableService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async ValueTask<IEnumerable<Table>> GetAllTables()
        {
            if (_tables == null)
            {
                var httpClient = _httpClientFactory.CreateClient(Constants.AppConstants.HttpClientName);

                var response = await httpClient.GetAsync("/api/Tables");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    if (content is not null)
                        _tables = JsonSerializer.Deserialize<IEnumerable<Table>?>(content, new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        });
                }
                else
                {
                    return Enumerable.Empty<Table>();
                }
            }
            return _tables;
        }

        public async ValueTask<IEnumerable<Table>> GetTablesByStatus(TableStatus status = TableStatus.Available)
        {
            if (_tables is null)
            {
                var tables = await GetAllTables();

                return tables.Where(t => t.State == status);
            }
            return Enumerable.Empty<Table>();
        }
    }
}
