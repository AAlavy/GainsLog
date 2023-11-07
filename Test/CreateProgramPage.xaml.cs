namespace Test;
using System.IO;
using System.Reflection;
using System.Text.Json;

public partial class CreateProgramPage : ContentPage
{ 
    ExerciseViewModel pickerModel;
    ExerciseViewModel viewModel;
    List<Exercise> exercises;
    string selectedDate;

    public CreateProgramPage()
    {
        InitializeComponent();
        LoadExercises();
    }

    private void LoadExercises()
    {
        var filePath = Path.Combine(AppContext.BaseDirectory, "Resources/Exercises/Exercises.json");
        string json = File.ReadAllText(filePath);
        ExerciseList exerciseList = JsonSerializer.Deserialize<ExerciseList>(json);
        exercises = exerciseList.Exercises;

        pickerModel = new ExerciseViewModel();
        if (exercises != null)
        {
            foreach (Exercise exercise in exercises)
            {
                pickerModel.AddPicker(exercise.Name);
            }
        }
        BindingContext = pickerModel;
    }

    private void btnSubmit_Clicked(object sender, EventArgs e)
    {
        string exercise = picker.Items[picker.SelectedIndex];
        string numReps = entryRep.Text;
        string numSets = entrySet.Text;

        pickerModel.AddExercise(exercise, numReps, numSets);
        
        //dateSelectedLabel.Text = button.Text;
    }

    private void btnDay_Clicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        selectedDate = button.Text;
    }

    private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var exercise = exercises.ElementAt(e.SelectedItemIndex);
        //exerciseSelectedLabel.Text = exercise.Name;
    }

    /*
    private void OnDrag(object sender, DragStartingEventArgs e)
    {
        e.Data.Properties.Add("Frame", myFrame);
    }

    private void OnDrop(object sender, DropEventArgs e)
    {
        if (e.Data.Properties.ContainsKey("Frame"))
        {
            var frame = e.Data.Properties["Frame"] as Frame;
            myDropTarget.Content = frame.Content;
        }
    }
    */
}