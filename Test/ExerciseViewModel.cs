using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{

    public class ExerciseRows
    {
        private string _exercise = string.Empty;
        private string _reps = string.Empty;
        private string _sets = string.Empty;
        public string Exercise
        {
            get { return _exercise; }
            set { _exercise = value; }
        }

        public string Reps
        {
            get { return _reps; }
            set { _reps = value; }
        }

        public string Sets
        {
            get { return _sets; }
            set { _sets = value; }
        }

        public ExerciseRows(string exercise, string reps, string sets)
        {
            _exercise = exercise;
            _reps = reps;
            _sets = sets;
        }
    }

    public class ExerciseViewModel
    {

        private ObservableCollection<ExerciseRows> exerciseCollection = new ObservableCollection<ExerciseRows>();
        private ObservableCollection<string> exercisePickerCollection = new ObservableCollection<string>();

        public ExerciseViewModel()
        {

        }

        public void AddPicker(string project)
        {
            exercisePickerCollection.Add(project);
        }

        public void AddExercise(string exercise, string reps, string sets)
        {
            exerciseCollection.Add(new ExerciseRows(exercise, reps, sets));
        }

        public ObservableCollection<ExerciseRows> ExerciseCollection
        {
            get { return exerciseCollection; }
            set { exerciseCollection = value; }
        }

        public ObservableCollection<string> ExercisePickerCollection
        {
            get { return exercisePickerCollection; }
            set { exercisePickerCollection = value; }
        }
    }
}