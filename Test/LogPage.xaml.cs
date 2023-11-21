using System.Text.Json;

namespace Test;

public partial class LogPage : ContentPage
{
    public LogPage()
    {
        InitializeComponent();
        LoadLogs();
    }

    private void LoadLogs()
    {
        string folderPath = Path.Combine(AppContext.BaseDirectory, "Resources/Logs");
        string[] files = Directory.GetFiles(folderPath);

        foreach (string file in files)
        {
            string json = File.ReadAllText(file);
            Log logEntry = JsonSerializer.Deserialize<Log>(json);

            LogView.Children.Add(new Label
            {
                Text = logEntry.Date.ToString(),
                TextColor = Color.FromRgb(0, 0, 0)
            });

        }
    }
}