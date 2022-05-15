using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReHealth.Shared
{
    public class SavedExercise
    {
        public int Id { get; set; }
        public string AspNetUser { get; set; }
        public Exercise Exercises { get; set; }
        public int ExerciseId { get; set; }
        public string ExerciseGifUrl { get; set; }
        public string ExerciseName { get; set; }
    }
}
