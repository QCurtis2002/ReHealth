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

        public ExerciseService(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("WebAPI.NoAuthenticationClient");
        }

        public async Task<ServiceResponse<Exercise>> GetExerciseById(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<Exercise>>> GetExercises()
        {
            var result = await _client.GetFromJsonAsync<ServiceResponse<List<Exercise>>>("api/Exercises");
            return result;
        }
    }
}
