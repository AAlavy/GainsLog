
using System.Collections.Generic;

public class Exercise
{
    public string Name { get; set; }
    public int Sets { get; set; }
    public int Reps { get; set; }
}

public class Days
{
    public string Day { get; set; }
    public List<Exercise> Exercises { get; set; }
}

public class WorkoutProgram
{
    public string Name { get; set; }
    public List<Days> Days { get; set; }
}