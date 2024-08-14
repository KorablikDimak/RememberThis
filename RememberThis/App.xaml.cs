using RememberThis.Services;

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
        if (!PlatformProperties.IsDesktop()) return window;
        
        window.MinimumWidth = window.MaximumWidth = window.Width = PlatformProperties.DefaultWidthMobile * PlatformProperties.WidthScaling;
        window.MinimumHeight = window.MaximumHeight = window.Height = window.Width * 1.78;
        return window;
    }
}