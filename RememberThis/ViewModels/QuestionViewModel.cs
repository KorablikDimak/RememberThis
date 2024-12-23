using System.ComponentModel;
using System.Runtime.CompilerServices;

using RememberThis.Models;
using RememberThis.Services;

namespace RememberThis.ViewModels;

public enum CompareResult
{
    Correct,
    Almost,
    Incorrect
}

public class QuestionViewModel(Question question) : INotifyPropertyChanged
{
    public Question Question { get => question; }

    public string Problem
    {
        get => question.Problem;
        set
        {
            if (question.Problem == value) return;
            question.Problem = value;
            OnPropertyChanged();
        }
    }
    
    public string Prompt
    {
        get => question.Prompt;
        set
        {
            if (question.Prompt == value) return;
            question.Prompt = value;
            OnPropertyChanged();
        }
    }
    
    public string ImageName
    {
        get => question.ImageName;
        set
        {
            if (question.ImageName == value) return;
            question.ImageName = value;
            OnPropertyChanged();
        }
    }
    
    public string Answer
    {
        get => question.Answer;
        set
        {
            if (question.Answer == value) return;
            question.Answer = value;
            OnPropertyChanged();
        }
    }
    
    public int Progress
    {
        get => question.Progress;
        set
        {
            if (question.Progress == value) return;
            question.Progress = value;
            OnPropertyChanged();
        }
    }

    private const int Factor = 20;

    private bool _promptIsVisible;
    public bool PromptIsVisible
    {
        get => _promptIsVisible;
        set => _promptIsVisible = value;
    }

    public CompareResult CommitQuestion(string answer)
    {
        var compareResult = Tokenizer.CompareStrings(Answer.ToLower(), answer.ToLower());

        if (compareResult == 1)
        {
            if (_promptIsVisible)
                Progress += (int) (Factor * 0.5);
            else
                Progress += Factor;

            return CompareResult.Correct;
        }
        else if (compareResult >= 0.5)
        {
            if (_promptIsVisible)
                Progress += (int) (compareResult * Factor * 0.25);
            else
                Progress += (int) (compareResult * Factor * 0.5);

            return CompareResult.Almost;
        }
        else
        {
            if (_promptIsVisible)
                Progress += (int) (compareResult * Factor * 0.25 - Factor);
            else
                Progress += (int) (compareResult * Factor * 0.5 - Factor);

            return CompareResult.Incorrect;
        }
    }

    private bool _isChecked;
    public bool IsChecked
    {
        get => _isChecked;
        set => _isChecked = value;
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}