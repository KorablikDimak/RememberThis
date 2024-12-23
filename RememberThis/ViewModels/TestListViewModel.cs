using System.ComponentModel;
using System.Runtime.CompilerServices;

using RememberThis.Models;

namespace RememberThis.ViewModels;

public class TestListViewModel(List<Test> tests) : INotifyPropertyChanged
{
    public List<Test> Tests {  get => tests; }

    private List<TestViewModel> _testsView = tests.Select(test => new TestViewModel(test)).ToList();
    public List<TestViewModel> TestListViewData
    {
        get => _testsView;
        private set
        {
            _testsView = value;
            OnPropertyChanged();
        }
    }
    
    public List<TestViewModel> ActiveTestListViewData
    {
        get => _testsView.Where(test => test.Progress < 100).ToList();
    }
    
    public List<TestViewModel> CompletedTestListViewData
    {
        get => _testsView.Where(test => test.Progress == 100).ToList();
    }
    
    public void AddTest(Test test)
    {
        tests.Add(test);
        Update();
    }

    public void AddTests(List<Test> testsForAdd)
    {
        tests.AddRange(testsForAdd);
        Update();
    }

    public void RemoveTest(Test test)
    {
        tests.Remove(test);
        Update();
    }

    public void RemoveTests(List<Test> testsForDelete)
    {
        foreach (var test in testsForDelete)
            tests.Remove(test);
        Update();
    }

    public void Update()
    {
        TestListViewData = tests.Select(test => new TestViewModel(test)).ToList();
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}