using DonMacaron.Data;
using DonMacaron.Services.TokenServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using DonMacaron.Entities;
using Microsoft.AspNetCore.Authorization;
using DonMacaron.DTOs.UserDtos;
using Microsoft.AspNetCore.Authorization.Infrastructure;



namespace DonMacaron.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly TokenService _tokenService;

        public AuthController(DataContext context, TokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _context.Users
                .Include(u => u.Roles)
                .SingleOrDefaultAsync(x => x.Login == model.Login);

            if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
                return Unauthorized();

            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new("Login", user.Login)
            };

            foreach (var role in user.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Name));
            }

            var accessToken = _tokenService.GenerateAccessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            await _context.SaveChangesAsync();

            Response.Cookies.Append("refreshToken", refreshToken, new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.Now.AddDays(7),
                SameSite = SameSiteMode.None,
                Secure = true
            });

            return Ok(new
            {
                AccessToken = accessToken
            });
        }
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];

            if (refreshToken == null)
                return Unauthorized();

            var user = await _context.Users
                .Include(u => u.Roles)
                .SingleOrDefaultAsync(u => u.RefreshToken == refreshToken);

            if (user == null || user.RefreshTokenExpiryTime <= DateTime.Now)
                return Unauthorized();

            var claims = new List<Claim>
                {
                    new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new("Login", user.Login),
                };
            foreach (var role in user.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Name));
            }

            var accessToken = _tokenService.GenerateAccessToken(claims);
            var newRefreshToken = _tokenService.GenerateRefreshToken();


            user.RefreshToken = newRefreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            await _context.SaveChangesAsync();

            Response.Cookies.Append("refreshToken", newRefreshToken, new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.Now.AddDays(7),
                SameSite = SameSiteMode.None,
                Secure = true
            });

            return Ok(new
            {
                AccessToken = accessToken
            });
        }

        [HttpPost("create-admin")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> CreateAdminUser(CreateUserDto createUserDto)
        {
            // Проверяем, есть ли уже администратор с таким email
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Login == createUserDto.Login);

            if (existingUser != null)
            {
                return BadRequest("Admin user already exists.");
            }


            List<Role> roles = [];

            foreach (int i in createUserDto.Roles){
                var role = await _context.Roles.FindAsync(i);
                if (role == null) return BadRequest("Role not found");
                roles.Add(role);
            } 

            var adminUser = new User
            {
                Login = createUserDto.Login,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(createUserDto.Password), 
                Roles = roles
            };

            _context.Users.Add(adminUser);
            await _context.SaveChangesAsync();

            return Ok("Admin user created.");
        }
    }
    public class LoginModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }

    public class RefreshTokenModel
    {
        public string RefreshToken { get; set; }
    }
}


