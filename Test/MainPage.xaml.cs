namespace Test;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void StartWorkout(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new WorkoutDayPicker());
    }

    private async void ProgramsPageNav(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProgramsPage());
    }

    private async void LogNav(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LogPage());
    }

}

