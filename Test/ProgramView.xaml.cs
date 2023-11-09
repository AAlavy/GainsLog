namespace Test;

public partial class ProgramView : ContentPage
{

    private WorkoutProgram program;
    public ProgramView()
    {
        InitializeComponent();
    }

    public ProgramView(WorkoutProgram program)
    {
        InitializeComponent();

        this.program = program;

        LoadProgram();
    }

    private void LoadProgram()
    {
        foreach (ProgramDay day in program.Days)
        {
            ViewProgram.Children.Add(new Label
            {
                Text = day.Day,
                TextColor = Color.FromRgb(0, 0, 0)

            });
            foreach (ProgramExercise exercise in day.Exercises)
            {
                ViewProgram.Children.Add(new Label
                {
                    Text = exercise.Name,
                    TextColor = Color.FromRgb(0, 0, 0)
                });
            }
        }
    }
}