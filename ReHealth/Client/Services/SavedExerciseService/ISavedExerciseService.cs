using ReHealth.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReHealth.Client.Services.SavedExerciseService
{
    public interface ISavedExerciseService
    {
        event Action OnChange;
        Task<List<SavedExercise>> GetSavedExercises(string user);
        Task AddSavedExercise(SavedExercise savedExercise);
        Task DeleteSavedExercise(int id);
    }
}
