using CafeKasse.MAUI.Services;
using CafeKasse.MAUI.ViewModels;
using CafeKasse.MAUI.Pages;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using CafeKasse.MAUI.Interfaces;

namespace CafeKasse.MAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            AddCafeServices(builder.Services);

            builder.Services.AddHttpClient(Constants.AppConstants.HttpClientName, (client) =>
            {
                var baseAddress = DeviceInfo.Platform == DevicePlatform.Android
                                ? "https://10.0.2.2:7045" : "https://localhost:7045";
                client.BaseAddress = new Uri(baseAddress);
            })
                .ConfigureHttpMessageHandlerBuilder(configureBuilder =>
            {
                var platformHttpMessageHandler = configureBuilder.Services.GetRequiredService<IPlatformHttpMessageHandler>();
                configureBuilder.PrimaryHandler = platformHttpMessageHandler.GetHttpMessageHandler();
            });


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        private static IServiceCollection AddCafeServices(IServiceCollection services)
        {
            services.AddSingleton<TableService>();
            services.AddSingleton<CategoryService>();
            services.AddSingleton<ItemService>();
            services.AddSingleton<OrderService>();
            services.AddSingleton<OrderItemService>();

            services.AddSingletonWithShellRoute<HomePage, HomeViewModel>(nameof(HomePage));
            services.AddTransientWithShellRoute<CategoryPage, CategoryViewModel>(nameof(CategoryPage));

            services.AddSingleton<IPlatformHttpMessageHandler, PlatformHttpMessageHandler>();


            return services;
        }
    }
}
