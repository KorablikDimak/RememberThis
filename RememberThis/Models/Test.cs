namespace RememberThis.Models;

public class Test
{
    public string Name { get; set; } = "";
    public List<Question> Questions { get; init; } = [];
    public double Progress => (double) Questions.Select(question => question.Progress).Sum() / (Questions.Count * 100);
}