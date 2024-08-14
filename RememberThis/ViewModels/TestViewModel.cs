using System.ComponentModel;
using System.Runtime.CompilerServices;

using RememberThis.Models;

namespace RememberThis.ViewModels;

public class TestViewModel(Test test) : INotifyPropertyChanged
{
    private List<Question> _questionListViewData = test.Questions;
    private int _questionCount = test.Questions.Count;
    private bool _isActive;
    private readonly Queue<Question> _questionQueue = [];
    private double _progress;

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

    public double Progress
    {
        get => test.Progress;
        private set
        {
            if (Math.Abs(_progress - value) < 0.001) return;
            _progress = value;
            OnPropertyChanged();
        }
    }

    public void AddQuestion(Question question)
    {
        test.Questions.Add(question);
        QuestionCount = test.Questions.Count;
        QuestionListViewData = test.Questions.OrderBy(q => q.Problem).ToList();
        _questionQueue.Enqueue(question);
        Progress = test.Progress;
    }

    public void RemoveQuestion(Question question)
    {
        test.Questions.Remove(question);
        QuestionCount = test.Questions.Count;
        QuestionListViewData = test.Questions.OrderBy(q => q.Problem).ToList();
        _questionQueue.Clear();
        Progress = test.Progress;
    }
    
    public void RemoveQuestions(List<Question> questions)
    {
        foreach (var question in questions)
        {
            test.Questions.Remove(question);
        }
        
        QuestionCount = test.Questions.Count;
        QuestionListViewData = test.Questions.OrderBy(t => t.Problem).ToList();
        _questionQueue.Clear();
        Progress = test.Progress;
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

    public bool CommitQuestion(Question question, string answer)
    {
        if (question.Answer == answer)
        {
            question.Progress += 20;
            Progress = test.Progress;
            return true;
        }
        else
        {
            question.Progress -= 20;
            Progress = test.Progress;
            return false;
        }
    }

    public void Restart()
    {
        foreach (var question in test.Questions)
            question.Progress = 0;

        QuestionCount = test.Questions.Count;
        QuestionListViewData = test.Questions.OrderBy(t => t.Problem).ToList();
        _questionQueue.Clear();
        Progress = test.Progress;
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}