using RememberThis.Models;
using RememberThis.ViewModels;

namespace RememberThis;

public partial class DeleteQuestionsPage : ContentPage
{
    private readonly TestViewModel _test;
    
    public DeleteQuestionsPage(TestViewModel testList)
    {
        InitializeComponent();
        _test = testList;
        BindingContext = _test;
    }

    private void ButtonRemoveOnClicked(object? sender, EventArgs e)
    {
        _test.RemoveQuestions(QuestionListView.SelectedItems.Select(question => question as Question ?? new Question()).ToList());
        Navigation.PopAsync();
    }
}