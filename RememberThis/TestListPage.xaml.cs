using RememberThis.Models;
using RememberThis.ViewModels;

namespace RememberThis;

public partial class TestListPage : ContentPage
{
    private readonly TestListViewModel _testList;
    
    public TestListPage(TestListViewModel testListViewModel)
    {
        InitializeComponent();
        _testList = testListViewModel;
        BindingContext = testListViewModel;
    }

    private void ListViewOnItemTapped(object? sender, ItemTappedEventArgs e)
    {
        Navigation.PushAsync(new TestPage(_testList.TestListViewData[e.ItemIndex]));
    }

    private void ButtonAddTestOnClicked(object? sender, EventArgs e)
    {
        var test = new Test { Name = "TestName", Questions = [] };
        _testList.AddTest(test);
        Navigation.PushAsync(new TestPage(test));
    }
    
    private void ButtonRemoveTestsOnClicked(object? sender, EventArgs e)
    {
        Navigation.PushAsync(new DeleteTestsPage(_testList));
    }
}