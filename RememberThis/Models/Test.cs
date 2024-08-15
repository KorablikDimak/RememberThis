namespace RememberThis.Models;

public class Test
{
    public string Name { get; set; } = "";
    public List<Question> Questions { get; } = [];
    public bool IsChecked { get; set; }
    public double Progress
    {
        get
        {
            if (Questions.Count == 0) return 0;
            return double.Round((double) Questions.Select(question => question.Progress).Sum() / (Questions.Count * 100), 3);
        }
    }
}