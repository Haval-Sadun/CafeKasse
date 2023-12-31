﻿using CafeKasse.MAUI.ViewModels;

namespace CafeKasse.MAUI.Pages
{
    public partial class HomePage : ContentPage
    {
        private readonly HomeViewModel _homeViewModel;

        public HomePage(HomeViewModel homeViewModel)
        {
            InitializeComponent();
            _homeViewModel = homeViewModel;
            BindingContext = _homeViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _homeViewModel.initializeTables();
        }


    }

}
