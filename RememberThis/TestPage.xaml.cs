using RememberThis.Models;
using RememberThis.Services;
using RememberThis.ViewModels;

namespace RememberThis;

public partial class TestPage : ContentPage
{
    public double WidthScaling { get; } = PlatformProperties.WidthScaling;
    public double HeightScaling { get; } = PlatformProperties.HeightScaling;
    
    private readonly TestViewModel _testViewModel;
    
    public TestPage(TestViewModel testViewModel)
    {
        InitializeComponent();
        _testViewModel = testViewModel;
        BindingContext = _testViewModel;
    }

    private async void ListViewOnItemTapped(object? sender, ItemTappedEventArgs e)
    {
        await Navigation.PushAsync(new EditQuestionPage(_testViewModel.QuestionListViewData[e.ItemIndex]));
    }
    
    private async void ButtonAddQuestionOnClicked(object? sender, EventArgs e)
    {
        Question question = new();
        await Navigation.PushAsync(new EditQuestionPage(new QuestionViewModel(question)));
        _testViewModel.AddQuestion(question);
    }
    
    private async void ButtonRemoveQuestionsOnClicked(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(new DeleteQuestionsPage(_testViewModel));
    }

    private async void ButtonStartOnClicked(object? sender, EventArgs e)
    {
        if (Math.Abs(_testViewModel.Progress - 1) < 0.01)
            _testViewModel.Restart();

        var questionViewModel = _testViewModel.NextQuestion();
        if (questionViewModel == null) return;
        _testViewModel.IsActive = true;
        await Navigation.PushAsync(new QuestionPage(_testViewModel, questionViewModel));
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        StartButton.Text = Math.Abs(_testViewModel.Progress - 1) < 0.01 ? "Повторить" : "Начать";
        _testViewModel.Update();
    }
}