using RememberThis.Models;
using RememberThis.Services;
using RememberThis.ViewModels;
using static System.Net.Mime.MediaTypeNames;

namespace RememberThis;

public partial class TestPage : ContentPage
{
    public double WidthScaling { get; } = PlatformProperties.WidthScaling;
    public double HeightScaling { get; } = PlatformProperties.HeightScaling;
    
    private readonly TestViewModel _test;
    
    public TestPage(Test test)
    {
        InitializeComponent();
        _test = new TestViewModel(test);
        BindingContext = _test;
    }

    private async void ListViewOnItemTapped(object? sender, ItemTappedEventArgs e)
    {
        await Navigation.PushAsync(new EditQuestionPage(_test.QuestionListViewData[e.ItemIndex]));
    }
    
    private async void ButtonAddQuestionOnClicked(object? sender, EventArgs e)
    {
        Question question = new();
        await Navigation.PushAsync(new EditQuestionPage(question));
        _test.AddQuestion(question);
    }
    
    private async void ButtonRemoveQuestionsOnClicked(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(new DeleteQuestionsPage(_test));
    }

    private async void ButtonStartOnClicked(object? sender, EventArgs e)
    {
        if (Math.Abs(_test.Progress - 1) < 0.01)
            _test.Restart();

        var question = _test.NextQuestion();
        if (question == null) return;
        _test.IsActive = true;
        await Navigation.PushAsync(new QuestionPage(_test, question));
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        StartButton.Text = Math.Abs(_test.Progress - 1) < 0.01 ? "Повторить" : "Начать";
    }
}