using RememberThis.Services;

namespace RememberThis;

public partial class HelloPage : ContentPage
{
    public double WidthScaling { get; } = PlatformProperties.WidthScaling;
    public double HeightScaling { get; } = PlatformProperties.HeightScaling;
    
    public HelloPage()
    {
        InitializeComponent();
    }

    private void StartButtonClicked(object? sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
}