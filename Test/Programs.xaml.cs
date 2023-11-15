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

        int row = 0;
        int col = 0;

        foreach (string file in files)
        {
            string json = File.ReadAllText(file);
            WorkoutProgram program = JsonSerializer.Deserialize<WorkoutProgram>(json);

            Frame workoutFrame = new Frame
            {
                BorderColor = Color.FromRgb(255, 255, 255),
                BackgroundColor = Color.FromRgb(0, 0, 0),
                CornerRadius = 10,
                HeightRequest = 100,
                WidthRequest = 100,

            };
            workoutFrame.Content = (new Label
            {
                Text = program.Name
            });

            Grid.SetRow(workoutFrame, row);
            Grid.SetColumn(workoutFrame, col);

            var programTap = new TapGestureRecognizer();
            programTap.Tapped += (s, e) =>
            {
                showProgram(s, e, program, file);
            };

            workoutFrame.GestureRecognizers.Add(programTap);

            ProgramGrid.Children.Add(workoutFrame);

            col++;
            if (col == ProgramGrid.ColumnDefinitions.Count)
            {
                col = 0;
                row++;
            }

        }
    }

    private async void showProgram(object sender, EventArgs e, WorkoutProgram program, string programPath)
    {
        await Navigation.PushAsync(new ProgramView(program, programPath));
    }

}