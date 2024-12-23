using RememberThis.Services;
using RememberThis.ViewModels;

namespace RememberThis;

public partial class DeleteTestsPage : ContentPage
{
    public double WidthScaling { get; } = PlatformProperties.WidthScaling;
    public double HeightScaling { get; } = PlatformProperties.HeightScaling;
    
    private readonly TestListViewModel _testListViewModel;
    
    public DeleteTestsPage(TestListViewModel testList)
    {
        InitializeComponent();
        _testListViewModel = testList;
        BindingContext = _testListViewModel;
    }

    private async void ButtonRemoveOnClicked(object? sender, EventArgs e)
    {
        _testListViewModel.RemoveTests(_testListViewModel.TestListViewData
            .Where(testViewModel => testViewModel.IsChecked)
            .Select(testViewModel => testViewModel.Test)
            .ToList());
        await Navigation.PopAsync();
    }
}