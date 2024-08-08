using RememberThis.Models;
using RememberThis.ViewModels;

namespace RememberThis;

public partial class TestsListPage : ContentPage
{
    private readonly TestListViewModel _testList = new();
    
    public TestsListPage()
    {
        var question1 = new Question{ Problem = "Problem", ImageName = "ImageName", Answer = "Answer", Prompt = "Prompt"};
        var question2 = new Question{ Problem = "Problem", ImageName = "ImageName", Answer = "Answer", Prompt = "Prompt"};
        var question3 = new Question{ Problem = "Problem", ImageName = "ImageName", Answer = "Answer", Prompt = "Prompt"};
        var question4 = new Question{ Problem = "Problem", ImageName = "ImageName", Answer = "Answer", Prompt = "Prompt"};
        var question5 = new Question{ Problem = "Problem", ImageName = "ImageName", Answer = "Answer", Prompt = "Prompt"};
        var question6 = new Question{ Problem = "Problem", ImageName = "ImageName", Answer = "Answer", Prompt = "Prompt"};

        List<Question> questions1 = [question1, question2, question3];
        List<Question> questions2 = [question4, question5, question6];

        _testList.AddTest(new Test { Name = "Test1", Questions = questions1 });
        _testList.AddTest(new Test { Name = "Test2", Questions = questions2 });
        
        InitializeComponent();
        BindingContext = _testList;
    }

    private void ListViewOnItemTapped(object? sender, ItemTappedEventArgs e)
    {
        Navigation.PushAsync(new TestPage(_testList.TestListViewData[e.ItemIndex]));
    }
}