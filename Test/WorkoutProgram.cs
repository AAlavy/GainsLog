public class WorkoutExercise
{
    public string Name { get; set; }
    public int Sets { get; set; }
    public int Reps { get; set; }
}

public class WorkoutDay
{
    public string Day { get; set; }
    public List<WorkoutExercise> Exercises { get; set; }
}

public class WorkoutProgram
{
    public string Name { get; set; }
    public List<WorkoutDay> Days { get; set; }
}