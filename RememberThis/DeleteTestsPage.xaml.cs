using RememberThis.Models;
using RememberThis.ViewModels;

namespace RememberThis;

public partial class DeleteTestsPage : ContentPage
{
    private readonly TestListViewModel _testList;
    
    public DeleteTestsPage(TestListViewModel testList)
    {
        InitializeComponent();
        _testList = testList;
        BindingContext = _testList;
    }

    private void ButtonRemoveOnClicked(object? sender, EventArgs e)
    {
        _testList.RemoveTests(TestListView.SelectedItems.Select(test => test as Test ?? new Test()).ToList());
        Navigation.PopAsync();
    }
}