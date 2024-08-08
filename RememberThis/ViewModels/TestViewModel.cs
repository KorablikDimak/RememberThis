using System.ComponentModel;
using System.Runtime.CompilerServices;

using RememberThis.Models;

namespace RememberThis.ViewModels;

public class TestViewModel(Test test) : INotifyPropertyChanged
{
    private List<Question> _questionListViewData = test.Questions;
    private int _questionCount = test.Questions.Count;

    public string Name
    {
        get => test.Name;
        set
        {
            if (test.Name == value) return;
            test.Name = value;
            OnPropertyChanged();
        } 
    }
    
    public List<Question> TestListViewData 
    {
        get => _questionListViewData;
        set
        {
            _questionListViewData = value;
            OnPropertyChanged();
        }
    }
    
    public int QuestionCount
    {
        get => _questionCount;
        set
        {
            if (_questionCount == value) return;
            _questionCount = value;
            OnPropertyChanged();
        }
    }

    public void AddQuestion(Question question)
    {
        test.Questions.Add(question);
        QuestionCount = test.Questions.Count;
    }

    public void RemoveQuestion(Question question)
    {
        test.Questions.Remove(question);
        QuestionCount = test.Questions.Count;
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}