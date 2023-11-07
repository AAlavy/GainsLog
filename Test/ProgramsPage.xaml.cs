namespace Test;

public partial class ProgramsPage : ContentPage
{
	public ProgramsPage()
	{
		InitializeComponent();
	}

    private async void onPrograms(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Programs());
    }

    private async void onCreateProgram(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CreateProgramPage());
    }
}