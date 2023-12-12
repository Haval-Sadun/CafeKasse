using CafeKasse.MAUI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeKasse.MAUI.Services
{
    public class CategoryService : BaseApiService
    {
        private IEnumerable<Category>? _categories;
        public CategoryService(IHttpClientFactory httpClientFactory) : base(httpClientFactory) { }

        public async ValueTask<IEnumerable<Category>> GetAllCategories()
        {
            if (_categories == null)
            {
                var response = await HttpClient.GetAsync("/api/Categories");

                var categories = await HandleApiResponseAsync<IEnumerable<Category>>(response, null);

                if (categories == null)
                    return Enumerable.Empty<Category>();
                _categories = categories;
            }
            return _categories;
        }

    }
}

