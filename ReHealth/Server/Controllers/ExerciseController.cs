using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReHealth.Server.Data;
using ReHealth.Server.Services.ExerciseService;
using ReHealth.Shared;

namespace ReHealth.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {

        private readonly IExerciseService _exerciseService;

        public ExerciseController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Exercise>>>> GetExercises()
        {
            var response = await _exerciseService.GetExercises();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Exercise>>> GetExerciseById(int id)
        {
            var result = await _exerciseService.GetExerciseById(id);
            return Ok(result);
        }

        [HttpGet("bodypart/{bodypart}")]
        public async Task<ActionResult<ServiceResponse<Exercise>>> GetExerciseByBodyPart(string bodyPart)
        {
            var result = await _exerciseService.GetExerciseByBodyPart(bodyPart);
            return Ok(result);
        }

        [HttpGet("equipment/{equipment}")]
        public async Task<ActionResult<ServiceResponse<Exercise>>> GetExerciseByEquipment(string equipment)
        {
            var result = await _exerciseService.GetExerciseByEquipment(equipment);
            return Ok(result);
        }

        [HttpGet("target/{target}")]
        public async Task<ActionResult<ServiceResponse<Exercise>>> GetExerciseByTarget(string target)
        {
            var result = await _exerciseService.GetExerciseByTarget(target);
            return Ok(result);
        }

    }
}
