using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReHealth.Server.Data;
using ReHealth.Shared;

namespace ReHealth.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ExercisesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Exercises
        [HttpGet]
        public async Task<ActionResult<List<Exercise>>> GetExercises()
        {
            return await _context.Exercise.ToListAsync();
        }

        // GET: api/Exercises/5
        [HttpGet("{id}")]
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

        // GET: api/Exercises/bodypart/{bodypart}
        [HttpGet("bodypart/{bodypart}")]
        public async Task<ServiceResponse<List<Exercise>>> GetExercisesByBodyPart(string bodyPart)
        {
            var response = new ServiceResponse<List<Exercise>>
            {
                Data = await _context.Exercise
                .Where(p => p.BodyPart.ToLower().Equals(bodyPart.ToLower())).ToListAsync()
            };

            return response;
        }

        //GET: api/Exercises/equipment/{equipment}
        [HttpGet("equipment/{equipment}")]
        public async Task<ServiceResponse<List<Exercise>>> GetExercisesByEquipment(string equipment)
        {
            var response = new ServiceResponse<List<Exercise>>
            {
                Data = await _context.Exercise
                .Where(p => p.Equipment.ToLower().Equals(equipment.ToLower())).ToListAsync()
            };

            return response;
        }

        //GET: api/Exercises/target/{target}
        [HttpGet("target/{target}")]
        public async Task<ServiceResponse<List<Exercise>>> GetExercisesByTarget(string target)
        {
            var response = new ServiceResponse<List<Exercise>>
            {
                Data = await _context.Exercise
                .Where(p => p.Target.ToLower().Equals(target.ToLower())).ToListAsync()
            };

            return response;
        }

        private bool ExerciseExists(int id)
        {
            return _context.Exercise.Any(e => e.Id == id);
        }
    }
}
