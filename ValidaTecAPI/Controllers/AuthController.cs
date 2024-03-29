﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
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
        public IConfiguration _Configuration;
        public AuthController(Context context, IMapper mapper, IConfiguration configuration)
        {
            this.context = context;
            this.mapper = mapper;
            _Configuration = configuration;
        }
        [HttpPost("login")]
        public async Task<ActionResult<LoginCTDO>> UserLogin(Login user)
        {
            var login = await context.Users.Include(x => x.UserRole).FirstOrDefaultAsync(u => u.Email == user.Email);
            if (login == null)
                return Ok(new ErrorsDTO() { status = "alert", message = "usuario o contraseña incorrectos" });
            var isValidPassword = await context.Users.Include(u => u.UserRole).FirstOrDefaultAsync(x => x.Password == user.Password);/*BCrypt.Net.BCrypt.Verify(login.Password, user.Password);*/
            if (isValidPassword == null)
                return Ok(new ErrorsDTO() { status = "error", message = "Ocurrio algun problema intentelo mas tarde" });
            //return BadRequest("usuario o contraseña incorrectos");
            else
            {
                var userData = await GetUsers(user.Email, user.Password);
                var jwt = _Configuration.GetSection("Jwt").Get<Jwt>();

                var claims = new[]
                {
                        new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, jwt.Subject),

                        new Claim("Email", user.Email),
                        new Claim("Password", user.Password),

                    };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
                var singIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var tokens = new JwtSecurityToken
                         (
                          jwt.Issuer,
                          jwt.Audience,
                          claims,
                          expires: DateTime.Now.AddMinutes(20),
                          signingCredentials: singIn
                         );
                var token = new JwtSecurityTokenHandler().WriteToken(tokens);
                //return Ok(new JwtSecurityTokenHandler().WriteToken(token));

                return Ok(new LoginCTDO() { status = "sucess", userName = login.LastName + " " + (login.Name), isAdmin = true, token = token });
            }
        }
           
           
        
        [HttpGet("Usuarios")]
        public async Task<User> GetUsers(string email, string password)
        {

            return await context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }
    }
}





//var login = await context.Users.Include(x => x.UserRole).FirstOrDefaultAsync(u => u.Email == user.Email);
//if (login == null)
//    return NotFound();
//var isValidPassword = BCrypt.Net.BCrypt.Verify(login.Password, user.Password);
//if (isValidPassword)
//    return Ok(new LoginCTDO() { isLogged = true, Role = login.UserRole.Description, UserId = login.UserId });

//else
//{

//}

//var userData = await GetUsers(user.Email, user.Password);
//var jwt = _Configuration.GetSection("Jwt").Get<Jwt>();
//if (user != null)
//{
//    var claims = new[]
//    {
//                        new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
//                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
//                        new Claim(JwtRegisteredClaimNames.Iat, jwt.Subject),

//                        new Claim("Email", user.Email),
//                        new Claim("Password", user.Password),

//                    };
//    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
//    var singIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
//    var token = new JwtSecurityToken
//             (
//              jwt.Issuer,
//              jwt.Audience,
//              claims,
//              expires: DateTime.Now.AddMinutes(20),
//              signingCredentials: singIn
//             );

//    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
//}
//else
//{
//    return BadRequest("Credenciales Invalidas");
//}

//            }
//            else
//{
//    return BadRequest("Credenciales Invalidas x2");
//}