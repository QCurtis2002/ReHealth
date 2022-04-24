using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReHealth.Shared
{
    public class SavedExercises
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Exercises Exercises { get; set; }
        public int ExerciseId { get; set; }
    }
}
