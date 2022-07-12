using hotel_api.Data;
using hotel_api.DTOs;
using hotel_api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace hotel_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        // Access The appsettong.json
        private IConfiguration _config;
        private ApplicationDbContext _context;

        public AccountController(IConfiguration config, ApplicationDbContext context)
        {
            _config = config;
            _context = context;
        }

        [HttpGet("Admins")]
        [Authorize(Roles = "Admin")]
        public IActionResult AdminsEndpoints()
        {
            var curUser = GetCurrentUser();

            return Ok($"Hi {curUser.Username}, you are {curUser.Role}");
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            _context.Entry(user).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return Ok(user);
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginData userLogin)
        {
            User user = Authenticate(userLogin);

            if (user != null)
            {
                var token = Generate(user);
                return Ok(token);
            }

            return NotFound("User not found");
        }

        private string Generate(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              claims,
              expires: DateTime.Now.AddMinutes(15),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private User Authenticate(LoginData userLogin)
        {
            //var currentUser = UserConstants.Users
            //    .FirstOrDefault(o => o.Username.ToLower() == userLogin.Username.ToLower() && o.Password == userLogin.Password);


            User currentUser = _context.Users
                .Where(x => x.Username == userLogin.Username && x.Password == userLogin.Password)
                .FirstOrDefault();

            if (currentUser != null)
            {
                return currentUser;
            }

            return null;
        }

        private User GetCurrentUser()
        {
            //string username = HttpContext.User.Identity.Name;

            //return _context.Users.Where(x => x.Username == username).FirstOrDefault();

            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userClaims = identity.Claims;

                return new User
                {
                    Username = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Name)?.Value,
                    Role = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value
                };
            }

            return null;
        }
    }
}
