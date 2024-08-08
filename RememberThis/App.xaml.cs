namespace RememberThis;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new MainMenu();
    }
}