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
    public class SavedExercisesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SavedExercisesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SavedExercises/5
        [HttpGet("{id}")]
        public async Task<ServiceResponse<List<SavedExercise>>> GetSavedExercises(string user)
        {
            var response = new ServiceResponse<List<SavedExercise>>
            {
                Data = await _context.SavedExercise
                .Where(p => p.AspNetUser.ToLower().Equals(user.ToLower())).ToListAsync()
            };

            return response;
        }

        // PUT: api/SavedExercises/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSavedExercise(int id, SavedExercise savedExercise)
        {
            if (id != savedExercise.Id)
            {
                return BadRequest();
            }

            _context.Entry(savedExercise).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SavedExerciseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/SavedExercises
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SavedExercise>> PostSavedExercise(SavedExercise savedExercise)
        {
            _context.SavedExercise.Add(savedExercise);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSavedExercise", new { id = savedExercise.Id }, savedExercise);
        }

        // DELETE: api/SavedExercises/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSavedExercise(int id)
        {
            var savedExercise = await _context.SavedExercise.FindAsync(id);
            if (savedExercise == null)
            {
                return NotFound();
            }

            _context.SavedExercise.Remove(savedExercise);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SavedExerciseExists(int id)
        {
            return _context.SavedExercise.Any(e => e.Id == id);
        }
    }
}
