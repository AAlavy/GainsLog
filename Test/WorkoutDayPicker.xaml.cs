using System.Text.Json;

namespace Test;

public partial class WorkoutDayPicker : ContentPage
{
    private WorkoutProgram workoutProgram;
    public WorkoutDayPicker()
    {
        InitializeComponent();
        LoadProgram();
    }

    private void LoadProgram()
    {
        if (Preferences.ContainsKey("SelectedProgram"))
        {
            string json = File.ReadAllText(Preferences.Get("SelectedProgram", ""));
            workoutProgram = JsonSerializer.Deserialize<WorkoutProgram>(json);

            foreach (WorkoutDay day in workoutProgram.Days)
            {
                AddDayButton(day);
            }
        }
        else
        {
            throw new Exception("No program was selected");
        }
    }

    private void AddDayButton(WorkoutDay day)
    {

        Button dayButton = new Button
        {
            Text = day.Day
        };

        dayButton.Clicked += (s, e) => DaySelected(s, e, day);
        WorkoutDayView.Children.Add(dayButton);
    }

    private async void DaySelected(object sender, EventArgs e, WorkoutDay day)
    {
        await Navigation.PushAsync(new WorkoutPage(day));
    }
}