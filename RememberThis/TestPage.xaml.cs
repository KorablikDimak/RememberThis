using RememberThis.Models;
using RememberThis.ViewModels;

namespace RememberThis;

public partial class TestPage : ContentPage
{
    private readonly TestViewModel _test;
    
    public TestPage(Test test)
    {
        _test = new TestViewModel(test);
        InitializeComponent();
        BindingContext = _test;
    }
}