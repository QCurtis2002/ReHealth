using ReHealth.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ReHealth.Client.Services.ExerciseService
{
    public class ExerciseService : IExerciseService
    {
        public event Action ExercisesChanged;

        private readonly HttpClient _client;

        public string Message { get; set; } = "Loading Exercises...";

        public List<Exercise> Exercises { get; set; } = new List<Exercise>();

        public ExerciseService(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("WebAPI.NoAuthenticationClient");
        }

        public async Task<ServiceResponse<Exercise>> GetExerciseById(int id)
        {
            var result = await _client.GetFromJsonAsync<ServiceResponse<Exercise>>($"api/exercises/{id}");
            return result;
        }

        //public async Task<ServiceResponse<List<Exercise>>> GetExercises()
        //{
        //    var result = await _client.GetFromJsonAsync<ServiceResponse<List<Exercise>>>("api/Exercises");
        //    return result;
        //}

        public async Task GetExercises(string type = null, string filter = null)
        {
            var result = new ServiceResponse<List<Exercise>>();

            if (type == null || filter == null)
            {
                result = await _client.GetFromJsonAsync<ServiceResponse<List<Exercise>>>("api/Exercises");
            }
            else if (type == "bodypart")
            {
                result = await _client.GetFromJsonAsync<ServiceResponse<List<Exercise>>>($"api/Exercises/bodypart/{filter}");
            }
            else if (type == "equipment")
            {
                result = await _client.GetFromJsonAsync<ServiceResponse<List<Exercise>>>($"api/Exercises/equipment/{filter}");
            }
            else if (type == "target")
            {
                result = await _client.GetFromJsonAsync<ServiceResponse<List<Exercise>>>($"api/Exercises/target/{filter}");
            }

            Exercises = result.Data;
            ExercisesChanged.Invoke();
        }
    }
}
