using RememberThis.Models;
using RememberThis.Services;
using RememberThis.ViewModels;

namespace RememberThis;

public partial class TestListPage : ContentPage
{
    public double WidthScaling { get; } = PlatformProperties.WidthScaling;
    public double HeightScaling { get; } = PlatformProperties.HeightScaling;

    private readonly TestListViewModel _testListViewModel;

    public TestListPage(TestListViewModel testListViewModel)
    {
        InitializeComponent();
        _testListViewModel = testListViewModel;
        BindingContext = testListViewModel;
    }

    private async void ListViewOnItemTapped(object? sender, ItemTappedEventArgs e)
    {
        await Navigation.PushAsync(new TestPage(_testListViewModel.TestListViewData[e.ItemIndex]));
        Shell.Current.FlyoutBehavior = FlyoutBehavior.Disabled;
    }

    private async void ButtonAddTestOnClicked(object? sender, EventArgs e)
    {
        Test test = new();
        await Navigation.PushAsync(new TestPage(new TestViewModel(test)));
        Shell.Current.FlyoutBehavior = FlyoutBehavior.Disabled;
        _testListViewModel.AddTest(test);
    }
    
    private async void ButtonRemoveTestsOnClicked(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(new DeleteTestsPage(_testListViewModel));
        Shell.Current.FlyoutBehavior = FlyoutBehavior.Disabled;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        Shell.Current.FlyoutBehavior = FlyoutBehavior.Flyout;
        _testListViewModel.TestListViewData.ForEach(testViewModel => testViewModel.Update());
    }
}