namespace Test;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void onStartWorkout(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new WorkoutPage());
    }

    private async void onProgramsPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProgramsPage());
    }

}

