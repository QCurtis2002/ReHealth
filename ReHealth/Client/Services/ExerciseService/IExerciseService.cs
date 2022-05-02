using ReHealth.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReHealth.Client.Services.ExerciseService
{
    public interface IExerciseService
    {
        event Action ExercisesChanged;
        string Message { get; set; }
        List<Exercise> Exercises { get; set; }
        Task<ServiceResponse<Exercise>> GetExerciseById(int id);
        //Task<ServiceResponse<List<Exercise>>> GetExercises();
        Task GetExercises(string type = null, string filter = null);

    }
}
