using RememberThis.Services;
using RememberThis.ViewModels;

namespace RememberThis;

public partial class DeleteTestsPage : ContentPage
{
    public double WidthScaling { get; } = PlatformProperties.WidthScaling;
    public double HeightScaling { get; } = PlatformProperties.HeightScaling;
    
    private readonly TestListViewModel _testList;
    
    public DeleteTestsPage(TestListViewModel testList)
    {
        InitializeComponent();
        _testList = testList;
        BindingContext = _testList;
    }

    private async void ButtonRemoveOnClicked(object? sender, EventArgs e)
    {
        _testList.RemoveTests(_testList.TestListViewData.Where(test => test.IsChecked).ToList());
        await Navigation.PopAsync();
    }
}