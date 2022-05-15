using Blazored.Toast.Services;
using ReHealth.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ReHealth.Client.Services.SavedExerciseService
{
    public class SavedExerciseService : ISavedExerciseService
    {
        public event Action OnChange;

        private readonly HttpClient _client;

        private readonly IToastService _toastService;

        public SavedExerciseService(HttpClient client, IToastService toastService)
        {
            _client = client;
            _toastService = toastService;
        }


        public async Task AddSavedExercise(Exercise exercise, string user)
        {

            var savedExercise = new SavedExercise
            {
                ExerciseId = exercise.Id,
                ExerciseName = exercise.Name,
                ExerciseGifUrl = exercise.gifUrl,
                AspNetUser = user
            };

            var currentSavedExercises = await GetSavedExercises(user);

            bool check = new bool();

            foreach (var item in currentSavedExercises)
            {
                if (item.ExerciseId == savedExercise.ExerciseId)
                {
                    check = true;
                }
            }

            if (!check)
            {
                await _client.PostAsJsonAsync("api/SavedExercises", savedExercise);
                _toastService.ShowSuccess(savedExercise.ExerciseName, "Added to saved Exercises:");
            }
            else
            {
                _toastService.ShowError(savedExercise.ExerciseName, "Already Exists in saved Exercises");
            }




        }

        public async Task DeleteSavedExercise(int id)
        {
            await _client.DeleteAsync($"api/SavedExercises/{id}");
        }

        public async Task<List<SavedExercise>> GetSavedExercises(string user)
        {
            var result = await _client.GetFromJsonAsync<ServiceResponse<List<SavedExercise>>>($"api/SavedExercises/{user}");
            return result.Data;
        }
    }
}
