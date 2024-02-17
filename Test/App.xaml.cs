namespace Test;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        CreateMenu();

        MainPage = new AppShell();
    }

    private void CreateMenu()
    {
        new Button
        {
            Text = "Create program",
            BackgroundColor = Color.FromRgb(0, 0, 0),
            TextColor = Color.FromRgb(255, 255, 255)
        };
    }
}
