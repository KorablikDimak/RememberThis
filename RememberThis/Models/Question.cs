namespace RememberThis.Models;

public class Question
{
    public const int PROGRESS_LIMIT = 100;
    public string Problem { get; set; } = "";
    public string Prompt { get; set; } = "";
    public string ImageName { get; set; } = "";
    public string Answer { get; set; } = "";

    private int _progress;
    public int Progress
    {
        get => _progress;
        set
        {
            _progress = value switch
            {
                <= 0 => 0,
                >= PROGRESS_LIMIT => PROGRESS_LIMIT,
                _ => value
            };
        }
    }
}