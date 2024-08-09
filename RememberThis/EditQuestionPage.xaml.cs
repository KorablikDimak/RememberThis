using RememberThis.Models;
using RememberThis.ViewModels;

namespace RememberThis;

public partial class EditQuestionPage : ContentPage
{
    private readonly QuestionViewModel _question;
    
    public EditQuestionPage(Question question)
    {
        InitializeComponent();
        _question = new QuestionViewModel(question);
        BindingContext = _question;
    }
}