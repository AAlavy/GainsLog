namespace Test;

public partial class ProgramView : ContentPage
{

    private WorkoutProgram program;
    private string programPath;
    public ProgramView()
    {
        InitializeComponent();
    }

    public ProgramView(WorkoutProgram program, string programPath)
    {
        InitializeComponent();

        this.program = program;
        this.programPath = programPath;

        LoadProgram();
    }

    private void LoadProgram()
    {
        foreach (WorkoutDay day in program.Days)
        {
            ViewProgram.Children.Add(new Label
            {
                Text = day.Day,
                TextColor = Color.FromRgb(0, 0, 0)

            });
            foreach (WorkoutExercise exercise in day.Exercises)
            {
                ViewProgram.Children.Add(new Label
                {
                    Text = exercise.Name,
                    TextColor = Color.FromRgb(0, 0, 0)
                });
            }
        }
    }

    private void SelectProgram(object sender, EventArgs e)
    {
        Preferences.Set("SelectedProgram", programPath);
    }
}