using RememberThis.Services;

namespace RememberThis;

public partial class AboutMePage : ContentPage
{
    public double WidthScaling { get; } = PlatformProperties.WidthScaling;
    public double HeightScaling { get; } = PlatformProperties.HeightScaling;
    
    public AboutMePage()
    {
        InitializeComponent();
    }
}