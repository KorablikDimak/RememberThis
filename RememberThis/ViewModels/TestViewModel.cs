using System.ComponentModel;
using System.Runtime.CompilerServices;

using RememberThis.Models;

namespace RememberThis.ViewModels;

public class TestViewModel(Test test) : INotifyPropertyChanged
{
    private readonly List<Question> _questions = test.Questions;
    private List<Question> _questionListViewData = test.Questions;
    private int _questionCount = test.Questions.Count;
    private bool _isActive;
    private readonly Queue<Question> _questionQueue = [];

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
    
    public List<Question> QuestionListViewData 
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

    public bool IsActive
    {
        get => _isActive;
        set
        {
            if (_isActive == value) return;
            _isActive = value;
            OnPropertyChanged();
        }
    }

    public void AddQuestion(Question question)
    {
        _questions.Add(question);
        QuestionCount = _questions.Count;
        QuestionListViewData = _questions.OrderBy(q => q.Problem).ToList();
        _questionQueue.Enqueue(question);
    }

    public void RemoveQuestion(Question question)
    {
        _questions.Remove(question);
        QuestionCount = _questions.Count;
        QuestionListViewData = _questions.OrderBy(q => q.Problem).ToList();
        _questionQueue.Clear();
    }
    
    public void RemoveQuestions(List<Question> questions)
    {
        foreach (var question in questions)
        {
            _questions.Remove(question);
        }
        
        QuestionCount = _questions.Count;
        QuestionListViewData = _questions.OrderBy(t => t.Problem).ToList();
        _questionQueue.Clear();
    }

    public Question? NextQuestion()
    {
        if (_questionQueue.Count != 0) return _questionQueue.Dequeue();
        
        foreach (var question in QuestionListViewData.Where(question => question.Progress < 100))
        {
            _questionQueue.Enqueue(question);
        }
        
        return _questionQueue.Count == 0 ? null : _questionQueue.Dequeue();
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}