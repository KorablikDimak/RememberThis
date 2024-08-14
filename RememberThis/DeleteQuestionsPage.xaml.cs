using RememberThis.Services;
using RememberThis.ViewModels;

namespace RememberThis;

public partial class DeleteQuestionsPage : ContentPage
{
    public double WidthScaling { get; } = PlatformProperties.WidthScaling;
    public double HeightScaling { get; } = PlatformProperties.HeightScaling;
    
    private readonly TestViewModel _test;
    
    public DeleteQuestionsPage(TestViewModel testList)
    {
        InitializeComponent();
        _test = testList;
        BindingContext = _test;
    }

    private async void ButtonRemoveOnClicked(object? sender, EventArgs e)
    {
        _test.RemoveQuestions(_test.QuestionListViewData.Where(question => question.IsChecked).ToList());
        await Navigation.PopAsync();
    }
}