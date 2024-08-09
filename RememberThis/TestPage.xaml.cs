using RememberThis.Models;
using RememberThis.ViewModels;

namespace RememberThis;

public partial class TestPage : ContentPage
{
    private readonly TestViewModel _test;
    
    public TestPage(Test test)
    {
        InitializeComponent();
        _test = new TestViewModel(test);
        BindingContext = _test;
    }

    private void ListViewOnItemTapped(object? sender, ItemTappedEventArgs e)
    {
        Navigation.PushAsync(new EditQuestionPage(_test.QuestionListViewData[e.ItemIndex]));
    }
    
    private void ButtonAddQuestionOnClicked(object? sender, EventArgs e)
    {
        var question = new Question { Problem = "Question" };
        _test.AddQuestion(question);
        Navigation.PushAsync(new EditQuestionPage(question));
    }
    
    private void ButtonRemoveQuestionsOnClicked(object? sender, EventArgs e)
    {
        Navigation.PushAsync(new DeleteQuestionsPage(_test));
    }

    private void ButtonStartOnClicked(object? sender, EventArgs e)
    {
        var question = _test.NextQuestion();
        if (question == null) return; // TODO alert
        _test.IsActive = true;
        Navigation.PushAsync(new QuestionPage(_test, question));
    }
}