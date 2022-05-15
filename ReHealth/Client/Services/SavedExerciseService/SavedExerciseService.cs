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

        public SavedExerciseService(HttpClient client)
        {
            _client = client;
        }


        public async Task AddSavedExercise(SavedExercise savedExercise)
        {
            await _client.PostAsJsonAsync("api/SavedExercises", savedExercise);
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
