using System.ComponentModel;
using System.Runtime.CompilerServices;

using RememberThis.Models;

namespace RememberThis.ViewModels;

public class TestListViewModel : INotifyPropertyChanged
{
    private readonly List<Test> _tests;
    private List<Test> _testListViewData = [];
    private List<Test> _activeTestListViewData = [];
    private List<Test> _completedTestListViewData = [];
    private int _testsCount;

    public TestListViewModel(List<Test> tests)
    {
        _tests = tests;
        Update();
    }
    
    public List<Test> TestListViewData 
    {
        get => _testListViewData;
        private set
        {
            _testListViewData = value;
            OnPropertyChanged();
        }
    }
    
    public List<Test> ActiveTestListViewData
    {
        get => _activeTestListViewData;
        private set
        {
            _activeTestListViewData = value;
            OnPropertyChanged();
        }
    }
    
    public List<Test> CompletedTestListViewData
    {
        get => _completedTestListViewData;
        private set
        {
            _completedTestListViewData = value;
            OnPropertyChanged();
        }
    }
    
    public int TestCount
    {
        set
        {
            if (_testsCount == value) return;
            _testsCount = value;
            OnPropertyChanged();
        }
    }
    
    public void AddTest(Test test)
    {
        _tests.Add(test);
        Update();
    }

    public void AddTests(List<Test> tests)
    {
        _tests.AddRange(tests);
        Update();
    }

    public void RemoveTest(Test test)
    {
        _tests.Remove(test);
        Update();
    }

    public void RemoveTests(List<Test> tests)
    {
        foreach (var test in tests)
            _tests.Remove(test);
        Update();
    }

    public void Update()
    {
        TestCount = _tests.Count;
        TestListViewData = _tests.OrderBy(t => t.Progress).ToList();
        ActiveTestListViewData = _tests.Where(t => t.Progress < 1).OrderBy(t => t.Progress).ToList();
        CompletedTestListViewData = _tests.Where(t => Math.Abs(t.Progress - 1) < 0.01).OrderBy(t => t.Progress).ToList();
    }
    
    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}