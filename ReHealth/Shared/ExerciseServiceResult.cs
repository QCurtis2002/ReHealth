using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReHealth.Shared
{
    public class ExerciseServiceResult
    {
        public List<Exercise> Exercises { get; set; }
        public int pages { get; set; }
        public int CurrentPage { get; set; }
    }
}
