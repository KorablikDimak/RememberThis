using RememberThis.Models;
using RememberThis.Services;
using RememberThis.ViewModels;

namespace RememberThis;

public partial class EditQuestionPage : ContentPage
{
    public double WidthScaling { get; } = PlatformProperties.WidthScaling;
    public double HeightScaling { get; } = PlatformProperties.HeightScaling;
    
    private readonly QuestionViewModel _question;
    
    public EditQuestionPage(Question question)
    {
        InitializeComponent();
        _question = new QuestionViewModel(question);
        BindingContext = _question;
    }

    private async void ButtonSelectImageOnClicked(object? sender, EventArgs e)
    {
        var result = await FilePicker.Default.PickAsync();
        if (result == null) return;

        if (!result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) &&
            !result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase)) return;

        _question.ImageName = result.FullPath;
        DeleteImageButton.IsEnabled = true;
    }

    private void ButtonDeleteImageOnClicked(object? sender, EventArgs e)
    {
        _question.ImageName = "";
        DeleteImageButton.IsEnabled = false;
    }

    private async void ButtonSaveOnClicked(object? sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}