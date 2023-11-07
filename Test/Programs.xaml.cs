using System.Text.Json;
using System.IO;
using Microsoft.Maui.Graphics;

namespace Test;

public partial class Programs : ContentPage
{
    public Programs()
    {
        InitializeComponent();
    }

    private void LoadPrograms()
    {
        string folderPath = Path.Combine(AppContext.BaseDirectory, "Resources/Programs");
        string[] files = Directory.GetFiles(folderPath);
        foreach (string file in files)
        {
            string json = File.ReadAllText(file);
            Program program = JsonSerializer.Deserialize<Program>(json);
            ProgramGrid.Children.Add(new Label { 
                Text = program.Name,
                Grid.row = 
            });

        }
    }
}