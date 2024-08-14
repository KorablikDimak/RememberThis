using CommunityToolkit.Maui;
using RememberThis.ViewModels;

namespace RememberThis;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder()
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddSingleton<TestListPage>();
        builder.Services.AddSingleton<ActiveTestListPage>();
        builder.Services.AddSingleton<CompletedTestListPage>();
        builder.Services.AddSingleton<TestListViewModel>();

        return builder.Build();
    }
}