using CafeKasse.MAUI.ViewModels;

namespace CafeKasse.MAUI.Pages
{
    public partial class CategoryPage : ContentPage
    {
        private readonly CategoryViewModel _categoryViewModel;

        public CategoryPage(CategoryViewModel categoryViewModel)
        {
            InitializeComponent();
            _categoryViewModel = categoryViewModel;
            BindingContext = _categoryViewModel;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _categoryViewModel.Initialize();
        }
    }
}