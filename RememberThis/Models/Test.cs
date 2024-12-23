namespace RememberThis.Models;

public class Test
{
    public string Name { get; set; } = "";
    public List<Question> Questions { get; init; } = [];
    public double Progress
    {
        get
        {
            if (Questions.Count == 0) return 0;
            return double.Round((double) Questions.Select(question => question.Progress).Sum() / (Questions.Count * Question.PROGRESS_LIMIT), 3);
        }
    }
}