using RememberThis.Models;
using RememberThis.Services;
using RememberThis.ViewModels;

namespace RememberThis;

public partial class QuestionPage : ContentPage
{
    public double WidthScaling { get; } = PlatformProperties.WidthScaling;
    public double HeightScaling { get; } = PlatformProperties.HeightScaling;
    
    private readonly TestViewModel _test;
    private readonly Question _question;
    
    public QuestionPage(TestViewModel test, Question question)
    {
        InitializeComponent();
        _test = test;
        _question = question;
        BindingContext = _question;
    }

    private void ButtonShowPromptOnClicked(object? sender, EventArgs e)
    {
        LabelPrompt1.IsVisible = true;
        LabelPrompt2.IsVisible = true;
        ButtonPrompt.IsEnabled = false;
    }

    private void ButtonCommitOnClicked(object? sender, EventArgs e)
    {
        _test.CommitQuestion(_question, Answer.Text);

        Answer.IsEnabled = false;
        LabelAnswer2.IsVisible = true;
        ButtonPrompt.IsEnabled = false;
        ButtonCommit.IsEnabled = false;
        ButtonContinue.IsEnabled = true;
    }
    
    private async void ButtonContinueOnClicked(object? sender, EventArgs e)
    {
        var nextQuestion = _test.NextQuestion();
        if (nextQuestion == null)
        {
            await Navigation.PopAsync();
        }
        else await Navigation.PushAsync(new QuestionPage(_test, nextQuestion));
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        if (Navigation.NavigationStack.Count == 4)
            Navigation.RemovePage(Navigation.NavigationStack[2]);
    }
}