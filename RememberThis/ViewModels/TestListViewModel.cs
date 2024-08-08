﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

using RememberThis.Models;

namespace RememberThis.ViewModels;

public class TestListViewModel : INotifyPropertyChanged
{
    private readonly List<Test> _tests = [];
    private List<Test> _testListViewData = [];
    private int _testsCount;
    
    public List<Test> TestListViewData 
    {
        get => _testListViewData;
        set
        {
            _testListViewData = value;
            OnPropertyChanged();
        }
    }
    
    public int TestCount
    {
        get => _testsCount;
        set
        {
            if (_testsCount == value) return;
            _testsCount = value;
            OnPropertyChanged();
        }
    }
    
    public void AddTest(Test question)
    {
        _tests.Add(question);
        TestCount = _tests.Count;
        TestListViewData = _tests.OrderBy(test => test.Progress).ToList();
    }

    public void RemoveTest(Test question)
    {
        _tests.Remove(question);
        TestCount = _tests.Count;
        TestListViewData = _tests.OrderBy(test => test.Progress).ToList();
    }
    
    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}