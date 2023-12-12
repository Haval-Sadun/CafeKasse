using CafeKasse.MAUI.Models;
using CafeKasse.MAUI.Pages;
using CafeKasse.MAUI.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeKasse.MAUI.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        public ObservableCollection<Table> Tables { get; set; } = new();

        private readonly TableService _tableService;

        public HomeViewModel(TableService tableService)
        {
            _tableService = tableService;
        }

        [RelayCommand]
        private async Task GoToCategoryPage(Table table)
        {
            var parameters = new Dictionary<string, object>()
            {
                [nameof(CategoryViewModel.Table)] = table,
            };
            await Shell.Current.GoToAsync(nameof(CategoryPage), animate: true, parameters);
        }

        public async Task initializeTables()
        {
            var tables = await _tableService.GetAllTables();
            Tables.Clear();
            foreach (var table in tables)
            {
                Tables.Add(table);
            }
        }
    }
}
