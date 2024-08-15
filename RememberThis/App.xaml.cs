using RememberThis.Services;
using RememberThis.ViewModels;

namespace RememberThis;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        MainPage = new AppShell();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        var window = base.CreateWindow(activationState);

        window.Destroying += (_, _) =>
        {
            var testList = Handler?.MauiContext?.Services.GetService<TestListViewModel>(); 
            if (testList == null) return;
            Storage.WriteTestList(testList.TestListViewData);
        };
        
        if (!PlatformProperties.IsDesktop()) return window;
        window.MinimumWidth = window.MaximumWidth = window.Width = PlatformProperties.DefaultWidthMobile * PlatformProperties.WidthScaling;
        window.MinimumHeight = window.MaximumHeight = window.Height = window.Width * 1.78;
        return window;
    }
}