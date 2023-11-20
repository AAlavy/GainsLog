using Microsoft.Maui.Controls;
using System.Text.Json;

namespace Test;

public partial class WorkoutPage : ContentPage
{
    private WorkoutProgram workoutProgram;
    private static System.Timers.Timer workoutTimer;
    private static bool workoutStarted = false;
    private TimeSpan elapsedTime;
    private WorkoutDay day;

    private int currentExerciseIndex;
    private int currentSetIndex;

    private bool resting;

    private TapGestureRecognizer screenTapped = new TapGestureRecognizer();

    public WorkoutPage(WorkoutDay day)
    {
        this.day = day;

        InitializeComponent();
        StartTimer();
        LoadProgram();
        DisplayCurrentSet();
    }

    private void LoadProgram()
    {
        if (Preferences.ContainsKey("SelectedProgram"))
        {
            string json = File.ReadAllText(Preferences.Get("SelectedProgram", ""));
            workoutProgram = JsonSerializer.Deserialize<WorkoutProgram>(json);

            WorkoutView.Children.Add(new Label
            {
                Text = workoutProgram.Name,
                TextColor = Color.FromRgb(0, 0, 0)
            });
        }
        else
        {
            throw new Exception("No program was selected");
        }
    }

    private void StartTimer()
    {
        if (!workoutStarted)
        {
            workoutTimer = new System.Timers.Timer();
            workoutTimer.Interval = 1000;
            workoutTimer.Elapsed += (s, args) =>
            {
                elapsedTime = elapsedTime.Add(TimeSpan.FromSeconds(1));
                this.Dispatcher.Dispatch(() =>
                {
                    workoutTimerDisplay.Text = elapsedTime.ToString(@"hh\:mm\:ss");
                });
            };
            workoutTimer.Start();
            workoutStarted = true;
        }
    }

    private void DisplayCurrentSet()
    {
        WorkoutExercise currentExercise = day.Exercises[currentExerciseIndex];
        int currentSetNumber = currentSetIndex + 1;

        setLabel.Text = $"{currentExercise.Name} - Set {currentSetNumber} / {currentExercise.Sets}";
        restTimerLabel.Text = "Tap to start rest";
        nextLabel.Text = $"Next exercise: {day.Exercises[currentExerciseIndex + 1].Name}";

        screenTapped.Tapped += (s, e) =>
        {
            if (!resting)
            {
                StartRest();
            }
        };

        WorkoutView.GestureRecognizers.Add(screenTapped);
    }

    private void StartNextSet()
    {

        WorkoutExercise currentExercise = day.Exercises[currentExerciseIndex];

        // Start the next set for the current exercise
        if (currentSetIndex < currentExercise.Sets - 1)
        {
            currentSetIndex++;
        }
        // Move to the next exercise
        else if (currentExerciseIndex < day.Exercises.Count - 1)
        {
            currentExerciseIndex++;
            currentSetIndex = 0;
        }
        // Workout finished
        else
        {
            workoutTimer.Stop();
            Navigation.PopAsync();
            return;
        }

        resting = false;
        DisplayCurrentSet();

    }

    private async void StartRest()
    {
        resting = true;

        int restDuration = 10;

        for (int i = restDuration; i >= 0; i--)
        {
            restTimerLabel.Text = $"Rest: {i} seconds";
            await Task.Delay(1000);
        }

        StartNextSet();
    }

    private void StopWorkout(object sender, EventArgs args)
    {
        workoutTimer.Stop();
        workoutStarted = false;

        WorkoutFinished();
    }

    private async void WorkoutFinished()
    {
        await Navigation.PushAsync(new WorkoutFinished(elapsedTime.ToString(@"hh\:mm\:ss"), day));
    }
}