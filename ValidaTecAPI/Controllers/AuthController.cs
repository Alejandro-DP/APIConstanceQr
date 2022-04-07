using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ValidaTecAPI.DTO;
using ValidaTecAPI.Models;
using ValidaTecAPI.Repository;


namespace ValidaTecAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly Context context;
        private readonly IMapper mapper;
        public AuthController(Context context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
         [HttpPost("login")]
        public async Task<ActionResult<LoginCTDO>> UserLogin(Login login)
        {
            var user = await context.Users.Include(x => x.UserRole).FirstOrDefaultAsync(u => u.Email == login.Email);
            if (user == null)
                return NotFound();
            var isValidPassword = BCrypt.Net.BCrypt.Verify(login.Password, user.Password);
            if (isValidPassword)
                return Ok(new LoginCTDO() { isLogged = true, Role = user.UserRole.Description, UserId = user.UserId });

            else
                return BadRequest("Password is not valid");
        }
        [HttpGet("Usuarios")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await context.Users.Include(u => u.UserRole).ToListAsync();

        }
    }
}
