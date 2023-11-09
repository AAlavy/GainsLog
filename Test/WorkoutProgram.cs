
using System.Collections.Generic;

public class ProgramExercise
{
    public string Name { get; set; }
    public int Sets { get; set; }
    public int Reps { get; set; }
}

public class ProgramDay
{
    public string Day { get; set; }
    public List<ProgramExercise> Exercises { get; set; }
}

public class WorkoutProgram
{
    public string Name { get; set; }
    public List<ProgramDay> Days { get; set; }
}