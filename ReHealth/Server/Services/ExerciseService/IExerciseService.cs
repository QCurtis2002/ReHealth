using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReHealth.Shared;

namespace ReHealth.Server.Services.ExerciseService
{
    public interface IExerciseService
    {
        Task<ServiceResponse<List<Exercise>>> GetExercises();
        Task<ServiceResponse<Exercise>> GetExerciseById(int id);
        Task<ServiceResponse<List<Exercise>>> GetExerciseByEquipment(string equipment);
        Task<ServiceResponse<List<Exercise>>> GetExerciseByBodyPart(string bodyPart);
        Task<ServiceResponse<List<Exercise>>> GetExerciseByTarget(string target);
    }
}
