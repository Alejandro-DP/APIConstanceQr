using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ValidaTecAPI.Models;
using ValidaTecAPI.Repository;

namespace ValidaTecAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CarrerController : ControllerBase
    {
        private readonly Context _context;
        public CarrerController(Context context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carrer>>> GetAllCarrer()
        {
           return await _context.Carrers.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Carrer>> GetCarrer(int id)
        {
            var carrer = await _context.Carrers.FindAsync(id);
            if (carrer == null)
            {
                return NotFound("404 no encintrado");
            }
            return carrer;
        }
        [HttpPost]
        public async Task<ActionResult<Carrer>> PostCourse(Carrer carrer )
        {
            _context.Carrers.Add(carrer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAllCarrer", new { id = carrer.Id }, carrer);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarrer(int id, Carrer carrer)
        {
            if(id != carrer.Id)
            {
                return BadRequest("No encontrado");
            }
            _context.Entry(carrer).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }
            return CreatedAtAction("GetAllCarrer", new { id = carrer.Id }, carrer);
        }
        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.Id == id);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarrer(int id)
        {
            
            var carrer = await _context.Carrers.FindAsync(id);
            if (carrer == null)
            {
                return NotFound();
            }
            _context.Carrers.Remove(carrer);
            await _context.SaveChangesAsync();

            return Ok("Borrado la Carrera" +" "+ carrer.Name);
        }
    }
}
