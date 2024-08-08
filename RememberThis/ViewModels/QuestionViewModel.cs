using System.ComponentModel;
using System.Runtime.CompilerServices;

using RememberThis.Models;

namespace RememberThis.ViewModels;

public class QuestionViewModel(Question question) : INotifyPropertyChanged
{
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

    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}