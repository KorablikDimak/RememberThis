using System.ComponentModel;
using System.Runtime.CompilerServices;

using RememberThis.Models;

namespace RememberThis.ViewModels;

public class TestViewModel(Test test) : INotifyPropertyChanged
{
    public Test Test { get => test; }

    private List<QuestionViewModel> _questionListViewData = test.Questions.Select(question => new QuestionViewModel(question)).ToList();
    public List<QuestionViewModel> QuestionListViewData
    {
        get => _questionListViewData;
        set
        {
            _questionListViewData = value;
            OnPropertyChanged();
        }
    }

    private bool _isActive;
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

    private bool _isChecked;
    public bool IsChecked
    {
        get => _isChecked;
        set
        {
            if (_isChecked == value) return;
            _isChecked = value;
            OnPropertyChanged();
        }
    }

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

    private int _questionCount;
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

    private double _progress;
    public double Progress
    {
        get => _progress;
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
        Update();
    }
    
    public void AddQuestions(List<Question> questions)
    {
        test.Questions.AddRange(questions);
        Update();
    }

    public void RemoveQuestion(Question question)
    {
        test.Questions.Remove(question);
        Update();
    }
    
    public void RemoveQuestions(List<Question> questions)
    {
        foreach (var question in questions)
            test.Questions.Remove(question);
        Update();
    }

    private readonly Queue<QuestionViewModel> _questionQueue = [];
    public QuestionViewModel? NextQuestion()
    {
        if (_questionQueue.Count != 0) 
            return _questionQueue.Dequeue();
        
        foreach (var question in test.Questions
            .Where(question => question.Progress < 100)
            .OrderBy(t => new Random().Next(1, QuestionCount))
            .Select(question => new QuestionViewModel(question)))
        {
            _questionQueue.Enqueue(question);
        }
            
        return _questionQueue.Count == 0 ? null : _questionQueue.Dequeue();
    }

    public void Restart()
    {
        foreach (var question in test.Questions)
            question.Progress = 0;
        Update();
    }

    public void Update()
    {
        _questionQueue.Clear();
        QuestionListViewData = test.Questions.Select(question => new QuestionViewModel(question)).ToList();
        QuestionCount = test.Questions.Count;
        Progress = test.Progress;
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}