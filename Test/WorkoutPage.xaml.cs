namespace Test;

public partial class WorkoutPage : ContentPage
{

    private static System.Timers.Timer workoutTimer;
    private static bool workoutStarted = false;
    private TimeSpan elapsedTime;

    public WorkoutPage()
    {
        InitializeComponent();
        StartTimer();
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

    private void onStopWorkout(object sender, EventArgs args)
    {
        workoutTimer.Stop();
        workoutStarted = false;
    }
}