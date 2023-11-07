namespace Test;
using System.IO;
using System.Reflection;
using System.Text.Json;

public partial class CreateProgramPage : ContentPage
{
    public CreateProgramPage()
    {
        InitializeComponent();
        LoadExercises();
    }

    private void LoadExercises()
    {
        var filePath = Path.Combine(AppContext.BaseDirectory, "Resources/Programs/Exercises.json");
        string json = File.ReadAllText(filePath);
        ExerciseList exerciseList = JsonSerializer.Deserialize<ExerciseList>(json);
        List<Exercise> exercises = exerciseList.Exercises;

        foreach (Exercise exercise in exercises)
        {
            Layout.Children.Add(new Label
            {
                Text = exercise.Name
            });
        }
    }

    private void OnDrag(object sender, DragStartingEventArgs e)
    {
        e.Data.Properties.Add("Frame", myFrame);
    }

    private void OnDrop(object sender, DropEventArgs e)
    {
        if (e.Data.Properties.ContainsKey("Frame"))
        {
            var frame = e.Data.Properties["Frame"] as Frame;
            myDropTarget.Content = frame.Content;
        }
    }
}