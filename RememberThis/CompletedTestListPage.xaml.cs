using RememberThis.Models;
using RememberThis.Services;
using RememberThis.ViewModels;

namespace RememberThis;

public partial class CompletedTestListPage : ContentPage
{
    public double WidthScaling { get; } = PlatformProperties.WidthScaling;
    public double HeightScaling { get; } = PlatformProperties.HeightScaling;
    
    private readonly TestListViewModel _testList;
    
    public CompletedTestListPage(TestListViewModel testListViewModel)
    {
        InitializeComponent();
        _testList = testListViewModel;
        BindingContext = testListViewModel;
    }
    
    private async void ListViewOnItemTapped(object? sender, ItemTappedEventArgs e)
    {
        await Navigation.PushAsync(new TestPage(_testList.CompletedTestListViewData[e.ItemIndex]));
        Shell.Current.FlyoutBehavior = FlyoutBehavior.Disabled;
    }

    private async void ButtonAddTestOnClicked(object? sender, EventArgs e)
    {
        Test test = new();
        await Navigation.PushAsync(new TestPage(test));
        Shell.Current.FlyoutBehavior = FlyoutBehavior.Disabled;
        _testList.AddTest(test);
    }
    
    private async void ButtonRemoveTestsOnClicked(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(new DeleteTestsPage(_testList));
        Shell.Current.FlyoutBehavior = FlyoutBehavior.Disabled;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        Shell.Current.FlyoutBehavior = FlyoutBehavior.Flyout;
        _testList.Update();
    }
}