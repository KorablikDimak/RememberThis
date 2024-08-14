using RememberThis.Services;

namespace RememberThis;

public partial class HelpPage : ContentPage
{
    public double WidthScaling { get; } = PlatformProperties.WidthScaling;
    public double HeightScaling { get; } = PlatformProperties.HeightScaling;
    
    public HelpPage()
    {
        InitializeComponent();
    }

    private void ContinueButtonClicked(object? sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
}