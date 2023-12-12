using CafeKasse.MAUI.Models;
using CafeKasse.MAUI.Models.Enums;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace CafeKasse.MAUI.Services
{
    public class TableService : BaseApiService
    {
        private IEnumerable<Table>? _tables;
        public TableService(IHttpClientFactory httpClientFactory) : base(httpClientFactory) { }

        public async ValueTask<IEnumerable<Table>> GetAllTables()
        {
            if (_tables == null)
            {
                var response = await HttpClient.GetAsync("/api/Tables");

                var tables = await HandleApiResponseAsync<IEnumerable<Table>>(response, null);
                if (tables is null)
                    return Enumerable.Empty<Table>();

                _tables = tables;
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

        public async ValueTask<Table> SaveTableAsync(Table table)
        {
            string json = JsonSerializer.Serialize<Table>(table, serializerOptions);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;

            response = await HttpClient.PostAsync("/api/Tables", content);

            return await HandleApiResponseAsync<Table>(response, null);
        }
        public async Task UpdateTableAsync(Table table, int id)
        {
            string json = JsonSerializer.Serialize(table, serializerOptions);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            await HttpClient.PutAsync($"/api/Table/{id}", content);

        }
        public async Task DeleteTableAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await HttpClient.DeleteAsync($"/api/Table/{id}");
                if (response.IsSuccessStatusCode)
                    Debug.WriteLine(@"\tTable successfully deleted.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }
    }
}
