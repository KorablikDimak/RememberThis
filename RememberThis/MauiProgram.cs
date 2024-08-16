using CommunityToolkit.Maui;
using RememberThis.Services;
using RememberThis.ViewModels;

namespace RememberThis;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var storageReadPermissionStatus = Permissions.RequestAsync<Permissions.StorageRead>().Result;
        var storageWritePermissionStatus = Permissions.RequestAsync<Permissions.StorageWrite>().Result;
        
        if (storageReadPermissionStatus != PermissionStatus.Granted || 
            storageWritePermissionStatus != PermissionStatus.Granted)
            throw new InvalidOperationException("Permissions are not granted.");
        
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
        builder.Services.AddSingleton<TestListViewModel>(_ => new TestListViewModel(Storage.ReadTestList()));

        return builder.Build();
    }
}