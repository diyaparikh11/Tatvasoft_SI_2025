using Microsoft.AspNetCore.Mvc;
using Mission.Repositories;
using Mission.Api.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Mission.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IUserRepository _userRepo;

        public LoginController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var user = _userRepo.ValidateUser(request.Username, request.Password);
            if (user == null)
                return Unauthorized("Invalid credentials.");

            // 👇 JWT Token generation
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role ?? "User") // Fallback to "User"
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySuperLongSecretKey_ForJWT_Auth_12345!!")); // same as Program.cs
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                username = user.Username,
                role = user.Role
            });
        }
    }
}
