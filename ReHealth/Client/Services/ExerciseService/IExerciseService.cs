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
        Task<ServiceResponse<Exercise>> GetExerciseById(int Id);
        Task<ServiceResponse<List<Exercise>>> GetExercises();
    }
}
