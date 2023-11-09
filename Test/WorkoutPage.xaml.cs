using System.Text.Json;

namespace Test;

public partial class WorkoutPage : ContentPage
{
    private WorkoutProgram program;
    private static System.Timers.Timer workoutTimer;
    private static bool workoutStarted = false;
    private TimeSpan elapsedTime;

    public WorkoutPage()
    {
        InitializeComponent();
        StartTimer();
        DisplayProgram();
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

    private void DisplayProgram()
    {

        if (Preferences.ContainsKey("SelectedProgram"))
        {
            string json = File.ReadAllText(Preferences.Get("SelectedProgram", ""));
            program = JsonSerializer.Deserialize<WorkoutProgram>(json);

            WorkoutInProgress.Children.Add(new Label
            {
                Text = program.Name,
                TextColor = Color.FromRgb(0, 0, 0)
            });
        }
        else
        {
            throw new Exception("No program was selected");
        }
    }


    private void onStopWorkout(object sender, EventArgs args)
    {
        workoutTimer.Stop();
        workoutStarted = false;
    }
}