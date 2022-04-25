using ReHealth.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReHealth.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace ReHealth.Server.Services.ExerciseService
{
    public class ExerciseService : IExerciseService
    {

        private readonly ApplicationDbContext _context;

        public ExerciseService(ApplicationDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Get all exercises for that body part
        /// </summary>
        /// <param name="bodyPart"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<List<Exercise>>> GetExerciseByBodyPart(string bodyPart)
        {
            var response = new ServiceResponse<List<Exercise>>
            {
                Data = await _context.Exercise
                .Where(p => p.BodyPart.ToLower().Equals(bodyPart.ToLower())).ToListAsync()
            };

            return response;

        }
        /// <summary>
        /// Get all exercises for that equipment
        /// </summary>
        /// <param name="equipment"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<List<Exercise>>> GetExerciseByEquipment(string equipment)
        {
            var response = new ServiceResponse<List<Exercise>>
            {
                Data = await _context.Exercise
                .Where(p => p.Equipment.ToLower().Equals(equipment.ToLower())).ToListAsync()
            };

            return response;
        }
        /// <summary>
        /// Get the specific exercise given the Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<Exercise>> GetExerciseById(int id)
        {
            var response = new ServiceResponse<Exercise>();
            var exercise = await _context.Exercise.FindAsync(id);
            if (exercise == null)
            {
                response.Success = false;
                response.Message = "Sorry, but this exercise does not exist";
            }
            else
            {
                response.Data = exercise;
            }

            return response;
        }
        /// <summary>
        /// Get all Exercises for that target area
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<List<Exercise>>> GetExerciseByTarget(string target)
        {
            var response = new ServiceResponse<List<Exercise>>
            {
                Data = await _context.Exercise
                .Where(p => p.Target.ToLower().Equals(target.ToLower())).ToListAsync()
            };

            return response;
        }
        /// <summary>
        /// Get all the exercises
        /// </summary>
        /// <returns></returns>
        public Task<ServiceResponse<List<Exercise>>> GetExercises()
        {
            throw new NotImplementedException();
        }
    }
}
