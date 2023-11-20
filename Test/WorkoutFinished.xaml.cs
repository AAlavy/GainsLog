using System;
using System.IO;
using System.Text.Json;

namespace Test;

public partial class WorkoutFinished : ContentPage
{

    private string workoutTime;
    private WorkoutDay workout;
    private string note;
    public WorkoutFinished(string workoutTime, WorkoutDay workout)
    {
        InitializeComponent();
        this.workoutTime = workoutTime;
        this.workout = workout;

        DisplayWorkout();
    }

    private void DisplayWorkout()
    {
        WorkoutFinishedView.Children.Add(new Label
        {
            Text = workoutTime
        });

    }

    private void HandleNotesChanged(object sender, TextChangedEventArgs e)
    {
        note = e.NewTextValue;
    }

    private void AddToLogs()
    {
        string folderPath = Path.Combine(AppContext.BaseDirectory, "Resources/Logs");
        string fileName = DateTime.Now.ToString("ddMMyy_HHmmss");
        string filePath = Path.Combine(folderPath, fileName);

        Log logEntry = new();

        logEntry.note = note;
        logEntry.Workout = workout.Exercises;
        logEntry.date = DateTime.Today;
        logEntry.time = workoutTime;

        string json = JsonSerializer.Serialize(logEntry);

        using (FileStream fs = File.Create(filePath))
        {
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.Write(json);
            }
        }


        WorkoutFinishedView.Children.Add(new Label
        {
            Text = "Log successfully added"
        });

    }

    private void CloseButton(object sender, EventArgs e)
    {
        AddToLogs();
        Navigation.PopToRootAsync();
        return;
    }


}