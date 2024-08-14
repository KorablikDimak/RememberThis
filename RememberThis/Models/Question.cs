namespace RememberThis.Models;

public class Question
{
    public string Problem { get; set; } = "";
    public string Prompt { get; set; } = "";
    public string ImageName { get; set; } = "";
    public string Answer { get; set; } = "";
    public bool IsChecked { get; set; }

    private int _progress;
    public int Progress
    {
        get => _progress;
        set
        {
            _progress = value switch
            {
                <= 0 => 0,
                >= 100 => 100,
                _ => value
            };
        }
    }
}