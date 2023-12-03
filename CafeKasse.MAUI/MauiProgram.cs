using CafeKasse.MAUI.Services;
using CafeKasse.MAUI.ViewModels;
using CafeKasse.MAUI.Pages;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

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

            
#if DEBUG
            builder.Logging.AddDebug();
#endif
            AddCafeServices(builder.Services);

            return builder.Build();
        }

        private static IServiceCollection AddCafeServices (IServiceCollection services)
        {
            services.AddSingleton<TableService> ();
            services.AddSingleton<CategoryService> ();
            services.AddSingleton<ItemService> ();

            services.AddSingletonWithShellRoute<HomePage, HomeViewModel>(nameof(HomePage));
            services.AddTransientWithShellRoute<CategoryPage, CategoryViewModel>(nameof(CategoryPage));
            return services;
        }
    }
}
