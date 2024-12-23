using RememberThis.Services;
using RememberThis.ViewModels;

namespace RememberThis;

public partial class QuestionPage : ContentPage
{
    public double WidthScaling { get; } = PlatformProperties.WidthScaling;
    public double HeightScaling { get; } = PlatformProperties.HeightScaling;
    
    private readonly TestViewModel _testViewModel;
    private readonly QuestionViewModel _questionViewModel;
    
    public QuestionPage(TestViewModel testViewModel, QuestionViewModel questionViewModel)
    {
        InitializeComponent();
        _testViewModel = testViewModel;
        _questionViewModel = questionViewModel;
        BindingContext = _questionViewModel;
    }

    private void ButtonShowPromptOnClicked(object? sender, EventArgs e)
    {
        LabelPrompt1.IsVisible = true;
        LabelPrompt2.IsVisible = true;
        ButtonPrompt.IsEnabled = false;
    }

    private void ButtonCommitOnClicked(object? sender, EventArgs e)
    {
        CompareResult compareResult = _questionViewModel.CommitQuestion(Answer.Text ?? "");

        Answer.IsEnabled = false;

        if (compareResult == CompareResult.Correct)
            Answer.TextColor = Color.FromRgb(0, 255, 0);
        else if (compareResult == CompareResult.Almost)
            Answer.TextColor = Color.FromRgb(255, 165, 0);
        else if (compareResult == CompareResult.Incorrect)
            Answer.TextColor = Color.FromRgb(255, 0, 0);

        LabelAnswer2.IsVisible = true;
        ButtonPrompt.IsEnabled = false;
        ButtonCommit.IsEnabled = false;
        ButtonContinue.IsEnabled = true;
    }
    
    private async void ButtonContinueOnClicked(object? sender, EventArgs e)
    {
        var nextQuestionViewModel = _testViewModel.NextQuestion();
        if (nextQuestionViewModel == null)
        {
            await Navigation.PopAsync();
        }
        else await Navigation.PushAsync(new QuestionPage(_testViewModel, nextQuestionViewModel));
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        if (Navigation.NavigationStack.Count == 4)
            Navigation.RemovePage(Navigation.NavigationStack[2]);
    }
}