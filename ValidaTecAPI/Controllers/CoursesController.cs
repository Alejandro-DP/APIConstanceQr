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
    public class CoursesController : ControllerBase
    {
        private readonly Context _context;

        public CoursesController(Context context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Courses>>> GetAllCourses()
        {
            return await _context.Courses.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Courses>> GetCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound("404 no encintrado");
            }
            return course;
        }
        [HttpPost]
        public async Task<ActionResult<Courses>> PostCourse(Courses courses)
        {
            _context.Courses.Add(courses);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCourse", new { id = courses.Id }, courses);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(int id, Courses courses)
        {
            if (id != courses.Id)
            {
                return BadRequest();
            }

            _context.Entry(courses).State = EntityState.Modified ;

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

            return CreatedAtAction("GetCourse", new { id = courses.Id }, courses);
        }
        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.Id == id);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id) 
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
