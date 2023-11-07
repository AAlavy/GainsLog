using System.Diagnostics;
using System.Text.Json;

namespace Test;

public partial class Programs : ContentPage
{
    public Programs()
    {
        InitializeComponent();
        LoadPrograms();
    }

    private void LoadPrograms()
    {
        string folderPath = Path.Combine(AppContext.BaseDirectory, "Resources/Programs");
        string[] files = Directory.GetFiles(folderPath);
        foreach (string file in files)
        {
            string json = File.ReadAllText(file);
            WorkoutProgram program = JsonSerializer.Deserialize<WorkoutProgram>(json);
            ProgramGrid.Children.Add(new Label { 
                Text = program.Name
            });

        }
    }
}